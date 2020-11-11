using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Operation_TypeMap: EntityTypeConfiguration<T_Operation_Type>
    {
        public T_Operation_TypeMap()
        {
            this.ToTable("T_Operation_Type");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
