

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_User_OrderInfo : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_User_OrderInfo()
        {
        }

        

        private System.String _TypeGuid;
        /// <summary>
        /// 
        /// </summary>
        public System.String TypeGuid { get { return this._TypeGuid; } set { this._TypeGuid = value; } }

        private System.String _TypeName;
        /// <summary>
        /// 
        /// </summary>
        public System.String TypeName { get { return this._TypeName; } set { this._TypeName = value; } }

        private System.String _UserGuid;
        /// <summary>
        /// 
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

       
    }
}