using _OpenAuth.Repository.Domain.DonvvOffice;
using Infrastructure;
using OpenAuth.App;
using OpenAuth.App.Response;
using OpenAuth.App.SSO;
using OpenAuth.Repository.Domain.DonvvOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace OpenAuth.Mvc.Controllers
{
    public class TypeMainController : BaseController
    {


        public TypeMainApp app { get; set; }


        public ActionResult Index()
        {
            return View();
        }


        public string GetList(string typeText)
        {
            int pageSize = Convert.ToInt32(this.HttpContext.Request.Form["limit"]);
            int pageNo = Convert.ToInt32(this.HttpContext.Request.Form["page"]); ;
            var result = new TableData();
            try
            {
                //拼接表达式
                Expression<Func<T_Dic_TypeMain, bool>> exp = PredicateBuilder.True<T_Dic_TypeMain>();
                if (!string.IsNullOrEmpty(typeText))
                {
                    exp = exp.And(x => x.Type.Contains(typeText));
                }
                IQueryable<T_Dic_TypeMain> _iqueryResult = app.Repository.Find(pageNo, pageSize, "", exp);
                int _totalCount = app.Repository.GetCount(exp);
                result.code = 0;  //Layui默认的返回成功code为0；
                result.data = _iqueryResult;
                result.count = _totalCount;
            }
            catch (Exception ex)
            {
                result.code = 500;
                result.msg = "请求大类数据发生错误!";
                //写到日志里面
                LogHelper.Log(ex.Message);
            }

            return JsonHelper.Instance.SerializeByConverter(result);
        }



        public string DeleteMainType(string rowGuid)
        {
            var result = new Response();
            try
            {
                T_Dic_TypeMain _typeMain = app.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));
                if (_typeMain == null)
                {
                    result.Code = 500;
                    result.Message = "您要删除的数据不存在!";
                }
                else
                {
                    app.Repository.Delete(_typeMain);
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


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public string Add(string obj)
        {
            var result = new Response();
            try
            {
                T_Dic_TypeMain model = JsonHelper.Instance.Deserialize<T_Dic_TypeMain>(obj);
                model.RowGuid = Guid.NewGuid().ToString();
                app.Repository.Add(model);
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


        [HttpGet]
        public ActionResult Edit(string rowGuid)
        {
            T_Dic_TypeMain main = app.Repository.FindSingle(x=>x.RowGuid.Equals(rowGuid));
            return View(main);
        }


        [HttpPost]
        public string EditData(string obj)
        {
            var result = new Response();
            try
            {
                T_Dic_TypeMain model = JsonHelper.Instance.Deserialize<T_Dic_TypeMain>(obj);            
                app.Repository.Update(model);
                result.Code = 200;
                result.Message = "编辑成功!";
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.ToString();
                LogHelper.Log(ex.ToString());
            }
            return JsonHelper.Instance.Serialize(result);
        }

    }
}