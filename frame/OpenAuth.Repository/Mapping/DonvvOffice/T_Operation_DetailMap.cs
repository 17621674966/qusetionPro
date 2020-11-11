using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Operation_DetailMap: EntityTypeConfiguration<T_Operation_Detail>
    {
        public T_Operation_DetailMap()
        {
            this.ToTable("T_Operation_Detail");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
