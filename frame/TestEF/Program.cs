using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<UserInfo> list = new List<UserInfo>()
            //{
            //   new UserInfo(){  userName="徐义招", userAccount="xyz",ID=0},
            //   new UserInfo(){  userName="徐义招1", userAccount="xyz1",ID=1},
            //   new UserInfo(){  userName="徐义招2", userAccount="xyz2",ID=2},
            //   new UserInfo(){  userName="徐义招3", userAccount="xyz3",ID=3}
            //};

            //var search = from userinfo in list
            //             select userinfo;

            //var expression = PredicateBuilder.True<UserInfo>();
            //expression.And(x=>x.userName.Equals("徐义招"));
            //expression.Or(x=>x.userAccount.Equals("xyz")&& x.userName.Equals("")||x.ID==0);
            //expression.And(x=>x.ID>=2);
            //var result = search.AsQueryable<UserInfo>().Where(expression);
            //ObjectQuery<UserInfo> parents = result as ObjectQuery<UserInfo>;

            //if (parents != null)
            //{
            //    string sql = parents.ToTraceString();
            //    Console.WriteLine(sql);
            //}


        }



        private class UserInfo {
            public string userName { get; set; }
            public string userAccount { get; set; }
            public  int ID  { get; set; }

        }
    }
}
