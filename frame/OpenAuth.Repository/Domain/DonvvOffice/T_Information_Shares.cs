

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Information_Shares : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Information_Shares()
        {
        }

        

        private System.String _InformationGuid;
        /// <summary>
        /// 资讯标识
        /// </summary>
        public System.String InformationGuid { get { return this._InformationGuid; } set { this._InformationGuid = value; } }

        private System.Int32? _GoodLikeCount;
        /// <summary>
        /// 点赞数目
        /// </summary>
        public System.Int32? GoodLikeCount { get { return this._GoodLikeCount; } set { this._GoodLikeCount = value; } }

        private System.Int32? _ToFriendCount;
        /// <summary>
        /// 分享给朋友次数
        /// </summary>
        public System.Int32? ToFriendCount { get { return this._ToFriendCount; } set { this._ToFriendCount = value; } }

        private System.Int32? _ToFriendsCount;
        /// <summary>
        /// 分享到朋友圈次数
        /// </summary>
        public System.Int32? ToFriendsCount { get { return this._ToFriendsCount; } set { this._ToFriendsCount = value; } }

        private System.Int32? _BrowseCount;
        /// <summary>
        /// 浏览次数
        /// </summary>
        public System.Int32? BrowseCount { get { return this._BrowseCount; } set { this._BrowseCount = value; } }

        
    }
}