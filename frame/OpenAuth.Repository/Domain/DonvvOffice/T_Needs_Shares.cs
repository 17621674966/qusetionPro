

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Needs_Shares : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Needs_Shares()
        {
        }



        private System.String _NeedsGuid;
        /// <summary>
        /// 供需表行标识
        /// </summary>
        public System.String NeedsGuid { get { return this._NeedsGuid; } set { this._NeedsGuid = value; } }

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
        /// 
        /// </summary>
        public System.Int32? BrowseCount { get { return this._BrowseCount; } set { this._BrowseCount = value; } }

    }
}