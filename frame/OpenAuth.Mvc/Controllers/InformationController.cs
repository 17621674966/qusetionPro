using _OpenAuth.Repository.Domain.DonvvOffice;
using Infrastructure;

using OpenAuth.App;
using OpenAuth.App.Response;
using OpenAuth.App.SSO;
using OpenAuth.Repository.Domain.DonvvOffice;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace OpenAuth.Mvc.Controllers
{
    public class InformationController : Controller
    {

        public T_Dic_TypeItemApp app { get; set; }

        public T_Information_InfoApp appInformation { get; set; }

        public T_Information_SharesApp appShare { get; set; }

        public T_Information_TitleImgApp appTitleImg { get; set; }


        public T_Information_AttachApp appAttach { get; set; }



        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            string informationTypeGuid = ConfigurationManager.AppSettings["informationTypeGuid"].ToString();

            List<T_Dic_TypeItem> list = app.Repository.Find(x => x.TypeGuid.Equals(informationTypeGuid)).ToList();
            ViewBag.TypeItem = list;
            ViewBag.Guid = Guid.NewGuid().ToString();
            return View();
        }



        [HttpPost]
        [ValidateInput(false)]
        public string Add(string obj)
        {
            var result = new Response();
            //var user= AuthUtil.GetCurrentUser()
            string userGuid = ConfigurationManager.AppSettings["addUserGuid"].ToString();
            try
            {
                T_Information_Info model = JsonHelper.Instance.Deserialize<T_Information_Info>(obj);
                model.AddUserGuid = userGuid;
                model.UserGuid = userGuid;
                model.LastModifyUserGuid = userGuid;
                model.AddUserName = "";
                model.AuditStatus = 1;//懂微发布的默认就是审核通过的
                appInformation.Repository.Add(model);


                #region  将信息添加到T_Information_Shares
                T_Information_Shares share = new T_Information_Shares();
                share.RowGuid = Guid.NewGuid().ToString();
                share.InformationGuid = model.RowGuid;
                share.GoodLikeCount = 0;
                share.ToFriendCount = 0;
                share.ToFriendsCount = 0;
                share.BrowseCount = 0;
                share.AddUserGuid = userGuid;
                share.AddTime = DateTime.Now;
                share.LastModifyUserGuid = userGuid;
                share.LastModifyTime = DateTime.Now;
                share.RowStatus = 1;
                appShare.Repository.Add(share);

                #endregion

                result.Code = 200;
                result.Message = "添加成功!";
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.ToString();
                LogHelper.Log(ex.ToString());
            }

            return JsonHelper.Instance.Serialize(result);
        }




        #region   上传资讯的缩略图
        [HttpPost]
        public string AddInformationTitleImg(string guid)
        {
            var result = new Response();


            string userGuid = ConfigurationManager.AppSettings["addUserGuid"].ToString();
            string fileAbsolutePath = ConfigurationManager.AppSettings["fileUploadObsolutePathInformation"].ToString();
            string filePath = ConfigurationManager.AppSettings["fileUploadPathInformation"].ToString();
            try
            {



                for (var i = 0; i < HttpContext.Request.Files.Count; i++)
                {
                    HttpPostedFileBase fileItem = HttpContext.Request.Files[i];
                    string fileName = fileItem.FileName;
                    int fileSize = fileItem.ContentLength;
                    if (fileSize > 1024 * 1000 * 10)
                    {
                        result.Code = 500;
                        result.Message = "您上传的文件过大!";

                    }
                    else
                    {
                        string dicSavePath = fileAbsolutePath;
                        if (!System.IO.Directory.Exists(dicSavePath))
                        {
                            Directory.CreateDirectory(dicSavePath);
                        }

                        string saveFileName = Guid.NewGuid().ToString() + FileHelper.GetFileType(fileName);
                        string fileSavePath = dicSavePath + saveFileName;

                        #region  将数据保存到硬盘
                        fileItem.SaveAs(fileSavePath);
                        #endregion

                        T_Information_TitleImg info = new T_Information_TitleImg();
                        info.TitleImgUrl = filePath + saveFileName;
                        info.InformationGuid = guid;
                        info.AddUserGuid = userGuid;
                        info.LastModifyUserGuid = userGuid;
                        appTitleImg.Repository.Add(info);

                        result.Code = 200;
                        result.Message = "上传缩略图成功!";
                    }
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();

                LogHelper.Log(msg);
            }

            return JsonHelper.Instance.Serialize(result);

        }

        #endregion

        //上传资讯的图片
        [HttpPost]
        public string AddInformationImg(string guid)
        {
            var result = new Response();
            string userGuid = ConfigurationManager.AppSettings["addUserGuid"].ToString();
            string fileAbsolutePath = ConfigurationManager.AppSettings["fileUploadObsolutePathInformation"].ToString();
            string filePath = ConfigurationManager.AppSettings["fileUploadPathInformation"].ToString();
            try
            {
                if (HttpContext.Request.Files.Count <= 0)
                {
                    result.Code = 500;
                    result.Message = "请选择上传的文件！";
                }
                else if (HttpContext.Request.Files.Count > 9) //只能上传9张照片
                {
                    result.Code = 500;
                    result.Message = "最多只能上传9张照片！";
                }
                else
                {
                    for (int i = 0; i < HttpContext.Request.Files.Count; i++)
                    {
                        HttpPostedFileBase fileItem = HttpContext.Request.Files[i];
                        string fileName = fileItem.FileName;
                        int fileSize = fileItem.ContentLength;
                        if (fileSize > 1024 * 1000 * 10)
                        {
                            result.Code = 500;
                            result.Message = "您上传的图片过大!";
                            break;//单个图片不能超过10M

                        }
                        else
                        {
                            string dicSavePath = fileAbsolutePath;
                            if (!System.IO.Directory.Exists(dicSavePath))
                            {
                                Directory.CreateDirectory(dicSavePath);
                            }
                            string saveFileName = Guid.NewGuid().ToString() + FileHelper.GetFileType(fileName);
                            string fileSavePath = dicSavePath + saveFileName;

                            #region  将数据保存到硬盘
                            fileItem.SaveAs(fileSavePath);
                            #endregion

                            #region  数据保存到T_Information_Attach
                            T_Information_Attach attach = new T_Information_Attach();
                            attach.RowGuid = Guid.NewGuid().ToString();
                            attach.AttachName = saveFileName;
                            attach.AttachUrl = filePath + saveFileName;
                            attach.AddTime = DateTime.Now;
                            attach.AddUserGuid = userGuid;
                            attach.LastModifyUserGuid = userGuid;
                            attach.InformationGuid = guid;
                            appAttach.Repository.Add(attach);
                            #endregion 

                        }
                    }

                    result.Code = 200;
                    result.Message = "上传附件成功!";
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                result.Code = 500;
                result.Message = msg;
                LogHelper.Log(msg);
            }

            return JsonHelper.Instance.Serialize(result);
        }



        public ActionResult AuditListIndex()
        {
            return View();
        }



        public string GetList(string title, string addUserName, string beginTime, string endTime, string status)
        {
            int pageSize = Convert.ToInt32(this.HttpContext.Request.Form["limit"]);
            int pageNo = Convert.ToInt32(this.HttpContext.Request.Form["page"]);

            var result = new TableData();
            try
            {
                var res = from a in appInformation.UnitWork.Find<T_Information_Info>(x => x.ID > 0)
                          join b in appInformation.UnitWork.Find<T_User_Info>(x => x.ID > 0)
                          on a.AddUserGuid equals b.RowGuid
                          into c
                          from d in c.DefaultIfEmpty()
                          join e in appInformation.UnitWork.Find<T_Dic_TypeItem>(x => x.ID > 0)
                          on a.TypeItemGuid equals e.RowGuid
                          select new InformationModel()
                          {
                              RowGuid = a.RowGuid,
                              AddTime = a.AddTime,
                              AddUserName = a.AddUserName,
                              TypeItemGuid = a.TypeItemGuid,
                              TypeItemName = e.ItemName,
                              AuditStatus = a.AuditStatus.Value,
                              AuditTime = a.AuditTime,
                              AuditUnReason = a.AuditUnReason,
                              CompanyName = d.CompanyName,
                              LinkTel = d.Tel,
                              OutLine = a.OutLine,
                              ContentValue = a.ContentValue,
                              Title = a.Title,
                              UserGuid = a.UserGuid,
                              NickName = d.NickName

                          };

                //拼接表达式
                Expression<Func<InformationModel, bool>> exp = PredicateBuilder.True<InformationModel>();
                if (!string.IsNullOrEmpty(title))
                {
                    exp = exp.And(x => x.Title.Contains(title));
                }

                if (!string.IsNullOrEmpty(addUserName))
                {
                    exp = exp.And(x => x.CompanyName.Contains(addUserName) || x.AddUserName.Contains(addUserName) || x.NickName.Contains(addUserName));
                }
                if (!string.IsNullOrEmpty(beginTime))
                {
                    DateTime beginTimeValue = Convert.ToDateTime(beginTime);
                    exp = exp.And(x => x.AddTime >= (beginTimeValue));
                }

                if (!string.IsNullOrEmpty(endTime))
                {
                    DateTime endTimeValue = Convert.ToDateTime(endTime);
                    exp = exp.And(x => x.AddTime <= (endTimeValue));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    int statusValue = Convert.ToInt32(status);
                    exp = exp.And(x => x.AuditStatus == statusValue);
                }

                IQueryable<InformationModel> iquery = ExpandableHelper.GetExpandable(res.Where(exp));
                List<InformationModel> list = iquery.OrderByDescending(x => x.AddTime).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
                list.ForEach(x =>
                {
                    x.AddTimeStr = x.AddTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    if (string.IsNullOrEmpty(x.AddUserName))
                    {
                        x.AddUserName = x.NickName;
                    }
                });

                int _totalCount = iquery.Count();
                result.code = 0;  //Layui默认的返回成功code为0；
                result.data = list;
                result.count = _totalCount;


            }
            catch (Exception ex)
            {
                result.code = 500;
                result.msg = "请求资讯数据发生错误!";
                //写到日志里面
                LogHelper.Log(ex.Message);
            }

            return JsonHelper.Instance.SerializeByConverter(result);
        }


        [HttpPost]
        public string DeleteInformation(string rowGuid)
        {
            var result = new Response();
            try
            {
                T_Information_Info info = appInformation.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));
                if (info == null)
                {
                    result.Code = 500;
                    result.Message = "您要删除的数据不存在!";
                }
                else
                {
                    appInformation.Repository.Delete(info);
                    result.Code = 200;
                    result.Message = "删除成功!";
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


        public ActionResult Detail(string rowGuid)
        {
            string informationTypeGuid = ConfigurationManager.AppSettings["informationTypeGuid"].ToString();
            string hostUrl = ConfigurationManager.AppSettings["hostUrl"].ToString();
            List<T_Dic_TypeItem> list = app.Repository.Find(x => x.TypeGuid.Equals(informationTypeGuid)).ToList();
            ViewBag.TypeItem = list;
            T_Information_Info Info = appInformation.Repository.FindSingle(x=>x.RowGuid.Equals(rowGuid));
            Info.ContentValue =CommonHelper.MergeSpace(Info.ContentValue).Trim();
            List<T_Information_TitleImg> listTitleImg = appTitleImg.Repository.Find(x=>x.InformationGuid.Equals(rowGuid)).ToList();
            listTitleImg.ForEach(x =>
            {
                if (x.TitleImgUrl != null)
                {
                    x.TitleImgUrl = hostUrl + x.TitleImgUrl.TrimStart('~');
                }
            });
            List<T_Information_Attach> listAttach = appAttach.Repository.Find(x => x.InformationGuid.Equals(rowGuid)).ToList();
            listAttach.ForEach(x =>
            {
                if (x.AttachUrl != null)
                {
                    x.AttachUrl = hostUrl + x.AttachUrl.TrimStart('~');
                }
            });
            ViewBag.ImgList = listTitleImg;
            ViewBag.AttachList = listAttach;
            return View(Info);

        }


        public string Audit(int type,string contentValue,string rowGuid)
        {
            T_Information_Info info = appInformation.Repository.FindSingle(x=>x.RowGuid.Equals(rowGuid));
            switch (type)
            {
                case 1: //审核通过
                    info.AuditStatus = 1;
                    appInformation.Repository.Update(info);
                    break;

                case 2: //审核不通过
                    info.AuditStatus = 2;
                    info.AuditUnReason = contentValue;
                    appInformation.Repository.Update(info);
                    break;
            }
            var result = new Response();
            result.Code = 200;
            result.Message = "审核成功!";
            return JsonHelper.Instance.Serialize(result);

        }

        public class InformationModel
        {

            public string CompanyName { get; set; }

            public string LinkTel { get; set; }

            public string RowGuid { get; set; }
            public string TypeItemGuid { get; set; }
            public string TypeItemName { get; set; }
            public string UserGuid { get; set; }
            public string TitleImgUrl { get; set; }
            public string Title { get; set; }
            public int AuditStatus { get; set; }
            public DateTime? AuditTime { get; set; }

            public string AuditTimeStr { get; set; }

            public string AuditUnReason { get; set; }
            public string ContentValue { get; set; }

            public string OutLine { get; set; }

            public string AddUserName { get; set; }

            public string AddTimeStr { get; set; }

            public DateTime? AddTime { get; set; }

            public string NickName { get; set; }
        }

    }
}