using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Level_InfoMap: EntityTypeConfiguration<T_Level_Info>
    {
        public T_Level_InfoMap()
        {
            this.ToTable("T_Level_Info");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
