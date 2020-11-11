using _OpenAuth.Repository.Domain.DonvvOffice;
using Infrastructure;
using OpenAuth.App;
using OpenAuth.App.Response;
using OpenAuth.Repository.Domain.DonvvOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace OpenAuth.Mvc.Controllers
{
    public class TypeItemController : Controller
    {


        public T_Dic_TypeItemApp app { get; set; }

        public TypeMainApp appMain { get; set; }

        public ActionResult Index()
        {
            List<T_Dic_TypeMain> list = appMain.Repository.Find(x=>x.ID>0).ToList();
            ViewBag.TypeMain = list;
            return View();
        }



        public string GetList(string typeText,string typeMain)
        {
            int pageSize = Convert.ToInt32(this.HttpContext.Request.Form["limit"]);
            int pageNo = Convert.ToInt32(this.HttpContext.Request.Form["page"]);
            List<T_Dic_TypeMain> list = appMain.Repository.Find(x => x.ID > 0).ToList();
            var result = new TableData();
            try
            {
                //拼接表达式
                Expression<Func<T_Dic_TypeItem, bool>> exp = PredicateBuilder.True<T_Dic_TypeItem>();
                if (!string.IsNullOrEmpty(typeText))
                {
                    exp = exp.And(x => x.ItemName.Contains(typeText));
                }

                if (!string.IsNullOrEmpty(typeMain))
                {
                    exp = exp.And(x => x.TypeGuid.Equals(typeMain));
                }
            
                IQueryable<T_Dic_TypeItem> _iqueryResult = app.Repository.Find(pageNo, pageSize, "", exp);
                List<T_Dic_TypeItem> listResult = _iqueryResult.ToList();
                listResult.ForEach(x=> {
                    T_Dic_TypeMain item = list.FirstOrDefault(e=>e.RowGuid.Equals(x.TypeGuid));
                    x.TypeGuid = item.Type;
                });
                int _totalCount = app.Repository.GetCount(exp);
                result.code = 0;  //Layui默认的返回成功code为0；
                result.data = listResult;
                result.count = _totalCount;


            }
            catch (Exception ex)
            {
                result.code = 500;
                result.msg = "请求小类数据发生错误!";
                //写到日志里面
                LogHelper.Log(ex.Message);
            }

            return JsonHelper.Instance.SerializeByConverter(result);
        }

        public ActionResult Add()
        {

            List<T_Dic_TypeMain> list = appMain.Repository.Find(x => x.ID > 0).ToList();
            ViewBag.TypeMain = list;
            return View();
        }


        [HttpPost]
        public string Add(string obj)
        {
            var result = new Response();
            try
            {
                T_Dic_TypeItem model = JsonHelper.Instance.Deserialize<T_Dic_TypeItem>(obj);
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

            List<T_Dic_TypeMain> list = appMain.Repository.Find(x => x.ID > 0).ToList();
            ViewBag.TypeMain = list;
            T_Dic_TypeItem main = app.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));
            return View(main);
        }


        [HttpPost]
        public string DeleteItemType(string rowGuid)
        {
            var result = new Response();
            try
            {
                T_Dic_TypeItem _typeMain = app.Repository.FindSingle(x => x.RowGuid.Equals(rowGuid));
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



        [HttpPost]
        public string EditData(string obj)
        {
            var result = new Response();
            try
            {
                T_Dic_TypeItem model = JsonHelper.Instance.Deserialize<T_Dic_TypeItem>(obj);
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