using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Information_TitleImgMap: EntityTypeConfiguration<T_Information_TitleImg>
    {
        public T_Information_TitleImgMap()
        {
            this.ToTable("T_Information_TitleImg");
            this.HasKey(x => x.RowGuid);
        }
    }
}
