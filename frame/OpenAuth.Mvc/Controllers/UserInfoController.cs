using Infrastructure;
using OpenAuth.App;
using OpenAuth.App.Response;
using OpenAuth.Repository.Domain.DonvvOffice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace OpenAuth.Mvc.Controllers
{
    public class UserInfoController : Controller
    {


        public T_User_InfoApp app { get; set; }

        public T_User_CompanyAuthApp companyAuthapp { get; set; }

        public T_Company_InfoApp Companyapp { get; set; }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult UserList()
        {
            return View();
        }


        public string GetList(string name, string companyName, string auditStatus, int isEnable)
        {
            int pageSize = Convert.ToInt32(this.HttpContext.Request.Form["limit"]);
            int pageNo = Convert.ToInt32(this.HttpContext.Request.Form["page"]);

            var result = new TableData();
            try
            {
                var res = from a in app.UnitWork.Find<T_User_Info>(x => x.ID > 0)
                          join b in app.UnitWork.Find<T_Company_Info>(x => x.ID > 0)
                          on a.CompanyGuid equals b.RowGuid
                          into c
                          from d in c.DefaultIfEmpty()

                          select new UserInfo()
                          {
                              RowGuid = a.RowGuid,
                              AddTime = a.AddTime,
                              Address = a.Address,
                              CompanyGuid = a.CompanyGuid,
                              CompanyName = a.CompanyName,
                              AuthGuid = a.AuthGuid,
                              AvatarUrl = a.AvatarUrl,
                              DeptName = a.DeptName,
                              Email = a.Email,
                              IsAuth = a.IsAuth,
                              IsEnable = a.IsEnable,
                              Name = a.Name,
                              NickName = a.NickName,
                              OpenId = a.OpenId,
                              Position = a.Position,
                              Sex = a.Sex,
                              Tel = a.Tel


                          };

                //拼接表达式
                Expression<Func<UserInfo, bool>> exp = PredicateBuilder.True<UserInfo>();
                if (!string.IsNullOrEmpty(name))
                {
                    exp = exp.And(x => x.Name.Contains(name) || x.NickName.Contains(name));
                }

                if (!string.IsNullOrEmpty(companyName))
                {
                    exp = exp.And(x => x.CompanyName.Contains(companyName));
                }


                if (!string.IsNullOrEmpty(auditStatus))
                {
                    int statusValue = Convert.ToInt32(auditStatus);
                    exp = exp.And(x => x.IsAuth == statusValue);
                }

                if (isEnable != -1)
                {
                    bool isEnableValue = isEnable == 1 ? true : false;
                    exp = exp.And(x => x.IsEnable == isEnableValue);
                }

                IQueryable<UserInfo> iquery = ExpandableHelper.GetExpandable(res.Where(exp));
                List<UserInfo> list = iquery.OrderByDescending(x => x.AddTime).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
                list.ForEach(x =>
                {
                    x.AddTimeStr = x.AddTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                });

                int _totalCount = iquery.Count();
                result.code = 0;  //Layui默认的返回成功code为0；
                result.data = list;
                result.count = _totalCount;


            }
            catch (Exception ex)
            {
                result.code = 500;
                result.msg = "请求用户数据发生错误!";
                //写到日志里面
                LogHelper.Log(ex.Message);
            }

            return JsonHelper.Instance.SerializeByConverter(result);
        }




        [HttpPost]
        public string SetUnEnable(string rowGuid)
        {
            var result = new Response();
            try
            {
                T_User_Info info = app.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));
                if (info == null)
                {
                    result.Code = 500;
                    result.Message = "您要操作的数据不存在!";
                }
                else
                {
                    info.IsEnable = false;
                    app.Repository.Update(info);
                    result.Code = 200;
                    result.Message = "置为不可用成功!";
                }
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.ToString();
                LogHelper.Log(ex.ToString());

            }

            return JsonHelper.Instance.Serialize(result);
        }


        [HttpPost]
        public string SetEnable(string rowGuid)
        {
            var result = new Response();
            try
            {
                T_User_Info info = app.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));
                if (info == null)
                {
                    result.Code = 500;
                    result.Message = "您要操作的数据不存在!";
                }
                else
                {
                    info.IsEnable = true;
                    app.Repository.Update(info);
                    result.Code = 200;
                    result.Message = "置为可用成功!";
                }
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.ToString();
                LogHelper.Log(ex.ToString());

            }

            return JsonHelper.Instance.Serialize(result);
        }


        public ViewResult Detail(string rowGuid)
        {
            T_User_CompanyAuth Info = companyAuthapp.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));
            string hostUrl = ConfigurationManager.AppSettings["hostUrl"].ToString();
            if (Info != null)
            {
                if (Info.CardUrl != null)
                { Info.CardUrl = hostUrl + Info.CardUrl.TrimStart('~'); }

                if (Info.BusinessLicenseUrl != null)
                { Info.BusinessLicenseUrl = hostUrl + Info.BusinessLicenseUrl.TrimStart('~'); }

            }
            else
            { Info = new T_User_CompanyAuth(); }


            return View(Info);
        }


        public string Audit(int type, string rowGuid)
        {
            T_User_CompanyAuth info = companyAuthapp.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));

            T_User_Info infoUser = app.Repository.FindSingle(x => x.AuthGuid.Equals(rowGuid));
            var result = new Response();
            if (info != null && infoUser != null)
            {
                switch (type)
                {
                    case 1: //审核通过
                        info.IsAuth = 1;
                        companyAuthapp.Repository.Update(info);

                        infoUser.IsAuth = 1;
                        app.Repository.Update(infoUser);
                        break;

                    case 2: //审核不通过
                        info.IsAuth = 2;
                        companyAuthapp.Repository.Update(info);

                        infoUser.IsAuth = 2;
                        app.Repository.Update(infoUser);
                        break;
                }

                result.Code = 200;
                result.Message = "审核成功!";
            }
            else {
                result.Code = 500;
                result.Message = "用户还没有上传相关资料，无法审核!";
            }
            
            return JsonHelper.Instance.Serialize(result);

        }

        public class UserInfo
        {
            public string RowGuid { get; set; }
            public string Name { get; set; }
            public string Tel { get; set; }
            public string Email { get; set; }

            public string Address { get; set; }
            public int? Sex { get; set; }
            public string NickName { get; set; }
            public string AvatarUrl { get; set; }
            public string CompanyGuid { get; set; }
            public string CompanyName { get; set; }

            public string DeptName { get; set; }
            public string Position { get; set; }
            public string OpenId { get; set; }

            public bool? IsEnable { get; set; }

            public int? IsAuth { get; set; }
            public string AuthGuid { get; set; }

            public DateTime? AddTime { get; set; }

            public string AddTimeStr { get; set; }
        }

    }
}