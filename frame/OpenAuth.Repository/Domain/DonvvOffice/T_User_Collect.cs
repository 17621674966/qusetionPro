using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    public class T_User_Collect : BaseEntity
    {
        public T_User_Collect()
        {

        }


        private System.Int32? _Type;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Type { get { return this._Type; } set { this._Type = value; } }

        private System.String _UserGuid;
        /// <summary>
        /// 
        /// </summary>
        public System.String UserGuid { get { return this._UserGuid; } set { this._UserGuid = value; } }

        private System.String _TableRowGuid;
        /// <summary>
        /// 
        /// </summary>
        public System.String TableRowGuid { get { return this._TableRowGuid; } set { this._TableRowGuid = value; } }

    }
}
