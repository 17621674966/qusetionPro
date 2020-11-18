using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Domain
{   
    public  class T_QsMainLog:Entity
    {
        public string TemplateType { get; set; }
        public string ComapnyName { get; set; }
        public string DanZhaoName { get; set; }
        public string Address { get; set; }
        public string BusinessPro { get; set; }
        public string LegalName { get; set; }
        public string SecutyName { get; set; }
        public string LinkTel { get; set; }

        public DateTime? CheckTime { get; set; }

        public string BelongArea { get; set; }
        public string BelongTown { get; set; }
        public string Code { get; set; }
        public DateTime? BuildTime { get; set; }
        public string PeopleCount { get; set; }
        public string Area { get; set; }
        public string CompanyType { get; set; }
        public string AddUserName { get; set; }
        public string AddUserGuid { get; set; }

        public DateTime? AddTime { get; set; }

        public DateTime? UpdateTime { get; set; }


        public int? RowStatus { get; set; }
        public int? TotalCount { get; set; }
        public int? MyCount { get; set; }
        public int? NotCount { get; set; }
        public decimal? PercentValue { get; set; }
        public bool? IsTuiJian { get; set; }

        public string Note { get; set; }


        public string FouJue1 { get; set; }
        public string FouJue2 { get; set; }
        public string FouJue3 { get; set; }
        public string FouJue4 { get; set; }
        public string FouJue5 { get; set; }


        public string FouJueDesc1 { get; set; }
        public string FouJueDesc2 { get; set; }
        public string FouJueDesc3 { get; set; }
        public string FouJueDesc4 { get; set; }
        public string FouJueDesc5 { get; set; }

        [NotMapped]
        public string AddTimeStr { get; set; }
    }
}
