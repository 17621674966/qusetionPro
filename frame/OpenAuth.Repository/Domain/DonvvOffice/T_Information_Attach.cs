

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Information_Attach : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Information_Attach()
        {
        }

        

        private System.String _InformationGuid;
        /// <summary>
        /// 咨询表主键
        /// </summary>
        public System.String InformationGuid { get { return this._InformationGuid; } set { this._InformationGuid = value; } }

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
        /// 附件url
        /// </summary>
        public System.String AttachUrl { get { return this._AttachUrl; } set { this._AttachUrl = value; } }

        
    }
}