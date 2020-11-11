using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    public  class T_Dic_TypeItem:BaseEntity
    {

        public T_Dic_TypeItem()
        { }
        private System.String _TypeGuid;
        /// <summary>
        /// 父类型Guid
        /// </summary>
        public System.String TypeGuid { get { return this._TypeGuid; } set { this._TypeGuid = value; } }

        private System.String _ItemName;
        /// <summary>
        /// 分类项
        /// </summary>
        public System.String ItemName { get { return this._ItemName; } set { this._ItemName = value; } }

        private System.Int32? _SortNumber;
        /// <summary>
        /// 排序值
        /// </summary>
        public System.Int32? SortNumber { get { return this._SortNumber; } set { this._SortNumber = value; } }

        private System.String _Note;
        /// <summary>
        /// 备注
        /// </summary>
        public System.String Note { get { return this._Note; } set { this._Note = value; } }
    }
}
