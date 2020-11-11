

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Needs_CommentInfo : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Needs_CommentInfo()
        {
        }

       

        private System.String _NeedsGuid;
        /// <summary>
        /// 供需表行标识
        /// </summary>
        public System.String NeedsGuid { get { return this._NeedsGuid; } set { this._NeedsGuid = value; } }

        private System.String _UserGuid;
        /// <summary>
        /// 评论人标识
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

        private System.String _CommentContent;
        /// <summary>
        /// 评论内容
        /// </summary>
        public System.String CommentContent { get { return this._CommentContent; } set { this._CommentContent = value; } }

        
    }
}