using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    public class T_Company_Info:BaseEntity
    {
        public T_Company_Info()
        {
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        private System.String _CompanyName;
        public System.String CompanyName { get { return this._CompanyName; } set { this._CompanyName = value; } }

        private System.String _OrgCode;
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public System.String OrgCode { get { return this._OrgCode; } set { this._OrgCode = value; } }

        private System.String _CompanyShortName;
        /// <summary>
        /// 公司简称
        /// </summary>
        public System.String CompanyShortName { get { return this._CompanyShortName; } set { this._CompanyShortName = value; } }

        private System.String _LinkName;
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public System.String LinkName { get { return this._LinkName; } set { this._LinkName = value; } }

        private System.String _LinkTel;
        /// <summary>
        /// 联系人电话
        /// </summary>
        public System.String LinkTel { get { return this._LinkTel; } set { this._LinkTel = value; } }

        private System.Int32? _TotalScore;
        /// <summary>
        /// 该企业总的积分
        /// </summary>
        public System.Int32? TotalScore { get { return this._TotalScore; } set { this._TotalScore = value; } }
    
    }
}
