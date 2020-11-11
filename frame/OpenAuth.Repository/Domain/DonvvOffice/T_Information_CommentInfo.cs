

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Information_CommentInfo : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Information_CommentInfo()
        {
        }

       

        private System.String _InformationGuid;
        /// <summary>
        /// 资讯标识
        /// </summary>
        public System.String InformationGuid { get { return this._InformationGuid; } set { this._InformationGuid = value; } }

        private System.String _UserGuid;
        /// <summary>
        /// 评论用户标识
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

        private System.String _CommentContent;
        /// <summary>
        /// 评论内容
        /// </summary>
        public System.String CommentContent { get { return this._CommentContent; } set { this._CommentContent = value; } }

        
    }
}