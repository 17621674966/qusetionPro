

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_User_FriendMsg : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_User_FriendMsg()
        {
        }

       

        private System.String _Msg;
        /// <summary>
        /// 消息内容
        /// </summary>
        public System.String Msg { get { return this._Msg; } set { this._Msg = value; } }

        private System.String _FromUserGuid;
        /// <summary>
        /// 谁发送的
        /// </summary>
        public System.String FromUserGuid { get { return this._FromUserGuid; } set { this._FromUserGuid = value; } }

        private System.String _ToUserGuid;
        /// <summary>
        /// 发送给谁的
        /// </summary>
        public System.String ToUserGuid { get { return this._ToUserGuid; } set { this._ToUserGuid = value; } }

        private System.Int32? _MsgStatus;
        /// <summary>
        /// 消息状态（0 未读，1已读）
        /// </summary>
        public System.Int32? MsgStatus { get { return this._MsgStatus; } set { this._MsgStatus = value; } }

       
    }
}