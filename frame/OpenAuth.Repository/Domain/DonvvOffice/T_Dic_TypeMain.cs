


using OpenAuth.Repository.Core;

namespace _OpenAuth.Repository.Domain.DonvvOffice
{
    /// <summary>
    /// 
    /// </summary>
    public class T_Dic_TypeMain:BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public T_Dic_TypeMain()
        {
        }

        

        private System.String _Type;
        /// <summary>
        /// 字典类型
        /// </summary>
        public System.String Type { get { return this._Type; } set { this._Type = value; } }

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