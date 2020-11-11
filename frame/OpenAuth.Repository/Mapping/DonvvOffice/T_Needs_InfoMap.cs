using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Needs_InfoMap: EntityTypeConfiguration<T_Needs_Info>
    {
        public T_Needs_InfoMap()
        {
            this.ToTable("T_Needs_Info");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
