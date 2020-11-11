

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Needs_Attach : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Needs_Attach()
        {
        }

       

        private System.String _NeedsGuid;
        /// <summary>
        /// 供需表行标识
        /// </summary>
        public System.String NeedsGuid { get { return this._NeedsGuid; } set { this._NeedsGuid = value; } }

        private System.String _AttachName;
        /// <summary>
        /// 附件名称
        /// </summary>
        public System.String AttachName { get { return this._AttachName; } set { this._AttachName = value; } }

        private System.String _AttachType;
        /// <summary>
        /// 附件类型
        /// </summary>
        public System.String AttachType { get { return this._AttachType; } set { this._AttachType = value; } }

        private System.Decimal? _AttachSize;
        /// <summary>
        /// 附件大小
        /// </summary>
        public System.Decimal? AttachSize { get { return this._AttachSize; } set { this._AttachSize = value; } }

        private System.String _AttachUrl;
        /// <summary>
        /// 附件存储的url
        /// </summary>
        public System.String AttachUrl { get { return this._AttachUrl; } set { this._AttachUrl = value; } }

       
    }
}