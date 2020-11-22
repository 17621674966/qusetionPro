using Infrastructure;
using Newtonsoft.Json;
using OpenAuth.App;
using OpenAuth.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace OpenAuth.Mvc.Controllers
{
    public class QsMainLogController : Controller
    {
        // GET: QsMainLog

        public T_QsMainLogApp App { get; set; }
        public T_QsDetailLog1App AppDetail { get; set; }

        public T_QsDetailLog2App AppDetail2 { get; set; }

        public T_QsDetailLog3App AppDetail3 { get; set; }


        public T_QsDetailLog4App AppDetail4 { get; set; }

        public LoginApp AppLog { get; set; }

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 添加问卷主表信息1
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult AddMessage(string mainLog, string detailLog, string userId)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog1>(detailLog);

            var user = AppLog.Repository.FindSingle(x => x.Id.Equals(userId));
            if (user == null)
            {
                Response Result = new Response();  //未授权
                Result.Code = 401;
                Result.Message = "请先登录！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                    main.Id = Guid.NewGuid().ToString();
                    main.AddUserName = user.Name;
                    main.AddUserGuid = user.Id;
                    main.AddTime = DateTime.Now;
                    main.UpdateTime = DateTime.Now;
                    main.RowStatus = 1;

                    App.Repository.Add(main);


                    //从表
                    detail.MainId = main.Id;
                    detail.Id = Guid.NewGuid().ToString();
                    detail.AddTime = DateTime.Now;
                    detail.AddUserName = user.Name;
                    detail.AddUserGuid = user.Id;
                    detail.UpdateTime = DateTime.Now;
                    detail.RowStatus = 1;

                    AppDetail.Repository.Add(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();  
                    Result.Code = 500;
                    Result.Message = "添加失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "添加成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }




        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult AddMessage2(string mainLog, string detailLog, string userId)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog2>(detailLog);

            var user = AppLog.Repository.FindSingle(x => x.Id.Equals(userId));
            if (user == null)
            {
                Response Result = new Response();  //未授权
                Result.Code = 401;
                Result.Message = "请先登录！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                    main.Id = Guid.NewGuid().ToString();
                    main.AddUserName = user.Name;
                    main.AddUserGuid = user.Id;
                    main.AddTime = DateTime.Now;
                    main.UpdateTime = DateTime.Now;
                    main.RowStatus = 1;

                    App.Repository.Add(main);


                    //从表
                    detail.MainId = main.Id;
                    detail.Id = Guid.NewGuid().ToString();
                    detail.AddTime = DateTime.Now;
                    detail.AddUserName = user.Name;
                    detail.AddUserGuid = user.Id;
                    detail.UpdateTime = DateTime.Now;
                    detail.RowStatus = 1;

                    AppDetail2.Repository.Add(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "添加失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "添加成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }




        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult AddMessage3(string mainLog, string detailLog, string userId)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog3>(detailLog);

            var user = AppLog.Repository.FindSingle(x => x.Id.Equals(userId));
            if (user == null)
            {
                Response Result = new Response();  //未授权
                Result.Code = 401;
                Result.Message = "请先登录！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                    main.Id = Guid.NewGuid().ToString();
                    main.AddUserName = user.Name;
                    main.AddUserGuid = user.Id;
                    main.AddTime = DateTime.Now;
                    main.UpdateTime = DateTime.Now;
                    main.RowStatus = 1;

                    App.Repository.Add(main);


                    //从表
                    detail.MainId = main.Id;
                    detail.Id = Guid.NewGuid().ToString();
                    detail.AddTime = DateTime.Now;
                    detail.AddUserName = user.Name;
                    detail.AddUserGuid = user.Id;
                    detail.UpdateTime = DateTime.Now;
                    detail.RowStatus = 1;

                    AppDetail3.Repository.Add(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "添加失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "添加成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }



        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult AddMessage4(string mainLog, string detailLog, string userId)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog4>(detailLog);

            var user = AppLog.Repository.FindSingle(x => x.Id.Equals(userId));
            if (user == null)
            {
                Response Result = new Response();  //未授权
                Result.Code = 401;
                Result.Message = "请先登录！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                    main.Id = Guid.NewGuid().ToString();
                    main.AddUserName = user.Name;
                    main.AddUserGuid = user.Id;
                    main.AddTime = DateTime.Now;
                    main.UpdateTime = DateTime.Now;
                    main.RowStatus = 1;

                    App.Repository.Add(main);


                    //从表
                    detail.MainId = main.Id;
                    detail.Id = Guid.NewGuid().ToString();
                    detail.AddTime = DateTime.Now;
                    detail.AddUserName = user.Name;
                    detail.AddUserGuid = user.Id;
                    detail.UpdateTime = DateTime.Now;
                    detail.RowStatus = 1;

                    AppDetail4.Repository.Add(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "添加失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "添加成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }

        /// <summary>
        /// 我的调查历史
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult GetMainLog(string userId)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var list = App.Repository.Find(x => x.AddUserGuid.Equals(userId)).OrderByDescending(x=>x.AddTime).ToList();
            list.ForEach(x =>
            {
                x.AddTimeStr = x.AddTime.Value.ToString("yyyy-MM-dd  HH:mm:ss");
            });
             Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }
    }
}