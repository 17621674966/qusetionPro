using OpenAuth.Repository.Core;

namespace OpenAuth.Repository.Domain.DonvvOffice
{
    public class T_Information_TitleImg:BaseEntity
    {
        public T_Information_TitleImg()
        {
        }


        private System.String _InformationGuid;
        /// <summary>
        /// 
        /// </summary>
        public System.String InformationGuid { get { return this._InformationGuid; } set { this._InformationGuid = value; } }

        private System.String _TitleImgUrl;
        /// <summary>
        /// 
        /// </summary>
        public System.String TitleImgUrl { get { return this._TitleImgUrl; } set { this._TitleImgUrl = value; } }

    }
}
