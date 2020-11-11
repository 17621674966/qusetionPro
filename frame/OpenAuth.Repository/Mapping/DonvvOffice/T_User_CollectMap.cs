using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_User_CollectMap : EntityTypeConfiguration<T_User_Collect>
    {
        public T_User_CollectMap()
        {
            this.ToTable("T_User_Collect");
            this.HasKey(x => x.RowGuid);

        }
    }
}
