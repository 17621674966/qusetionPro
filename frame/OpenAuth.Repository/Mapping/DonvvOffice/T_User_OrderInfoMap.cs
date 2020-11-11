using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_User_OrderInfoMap: EntityTypeConfiguration<T_User_OrderInfo>
    {
        public T_User_OrderInfoMap()
        {
            this.ToTable("T_User_OrderInfo");
            this.HasKey(x=>x.RowGuid);
        }

    }
}
