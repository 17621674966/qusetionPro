using Infrastructure;
using OpenAuth.App;
using OpenAuth.App.Response;
using OpenAuth.Repository.Domain.DonvvOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenAuth.Mvc.Controllers
{
    public class UserHomeController : Controller
    {

        public T_User_InfoApp app { get; set; }

        public T_Company_InfoApp Companyapp { get; set; }

        public T_Information_InfoApp informationapp { get; set; }


        public T_Needs_InfoApp needsapp { get; set; }

        // GET: UserHome
        public ActionResult Index()
        {
            return View();
        }

        public string GetHomeCount()
        {

            var result = new TableData();
            List<HomeMessage> list = new List<HomeMessage>()
            {
                new HomeMessage()
                {
                    informationCount = informationapp.Repository.GetCount(),
                    companyCount = (from a in Companyapp.UnitWork.Find<T_Company_Info>(x => x.ID > 0)
                                    select a.CompanyName).Distinct().Count(),
                    userCount = app.Repository.GetCount(),
                    needsCount = needsapp.Repository.GetCount(x=>x.Type==1),
                    needsCount1 = needsapp.Repository.GetCount(x=>x.Type==2),
                }
            };
            result.code = 200;
            result.data = list;
            result.count = list.Count;
            return JsonHelper.Instance.Serialize(result);




        }

        public class HomeMessage
        {  

            /// <summary>
            /// 资讯总数
            /// </summary>
           public int informationCount { get; set; }

            /// <summary>
            /// 公司总数
            /// </summary>
           public int companyCount { get; set; }

            /// <summary>
            /// 用户总数
            /// </summary>
           public int userCount { get; set; }

            /// <summary>
            /// 需求数目
            /// </summary>
           public int needsCount { get; set; }

            /// <summary>
            /// 供给数目
            /// </summary>
           public int needsCount1 { get; set; }
          
        }
    }
}