

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Operation_Detail : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Operation_Detail()
        {
        }

       

        private System.String _OperationTypeGuid;
        /// <summary>
        /// 操作类型
        /// </summary>
        public System.String OperationTypeGuid { get { return this._OperationTypeGuid; } set { this._OperationTypeGuid = value; } }

        private System.String _OperationDetail;
        /// <summary>
        /// 操作明细
        /// </summary>
        public System.String OperationDetail { get { return this._OperationDetail; } set { this._OperationDetail = value; } }

        private System.String _OperationUserGuid;
        /// <summary>
        /// 操作人标识
        /// </summary>
        public System.String OperationUserGuid { get { return this._OperationUserGuid; } set { this._OperationUserGuid = value; } }

        private System.Boolean? _IsHandle;
        /// <summary>
        /// 是否已经处理过了（0没有处理 1处理过了），这个主要是异步的算会员的积分
        /// </summary>
        public System.Boolean? IsHandle { get { return this._IsHandle; } set { this._IsHandle = value; } }

       
    }
}