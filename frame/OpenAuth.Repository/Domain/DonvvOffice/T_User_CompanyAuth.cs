

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_User_CompanyAuth : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_User_CompanyAuth()
        {
        }

       

        private System.String _UserGuid;
        /// <summary>
        /// 用户标识
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

        private System.String _CardUrl;
        /// <summary>
        /// 工牌存储url
        /// </summary>
        public System.String CardUrl { get { return this._CardUrl; } set { this._CardUrl = value; } }

        private System.String _BusinessLicenseUrl;
        /// <summary>
        /// 营业执照url
        /// </summary>
        public System.String BusinessLicenseUrl { get { return this._BusinessLicenseUrl; } set { this._BusinessLicenseUrl = value; } }

        private System.Int32 _IsAuth;
        /// <summary>
        /// 是否企业认证（0，待认证 1认证通过2 认证不通过）
        /// </summary>
        public System.Int32 IsAuth { get { return this._IsAuth; } set { this._IsAuth = value; } }

       
    }
}