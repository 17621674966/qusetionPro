

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Notice_Users : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Notice_Users()
        {
        }

       

        private System.String _NoticeGuid;
        /// <summary>
        /// 消息表标识
        /// </summary>
        public System.String NoticeGuid { get { return this._NoticeGuid; } set { this._NoticeGuid = value; } }

        private System.String _UserGuid;
        /// <summary>
        /// 用户标识
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

        private System.Int32? _IsSendMsg;
        /// <summary>
        /// 是否已经成功发送短信
        /// </summary>
        public System.Int32? IsSendMsg { get { return this._IsSendMsg; } set { this._IsSendMsg = value; } }

        private System.Int32? _IsSendMail;
        /// <summary>
        /// 是否已成功发送邮件
        /// </summary>
        public System.Int32? IsSendMail { get { return this._IsSendMail; } set { this._IsSendMail = value; } }

       
    }
}