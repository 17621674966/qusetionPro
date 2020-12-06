using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Domain
{
   public  class T_QsSuggest : Entity
    {

        public string Suggest { get; set; }
        public string MiaoShu { get; set; }
        public string MainId { get; set; }
        public string TemplateType { get; set; }
        public string ComapnyName { get; set; }
        public string DanZhaoName { get; set; }
        public string Address { get; set; }
        public string BusinessPro { get; set; }
        public string LegalName { get; set; }


        public string SecutyName { get; set; }
        public string LinkTel { get; set; }
        public string BelongArea { get; set; }
        public string CompanyType { get; set; }
        public string AddUserName { get; set; }
        public string AddUserGuid { get; set; }
        public DateTime? AddTime { get; set; }
        public string TiaoKuan { get; set; }
        public string ZhiBiao { get; set; }

        public string KouFen { get; set; }
        public string Note { get; set; }
        public string ImgList { get; set; }
        public int SortNumber { get; set; }
    }
}
