using _OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Dic_TypeMainMap: EntityTypeConfiguration<T_Dic_TypeMain>
    {
        public T_Dic_TypeMainMap()
        {
            this.ToTable("T_Dic_TypeMain");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
