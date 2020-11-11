

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Operation_Type : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Operation_Type()
        {
        }

        

        private System.String _OrerationType;
        /// <summary>
        /// 操作类型
        /// </summary>
        public System.String OrerationType { get { return this._OrerationType; } set { this._OrerationType = value; } }

        private System.Int32 _Score;
        /// <summary>
        /// 分数
        /// </summary>
        public System.Int32 Score { get { return this._Score; } set { this._Score = value; } }

        
    }
}