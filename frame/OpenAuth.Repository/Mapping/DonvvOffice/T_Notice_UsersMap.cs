using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Notice_UsersMap: EntityTypeConfiguration<T_Notice_Users>
    {

        public T_Notice_UsersMap()
        {
            this.ToTable("T_Notice_Users");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
