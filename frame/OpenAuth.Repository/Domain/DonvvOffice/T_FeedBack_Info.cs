

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_FeedBack_Info : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_FeedBack_Info()
        {
        }

       

        private System.String _FeedBackUserGuid;
        /// <summary>
        /// 反馈人标识
        /// </summary>
        public System.String FeedBackUserGuid { get { return this._FeedBackUserGuid; } set { this._FeedBackUserGuid = value; } }

        private System.String _FeedBackContent;
        /// <summary>
        /// 反馈内容
        /// </summary>
        public System.String FeedBackContent { get { return this._FeedBackContent; } set { this._FeedBackContent = value; } }

        
    }
}