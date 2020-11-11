
using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Company_InfoMap:EntityTypeConfiguration<T_Company_Info>
    {
        public T_Company_InfoMap()
        {
            this.ToTable("T_Company_Info");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
