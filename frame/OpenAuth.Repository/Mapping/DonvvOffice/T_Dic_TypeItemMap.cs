using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public  class T_Dic_TypeItemMap:EntityTypeConfiguration<T_Dic_TypeItem>
    {
        public T_Dic_TypeItemMap()
        {
            this.ToTable("T_Dic_TypeItem");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
