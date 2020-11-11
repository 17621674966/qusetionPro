using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public  class T_Information_SharesMap: EntityTypeConfiguration<T_Information_Shares>
    {
        public T_Information_SharesMap()
        {
            this.ToTable("T_Information_Shares");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
