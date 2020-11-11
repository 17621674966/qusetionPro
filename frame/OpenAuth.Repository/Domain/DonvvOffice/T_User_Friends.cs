

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_User_Friends : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_User_Friends()
        {
        }

       

        private System.String _UserGuid;
        /// <summary>
        /// 用户标识
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

        private System.String _FriendGuid;
        /// <summary>
        /// 朋友标识
        /// </summary>
        public System.String FriendGuid { get { return this._FriendGuid; } set { this._FriendGuid = value; } }

       
    }
}