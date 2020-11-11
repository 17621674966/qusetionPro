using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Information_InfoMap: EntityTypeConfiguration<T_Information_Info>
    {
        public T_Information_InfoMap()
        {
            this.ToTable("T_Information_Info");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
