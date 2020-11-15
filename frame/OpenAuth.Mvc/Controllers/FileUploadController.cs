using Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenAuth.Mvc.Controllers
{  

    [AllowAnonymous]
    public class FileUploadController : Controller
    {

        private const string DirectoryPath = "~/upload/";
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 通用的上传的方法
        /// </summary>
        /// <returns></returns>
        public JsonResult UploadFile()
        {

            HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            var directoryPath = Server.MapPath(DirectoryPath);
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var filePathList = new List<string>();
            for (int i=0;i<this.HttpContext.Request.Files.Count;i++)
            {
                var fileName = Guid.NewGuid().ToString();
                var file = this.HttpContext.Request.Files[i];
                var fileType = FileHelper.GetFileType(file.FileName) ;
                var saveFileName = directoryPath + fileName+ fileType;
                filePathList.Add(DirectoryPath+ fileName + fileType);  //返回路径
                file.SaveAs(saveFileName)  ;    

            }

            Response Result = new Response();
            Result.Code = 200;
            Result.Message = "上传成功";
            Result.Obj = new {FilePath= string.Join(";", filePathList.ToArray()) };

            return Json(Result , JsonRequestBehavior.DenyGet);
        
        }


    }
}