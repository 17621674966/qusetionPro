using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Information_AttachMap: EntityTypeConfiguration<T_Information_Attach>
    {

        public T_Information_AttachMap()
        {
            this.ToTable("T_Information_Attach");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
