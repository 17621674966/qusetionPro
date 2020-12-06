using Infrastructure;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using OpenAuth.App;
using OpenAuth.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using WebGrease;

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

        public T_QsDetailLog5App AppDetail5 { get; set; }

        public T_QsDetailLog6App AppDetail6 { get; set; }

        public LoginApp AppLog { get; set; }

        public QsSuggestApp QsSuggestApp { get; set; }

        public ActionResult Index()
        {
            return View();
        }



        #region   添加问卷信息
        /// <summary>
        /// 添加问卷主表信息1
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult AddMessage(string mainLog, string detailLog, string userId, string qsSuggest)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog1>(detailLog);

            //描述项
            var suggest = new List<T_QsSuggest>();
            if (!string.IsNullOrEmpty(qsSuggest))
            {
                suggest = JsonConvert.DeserializeObject<List<T_QsSuggest>>(qsSuggest);
            }
            else {
                suggest.Add(new T_QsSuggest() { AddTime=DateTime.Now});
            }

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

                   
                    //描述
                    foreach (var item in suggest)
                    {
                        item.MainId = main.Id;
                        item.Id = Guid.NewGuid().ToString();
                        item.AddTime = DateTime.Now;
                        item.AddUserName = user.Name;
                        item.AddUserGuid = user.Id;
                        item.TemplateType = main.TemplateType;
                        item.ComapnyName = main.ComapnyName;
                        item.DanZhaoName = main.DanZhaoName;
                        item.Address = main.Address;
                        item.BusinessPro = main.BusinessPro;
                        item.LegalName = main.LegalName;
                        item.SecutyName = main.SecutyName;
                        item.LinkTel = main.LinkTel;
                        item.BelongArea = main.BelongArea;
                        item.CompanyType = main.CompanyType;

                    }
                   
                     QsSuggestApp.Repository.BatchAdd(suggest.ToArray());
                    

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
        public JsonResult AddMessage2(string mainLog, string detailLog, string userId, string qsSuggest)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog2>(detailLog);
            //描述项
            var suggest = new List<T_QsSuggest>();
            if (!string.IsNullOrEmpty(qsSuggest))
            {
                suggest = JsonConvert.DeserializeObject<List<T_QsSuggest>>(qsSuggest);
            }
            else
            {
                suggest.Add(new T_QsSuggest() { AddTime = DateTime.Now });
            }

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


                    //描述
                    foreach (var item in suggest)
                    {
                        item.MainId = main.Id;
                        item.Id = Guid.NewGuid().ToString();
                        item.AddTime = DateTime.Now;
                        item.AddUserName = user.Name;
                        item.AddUserGuid = user.Id;
                        item.TemplateType = main.TemplateType;
                        item.ComapnyName = main.ComapnyName;
                        item.DanZhaoName = main.DanZhaoName;
                        item.Address = main.Address;
                        item.BusinessPro = main.BusinessPro;
                        item.LegalName = main.LegalName;
                        item.SecutyName = main.SecutyName;
                        item.LinkTel = main.LinkTel;
                        item.BelongArea = main.BelongArea;
                        item.CompanyType = main.CompanyType;

                    }

                    QsSuggestApp.Repository.BatchAdd(suggest.ToArray());


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
        public JsonResult AddMessage3(string mainLog, string detailLog, string userId, string qsSuggest)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog3>(detailLog);
            //描述项
            var suggest = new List<T_QsSuggest>();
            if (!string.IsNullOrEmpty(qsSuggest))
            {
                suggest = JsonConvert.DeserializeObject<List<T_QsSuggest>>(qsSuggest);
            }
            else
            {
                suggest.Add(new T_QsSuggest() { AddTime = DateTime.Now });
            }

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


                    //描述
                    foreach (var item in suggest)
                    {
                        item.MainId = main.Id;
                        item.Id = Guid.NewGuid().ToString();
                        item.AddTime = DateTime.Now;
                        item.AddUserName = user.Name;
                        item.AddUserGuid = user.Id;
                        item.TemplateType = main.TemplateType;
                        item.ComapnyName = main.ComapnyName;
                        item.DanZhaoName = main.DanZhaoName;
                        item.Address = main.Address;
                        item.BusinessPro = main.BusinessPro;
                        item.LegalName = main.LegalName;
                        item.SecutyName = main.SecutyName;
                        item.LinkTel = main.LinkTel;
                        item.BelongArea = main.BelongArea;
                        item.CompanyType = main.CompanyType;

                    }

                    QsSuggestApp.Repository.BatchAdd(suggest.ToArray());


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
        public JsonResult AddMessage4(string mainLog, string detailLog, string userId, string qsSuggest)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog4>(detailLog);
            //描述项
            var suggest = new List<T_QsSuggest>();
            if (!string.IsNullOrEmpty(qsSuggest))
            {
                suggest = JsonConvert.DeserializeObject<List<T_QsSuggest>>(qsSuggest);
            }
            else
            {
                suggest.Add(new T_QsSuggest() { AddTime = DateTime.Now });
            }

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


                    //描述
                    foreach (var item in suggest)
                    {
                        item.MainId = main.Id;
                        item.Id = Guid.NewGuid().ToString();
                        item.AddTime = DateTime.Now;
                        item.AddUserName = user.Name;
                        item.AddUserGuid = user.Id;
                        item.TemplateType = main.TemplateType;
                        item.ComapnyName = main.ComapnyName;
                        item.DanZhaoName = main.DanZhaoName;
                        item.Address = main.Address;
                        item.BusinessPro = main.BusinessPro;
                        item.LegalName = main.LegalName;
                        item.SecutyName = main.SecutyName;
                        item.LinkTel = main.LinkTel;
                        item.BelongArea = main.BelongArea;
                        item.CompanyType = main.CompanyType;

                    }

                    QsSuggestApp.Repository.BatchAdd(suggest.ToArray());


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
        public JsonResult AddMessage5(string mainLog, string detailLog, string userId, string qsSuggest)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog5>(detailLog);
            //描述项
            var suggest = new List<T_QsSuggest>();
            if (!string.IsNullOrEmpty(qsSuggest))
            {
                suggest = JsonConvert.DeserializeObject<List<T_QsSuggest>>(qsSuggest);
            }
            else
            {
                suggest.Add(new T_QsSuggest() { AddTime = DateTime.Now });
            }

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

                    AppDetail5.Repository.Add(detail);



                    //描述
                    foreach (var item in suggest)
                    {
                        item.MainId = main.Id;
                        item.Id = Guid.NewGuid().ToString();
                        item.AddTime = DateTime.Now;
                        item.AddUserName = user.Name;
                        item.AddUserGuid = user.Id;
                        item.TemplateType = main.TemplateType;
                        item.ComapnyName = main.ComapnyName;
                        item.DanZhaoName = main.DanZhaoName;
                        item.Address = main.Address;
                        item.BusinessPro = main.BusinessPro;
                        item.LegalName = main.LegalName;
                        item.SecutyName = main.SecutyName;
                        item.LinkTel = main.LinkTel;
                        item.BelongArea = main.BelongArea;
                        item.CompanyType = main.CompanyType;

                    }

                    QsSuggestApp.Repository.BatchAdd(suggest.ToArray());

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
        public JsonResult AddMessage6(string mainLog, string detailLog, string userId, string qsSuggest)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog6>(detailLog);
            //描述项
            var suggest = new List<T_QsSuggest>();
            if (!string.IsNullOrEmpty(qsSuggest))
            {
                suggest = JsonConvert.DeserializeObject<List<T_QsSuggest>>(qsSuggest);
            }
            else
            {
                suggest.Add(new T_QsSuggest() { AddTime = DateTime.Now });
            }

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

                    AppDetail6.Repository.Add(detail);

                    //描述
                    foreach (var item in suggest)
                    {
                        item.MainId = main.Id;
                        item.Id = Guid.NewGuid().ToString();
                        item.AddTime = DateTime.Now;
                        item.AddUserName = user.Name;
                        item.AddUserGuid = user.Id;
                        item.TemplateType = main.TemplateType;
                        item.ComapnyName = main.ComapnyName;
                        item.DanZhaoName = main.DanZhaoName;
                        item.Address = main.Address;
                        item.BusinessPro = main.BusinessPro;
                        item.LegalName = main.LegalName;
                        item.SecutyName = main.SecutyName;
                        item.LinkTel = main.LinkTel;
                        item.BelongArea = main.BelongArea;
                        item.CompanyType = main.CompanyType;

                    }

                    QsSuggestApp.Repository.BatchAdd(suggest.ToArray());

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

        #endregion


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


        #region   修改问卷信息
        /// <summary>
        /// 添加问卷主表信息1
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult EditMessage(string mainLog, string detailLog, string userId)
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


            var detailMessage = App.Repository.FindSingle(x=>x.Id.Equals(main.Id) );

            if (detailMessage!=null)
            {
                main.BelongArea = detailMessage.BelongArea;
                main.AddUserGuid = detailMessage.AddUserGuid;
                main.AddUserName = detailMessage.AddUserName;
                main.AddTime = detailMessage.AddTime;
                detail.MainId = main.Id;
                detail.AddTime = detailMessage.AddTime;
                detail.AddUserGuid = detailMessage.AddUserGuid;
                detail.AddUserName = detailMessage.AddUserName;
            }
            using (var train = new TransactionScope())
            {


                try
                {
                   
                   
                    main.UpdateTime = DateTime.Now;
                    main.RowStatus = 1;
                    

                    App.Repository.Update(main);


                    //从表
                  
                  
                    detail.UpdateTime = DateTime.Now;
                  

                    AppDetail.Repository.Update(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "修改失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "修改成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }




        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult EditMessage2(string mainLog, string detailLog, string userId)
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

            var detailMessage = App.Repository.FindSingle(x => x.Id.Equals(main.Id));

            if (detailMessage != null)
            {
                main.BelongArea = detailMessage.BelongArea;
                main.AddUserGuid = detailMessage.AddUserGuid;
                main.AddUserName = detailMessage.AddUserName;
                main.AddTime = detailMessage.AddTime;
                detail.MainId = main.Id;
                detail.AddTime = detailMessage.AddTime;
                detail.AddUserGuid = detailMessage.AddUserGuid;
                detail.AddUserName = detailMessage.AddUserName;
            }

            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                   
                    main.UpdateTime = DateTime.Now;
                  

                    App.Repository.Update(main);


                    //从表
                  
                    detail.UpdateTime = DateTime.Now;
                  

                    AppDetail2.Repository.Update(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "修改失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "修改成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }




        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult EditMessage3(string mainLog, string detailLog, string userId)
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

            var detailMessage = App.Repository.FindSingle(x => x.Id.Equals(main.Id));

            if (detailMessage != null)
            {
                main.BelongArea = detailMessage.BelongArea;
                main.AddUserGuid = detailMessage.AddUserGuid;
                main.AddUserName = detailMessage.AddUserName;
                main.AddTime = detailMessage.AddTime;
                detail.MainId = main.Id;
                detail.AddTime= detailMessage.AddTime;
                detail.AddUserGuid= detailMessage.AddUserGuid;
                detail.AddUserName= detailMessage.AddUserName;
            }

            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                 
                   
                    main.UpdateTime = DateTime.Now;
                  

                    App.Repository.Update(main);


                    //从表
                  
                    detail.UpdateTime = DateTime.Now;
                  

                    AppDetail3.Repository.Update(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "修改失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "修改成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }



        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult EditMessage4(string mainLog, string detailLog, string userId)
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


            var detailMessage = App.Repository.FindSingle(x => x.Id.Equals(main.Id));

            if (detailMessage != null)
            {
                main.BelongArea = detailMessage.BelongArea;
                main.AddUserGuid = detailMessage.AddUserGuid;
                main.AddUserName = detailMessage.AddUserName;
                main.AddTime = detailMessage.AddTime;
                detail.MainId = main.Id;
                detail.AddTime = detailMessage.AddTime;
                detail.AddUserGuid = detailMessage.AddUserGuid;
                detail.AddUserName = detailMessage.AddUserName;
            }
            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                   
                    main.UpdateTime = DateTime.Now;
                  

                    App.Repository.Update(main);


                    //从表
                  
                    detail.UpdateTime = DateTime.Now;
                    detail.RowStatus = 1;

                    AppDetail4.Repository.Update(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "修改失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "修改成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }



        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult EditMessage5(string mainLog, string detailLog, string userId)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog5>(detailLog);

            var user = AppLog.Repository.FindSingle(x => x.Id.Equals(userId));
            if (user == null)
            {
                Response Result = new Response();  //未授权
                Result.Code = 401;
                Result.Message = "请先登录！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }


            var detailMessage = App.Repository.FindSingle(x => x.Id.Equals(main.Id));

            if (detailMessage != null)
            {
                main.BelongArea = detailMessage.BelongArea;
                main.AddUserGuid = detailMessage.AddUserGuid;
                main.AddUserName = detailMessage.AddUserName;
                main.AddTime = detailMessage.AddTime;
                detail.MainId = main.Id;
                detail.AddTime = detailMessage.AddTime;
                detail.AddUserGuid = detailMessage.AddUserGuid;
                detail.AddUserName = detailMessage.AddUserName;
            }
            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                  
                    main.UpdateTime = DateTime.Now;
                    main.RowStatus = 1;

                    App.Repository.Update(main);


                    //从表
                   
                    detail.UpdateTime = DateTime.Now;
                    detail.RowStatus = 1;

                    AppDetail5.Repository.Update(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "修改失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "修改成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }



        /// <summary>
        /// 添加问卷主表信息
        /// </summary>
        /// <param name="mainLog"></param>
        /// <returns></returns>
        public JsonResult EditMessage6(string mainLog, string detailLog, string userId)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var main = JsonConvert.DeserializeObject<T_QsMainLog>(mainLog);
            var detail = JsonConvert.DeserializeObject<T_QsDetailLog6>(detailLog);

            var user = AppLog.Repository.FindSingle(x => x.Id.Equals(userId));
            if (user == null)
            {
                Response Result = new Response();  //未授权
                Result.Code = 401;
                Result.Message = "请先登录！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            var detailMessage = App.Repository.FindSingle(x => x.Id.Equals(main.Id));

            if (detailMessage != null)
            {
                main.BelongArea = detailMessage.BelongArea;
                main.AddUserGuid = detailMessage.AddUserGuid;
                main.AddUserName = detailMessage.AddUserName;
                main.AddTime = detailMessage.AddTime;
                detail.MainId = main.Id;
                detail.AddTime = detailMessage.AddTime;
                detail.AddUserGuid = detailMessage.AddUserGuid;
                detail.AddUserName = detailMessage.AddUserName;
            }
            using (var train = new TransactionScope())
            {


                try
                {
                    //主表
                   
                    main.UpdateTime = DateTime.Now;
                    main.RowStatus = 1;

                    App.Repository.Update(main);


                    //从表
                    
                    detail.UpdateTime = DateTime.Now;
                    detail.RowStatus = 1;

                    AppDetail6.Repository.Update(detail);


                    train.Complete();

                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex.Message);
                    Response Result = new Response();
                    Result.Code = 500;
                    Result.Message = "修改失败！";
                    return Json(Result, JsonRequestBehavior.DenyGet);
                }


                Response ResultEnd = new Response();
                ResultEnd.Code = 200;
                ResultEnd.Message = "修改成功！";
                return Json(ResultEnd, JsonRequestBehavior.DenyGet);


            }


        }


        #endregion



        #region   获取主表明细信息

        public JsonResult GetMainDetail(string guid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var list = App.Repository.Find(x => x.Id.Equals(guid)).OrderByDescending(x => x.AddTime).ToList();
            list.ForEach(x =>
            {
                x.AddTimeStr = x.AddTime.Value.ToString("yyyy-MM-dd");

                if (x.CheckTime.HasValue)
                {
                    x.CheckTimeStr = x?.CheckTime.Value.ToString("yyyy-MM-dd") ?? "";
                }
             
                if (x.BuildTime.HasValue)
                {
                    x.BuildTimeStr = x.BuildTime.Value.ToString("yyyy-MM-dd") ?? "";
                }
               
            });

            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }

        #endregion



        #region   获取明细信息

        public JsonResult GetDetail1(string mainGuid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var list = AppDetail.Repository.Find(x => x.MainId.Equals(mainGuid)).OrderByDescending(x => x.AddTime).ToList();
           

            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }


        public JsonResult GetDetail2(string mainGuid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var list = AppDetail2.Repository.Find(x => x.MainId.Equals(mainGuid)).OrderByDescending(x => x.AddTime).ToList();


            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }


        public JsonResult GetDetail3(string mainGuid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var list = AppDetail3.Repository.Find(x => x.MainId.Equals(mainGuid)).OrderByDescending(x => x.AddTime).ToList();


            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }



        public JsonResult GetDetail4(string mainGuid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var list = AppDetail4.Repository.Find(x => x.MainId.Equals(mainGuid)).OrderByDescending(x => x.AddTime).ToList();


            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }


        public JsonResult GetDetail5(string mainGuid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var list = AppDetail5.Repository.Find(x => x.MainId.Equals(mainGuid)).OrderByDescending(x => x.AddTime).ToList();


            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }


        public JsonResult GetDetail6(string mainGuid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            var list = AppDetail6.Repository.Find(x => x.MainId.Equals(mainGuid)).OrderByDescending(x => x.AddTime).ToList();


            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "查询成功！";
            Result.Obj = list;
            Result.count = list.Count;
            return Json(Result, JsonRequestBehavior.DenyGet);
        }





        #endregion



        #region  改进问题清单
        /// <summary>
        /// 生成问题清单
        /// </summary>
        /// <param name="mainGuid"></param>
        /// <returns></returns>
        public JsonResult DownLoad(string mainGuid)
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");



            try
            { 


            //获取excel需要的数据
            var mian = App.Repository.FindSingle(x => x.Id == mainGuid);
            var suggest = QsSuggestApp.Repository.Find(x => x.MainId == mainGuid).OrderBy(x => x.SortNumber).ToList();

            var templateFileName = Server.MapPath("~/Template/改进建议.xlsx");
            IWorkbook workbook = null;  //新建IWorkbook对象  
            FileStream fileStream = new FileStream(templateFileName, FileMode.Open, FileAccess.Read);
            if (templateFileName.IndexOf(".xlsx") > 0) // 2007版本  
            {
                workbook = new XSSFWorkbook(fileStream);  //xlsx数据读入workbook  
            }
            else if (templateFileName.IndexOf(".xls") > 0) // 2003版本  
            {
                workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook  
            }

                #region  边框
                //公共样式：加边框
                NPOI.SS.UserModel.ICellStyle style = workbook.CreateCellStyle();
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                style.Alignment = HorizontalAlignment.Center;
                #endregion

                ISheet sheet = null;
            sheet = workbook.GetSheet("改进建议");


            #region  第一行
            IRow row = sheet.GetRow(1); //获取第一行

            //单位名称
            row.GetCell(2).SetCellValue(mian?.ComapnyName ?? "");

            //评估时间
            row.GetCell(4).SetCellValue(mian?.CheckTime?.ToString("yyyy-MM-dd") ?? "");

            #endregion


            #region  第二行
            IRow row2 = sheet.GetRow(2); //获取第二行

            //单位地址
            row2.GetCell(2).SetCellValue(mian?.Address ?? "");

            //店    招
            row2.GetCell(2).SetCellValue(mian?.DanZhaoName ?? "");

            #endregion


            #region  第三行

            IRow row3 = sheet.GetRow(3); //获取第三行

            //所属区、所属商圈
            row3.GetCell(2).SetCellValue(mian?.BelongArea ?? "");

            //经营项目      
            row3.GetCell(2).SetCellValue(mian?.BusinessPro ?? "");


            #endregion



            #region  第四行

            IRow row4 = sheet.GetRow(4); //获取第四行

            //类    型
            row4.GetCell(2).SetCellValue(mian?.CompanyType ?? "");

            //不适用分数      
            row4.GetCell(2).SetCellValue(mian?.NotCount.ToString() ?? "");


            #endregion


            #region  第五行

            IRow row5 = sheet.GetRow(4); //获取第五行

            //得分率
            var mayCount = mian?.MyCount ?? 0;
            var totalCount = mian?.TotalCount ?? 0;
            var notCount = mian?.NotCount ?? 0;

            var percent = 0.00M;
            if (totalCount == 0)
            {

            }
            else {
                percent = (decimal.Round(mayCount / (totalCount - notCount) * 100, 4) * 100);
            }
            row5.GetCell(2).SetCellValue(percent.ToString());

            //结     论      

            if (percent >= 0.85M)
            {
                row5.GetCell(2).SetCellValue("推荐");
            }
            else {
                row5.GetCell(2).SetCellValue("不推荐");
            }



            #endregion



            #region  第六行

            IRow row6 = sheet.GetRow(6); //获取第六行

            //评估小组
            row6.GetCell(2).SetCellValue(mian?.AddUserName ?? "");

            //整改时间    
            row6.GetCell(2).SetCellValue("一周");


            #endregion



            if (suggest.Any())
            {
                for (int i = 0; i < suggest.Count; i++)
                {
                    //首先创建行
                    IRow rownew = sheet.CreateRow(8 + i);

                    //然后创建列
                    for (int j = 0; j < 5; j++) {
                        ICell cell = rownew.CreateCell(j);
                            cell.CellStyle = style;
                    }

                    //序号
                    rownew.GetCell(0).SetCellValue(suggest[i].SortNumber);

                    //条款号
                    rownew.GetCell(1).SetCellValue(suggest[i].TiaoKuan + $"({suggest[i].ZhiBiao})");


                    //改进问题描述

                    ICellStyle notesStyle = workbook.CreateCellStyle();
                    notesStyle.WrapText = true;//设置换行这个要先设置

                    rownew.GetCell(2).SetCellValue(suggest[i].MiaoShu + "\n");
                    rownew.GetCell(2).CellStyle = notesStyle;//设置换行


                    //合并单元格
                    rownew.GetCell(3).SetCellValue(suggest[i].Suggest + "\n");
                    CellRangeAddress region = new CellRangeAddress(8 + i, 8 + i, 3, 4);
                    sheet.AddMergedRegion(region);

                }
            }



            #region  最后的备注
            IRow rownNote = sheet.CreateRow(8 + suggest.Count);
                rownNote.Height = 1000;

            //然后创建列
                for (int j = 0; j < 5; j++)
            {
                ICell cell = rownNote.CreateCell(j);
                    cell.CellStyle = style;
                    
                }


            CellRangeAddress regionNote = new CellRangeAddress(8 + suggest.Count, 8 + suggest.Count, 0, 1);
            sheet.AddMergedRegion(regionNote);
            rownNote.GetCell(0).SetCellValue("备注");


            CellRangeAddress regionNote1 = new CellRangeAddress(8 + suggest.Count, 8 + suggest.Count, 2, 4);
            sheet.AddMergedRegion(regionNote1);

            #endregion



            #region  签字
            IRow rownNote22 = sheet.CreateRow(10 + suggest.Count);

            //然后创建列
            for (int j = 0; j < 5; j++)
            {
                ICell cell = rownNote22.CreateCell(j);
                    cell.CellStyle = style;
                }


            CellRangeAddress regionNote22 = new CellRangeAddress(10 + suggest.Count, 10 + suggest.Count, 0, 1);
            sheet.AddMergedRegion(regionNote22);
            rownNote22.GetCell(0).SetCellValue("评估组签字");


            rownNote22.GetCell(2).SetCellValue("");


            rownNote22.GetCell(3).SetCellValue("时间");

            rownNote22.GetCell(4).SetCellValue("");


            #endregion


            #region  签字
            IRow rownNote33 = sheet.CreateRow(11 + suggest.Count);

            //然后创建列
            for (int j = 0; j < 5; j++)
            {
                ICell cell = rownNote33.CreateCell(j);
                    cell.CellStyle = style;
                }


            CellRangeAddress regionNote33 = new CellRangeAddress(11 + suggest.Count, 11 + suggest.Count, 0, 1);
            sheet.AddMergedRegion(regionNote33);
            rownNote33.GetCell(0).SetCellValue("受评估方签字盖章");


            rownNote33.GetCell(2).SetCellValue("");


            rownNote33.GetCell(3).SetCellValue("时间");

            rownNote33.GetCell(4).SetCellValue("");


                #endregion




                XSSFWorkbook workbookNew = (XSSFWorkbook)workbook;
            string fileNameNew = DateTime.Now.ToString("yyyyMMddHHmmss");
            FileStream fileNew = new FileStream(Server.MapPath("~/Template/") + fileNameNew + ".xlsx", FileMode.Create);
            workbookNew.Write(fileNew);
            fileNew.Close();  //关闭文件流  
            workbookNew.Close();
            workbook.Close();


            return Json(new { success = true, path =ConfigurationManager.AppSettings["WebDomain"] +"/Template/" + fileNameNew + ".xlsx" });

        }

            catch (Exception ex)
            {

                LogHelper.Log(ex.Message.ToString());
                return Json(new { success = false, path = "" });
            }
        }


        #endregion



        #region  查看所有的调查
       /// <summary>
       /// 查看所有调查
       /// </summary>
       /// <param name="type"></param>
       /// <param name="companyName"></param>
       /// <param name="dianZhaoName"></param>
       /// <param name="addUserName"></param>
       /// <param name="belongQu"></param>
       /// <param name="addTimeBegin"></param>
       /// <param name="addTimeEnd"></param>
       /// <returns></returns>
        public JsonResult GetAll(string type,string companyName,string dianZhaoName,
            string addUserName,string belongQu
            ,string addTimeBegin,string  addTimeEnd,string tuijian) {
            int pageNo = Convert.ToInt32(Request.Form["page"]);
            int pageSize = Convert.ToInt32(Request.Form["limit"]);

            try {

                var result = App.Repository.Find(x=>x.Id!=""); //查询所有数据

                //模板类型
                if (!string.IsNullOrEmpty(type))
                {
                    result = result.Where(x=>x.TemplateType.Equals(type));
                }

                //公司名称
                if (!string.IsNullOrEmpty(companyName))
                {
                    result = result.Where(x => x.ComapnyName.Contains(companyName));
                }

                //店招名
                if (!string.IsNullOrEmpty(dianZhaoName))
                {
                    result = result.Where(x=>x.DanZhaoName.Contains(dianZhaoName));
                }

                //添加人名称
                if (!string.IsNullOrEmpty(addUserName))
                {
                    result = result.Where(x => x.AddUserName.Equals(addUserName));
                }

                //区
                if (!string.IsNullOrEmpty(belongQu))
                {
                    result = result.Where(x => x.BelongArea.Contains(belongQu));
                }

                //开始时间
                if (!string.IsNullOrEmpty(addTimeBegin))
                {

                    var begin =Convert.ToDateTime( Convert.ToDateTime(addTimeBegin).ToString("yyyy-MM-dd 00:00:00"));
                    result = result.Where(x => x.AddTime >= begin);
                }

                
                //结束时间
                if (!string.IsNullOrEmpty(addTimeEnd))
                {

                    var end = Convert.ToDateTime(Convert.ToDateTime(addTimeEnd).ToString("yyyy-MM-dd 00:00:00"));
                    result = result.Where(x => x.AddTime <= end);
                }

                if (!string.IsNullOrEmpty(tuijian))
                {
                    if (tuijian == "推荐")
                    {
                        result = result.Where(x => x.PercentValue >= 0.85M); //推荐
                    }
                    else {
                        result = result.Where(x => x.PercentValue < 0.85M);  //不推荐
                    }
                  
                }

                result = result.Where(x=>x.AddUserName!="test");

                var totalCount = result.Count();

                var table = result.OrderByDescending(x => x.AddTime)
                   .Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

                // table  

                table.ForEach(x =>
                {
                    x.AddTimeStr = x.AddTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    

                    if (x.PercentValue >= 0.85M)
                    {
                        x.IsTuiJianStr = "推荐";
                    }

                    else
                    {
                        x.IsTuiJianStr = "不推荐";
                    }

                });
                return Json(new { code =0, msg ="查询成功", count = totalCount , data = table });



            }
            catch (Exception  ex)
            {
                LogHelper.Log(ex.Message.ToString());
                return Json(new { code = 500, msg = "查询失败", count = 0 });
               
            }
        }



        public ActionResult GetAllIndex() {
            return View();
        }

        #endregion



        #region    修改建议
        /// <summary>
        /// 查询所有修改建议
        /// </summary>
        public JsonResult GetSuggestList(string mainGuid)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var result = QsSuggestApp.Repository.Find(x => x.MainId.Equals(mainGuid)).ToList();
            return Json(new { success = true, data= result });

           
        }

        #endregion 


    }
}