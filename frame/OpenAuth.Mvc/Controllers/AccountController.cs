using Infrastructure;
using OpenAuth.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenAuth.Mvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        public LoginApp App { get; set; }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult CheckLogin(string userName,string password)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            if (string.IsNullOrWhiteSpace(userName)||string.IsNullOrWhiteSpace(password))
            {
                Response Result = new Response();
                Result.Code = 500;
                Result.Message = "用户名或密码不能为空！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            var user = App.Repository.
                FindSingle(x => x.Account.Equals(userName) && x.Password.Equals(password));

            if (user == null)
            {
                Response Result = new Response();
                Result.Code = 500;
                Result.Message = "用户名或密码不正确！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }
            else {
                Response Result = new Response();
                Result.Code = 200;
                Result.Message = "登录成功！";
                Result.Obj = new { Id= user .Id,Name= user.Name};
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newPass"></param>
        /// <param name="confirmPass"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult EditPassWord(string oldPass,string newPass, string confirmPass, string userId)
        {
            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                Response Result = new Response();
                Result.Code = 500;
                Result.Message = "新密码不能为空！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            if (newPass!= confirmPass)
            {
                Response Result = new Response();
                Result.Code = 500;
                Result.Message = "两次密码输入不一样！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }

            var user = App.Repository.
                FindSingle(x => x.Id.Equals(userId));

            if (user == null)
            {
                Response Result = new Response();
                Result.Code = 500;
                Result.Message = "用户不存在！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }
            else if (user.Password!=oldPass)
            {
                Response Result = new Response();
                Result.Code = 500;
                Result.Message = "原密码不正确！";
                return Json(Result, JsonRequestBehavior.DenyGet);
            }
            else 
            {
                user.Password = newPass;
                App.Repository.Update(user);
                Response Result = new Response();
                Result.Code = 200;
                Result.Message = "修改密码成功！";

                return Json(Result, JsonRequestBehavior.DenyGet);
            }

        }


    }
}