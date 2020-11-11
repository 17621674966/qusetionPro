

using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Needs_Info : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Needs_Info()
        {
        }

       

        

        private System.Int32? _Type;
        /// <summary>
        /// 1需求 2 供给
        /// </summary>
        public System.Int32? Type { get { return this._Type; } set { this._Type = value; } }

        private System.String _TypeItemGuid;
        /// <summary>
        /// 类型
        /// </summary>
        public System.String TypeItemGuid { get { return this._TypeItemGuid; } set { this._TypeItemGuid = value; } }

        private System.String _UserGuid;
        /// <summary>
        /// 发布人标识
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

        private System.String _Title;
        /// <summary>
        /// 标题
        /// </summary>
        public System.String Title { get { return this._Title; } set { this._Title = value; } }

        private System.Int32? _AuditStatus;
        /// <summary>
        /// 审核状态0待审核1审核通过2审核不通过
        /// </summary>
        public System.Int32? AuditStatus { get { return this._AuditStatus; } set { this._AuditStatus = value; } }

        private System.String _AuditUserGuid;
        /// <summary>
        /// 审核人标识
        /// </summary>
        public System.String AuditUserGuid { get { return this._AuditUserGuid; } set { this._AuditUserGuid = value; } }

        private System.DateTime? _AuditTime;
        /// <summary>
        /// 审核时间
        /// </summary>
        public System.DateTime? AuditTime { get { return this._AuditTime; } set { this._AuditTime = value; } }

        private System.String _AuditUnReason;
        /// <summary>
        /// 审核不通过理由
        /// </summary>
        public System.String AuditUnReason { get { return this._AuditUnReason; } set { this._AuditUnReason = value; } }

        private System.String _ContentValue;
        /// <summary>
        /// 内容
        /// </summary>
        public System.String ContentValue { get { return this._ContentValue; } set { this._ContentValue = value; } }

        private System.String _OutLine;
        /// <summary>
        /// 摘要
        /// </summary>
        public System.String OutLine { get { return this._OutLine; } set { this._OutLine = value; } }

        
    }
}