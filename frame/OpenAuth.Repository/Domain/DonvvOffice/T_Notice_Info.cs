

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Notice_Info : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Notice_Info()
        {
        }

       

        private System.Boolean? _IsHandle;
        /// <summary>
        /// 是否处理
        /// </summary>
        public System.Boolean? IsHandle { get { return this._IsHandle; } set { this._IsHandle = value; } }

        private System.String _TypeGuid;
        /// <summary>
        /// 类型Guid
        /// </summary>
        public System.String TypeGuid { get { return this._TypeGuid; } set { this._TypeGuid = value; } }

        private System.String _TypeName;
        /// <summary>
        /// 类型Name
        /// </summary>
        public System.String TypeName { get { return this._TypeName; } set { this._TypeName = value; } }

        private System.String _NoticeTitle;
        /// <summary>
        /// 消息标题
        /// </summary>
        public System.String NoticeTitle { get { return this._NoticeTitle; } set { this._NoticeTitle = value; } }

        private System.String _NoticeContent;
        /// <summary>
        /// 消息内容
        /// </summary>
        public System.String NoticeContent { get { return this._NoticeContent; } set { this._NoticeContent = value; } }

        private System.String _TableName;
        /// <summary>
        /// 这条消息来自于那个表
        /// </summary>
        public System.String TableName { get { return this._TableName; } set { this._TableName = value; } }

        private System.String _TableRowGuid;
        /// <summary>
        /// 这条消息来自于哪个行
        /// </summary>
        public System.String TableRowGuid { get { return this._TableRowGuid; } set { this._TableRowGuid = value; } }

       
    }
}