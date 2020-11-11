

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Level_Info : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Level_Info()
        {
        }

        

        private System.String _LevelContent;
        /// <summary>
        /// 会员等级
        /// </summary>
        public System.String LevelContent { get { return this._LevelContent; } set { this._LevelContent = value; } }

        private System.Int32? _ScoreRange;
        /// <summary>
        /// 积分范围
        /// </summary>
        public System.Int32? ScoreRange { get { return this._ScoreRange; } set { this._ScoreRange = value; } }

       
    }
}