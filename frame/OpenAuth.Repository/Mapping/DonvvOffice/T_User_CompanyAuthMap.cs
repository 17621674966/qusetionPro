using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_User_CompanyAuthMap : EntityTypeConfiguration<T_User_CompanyAuth>
    {
        public T_User_CompanyAuthMap()
        {
            this.ToTable("T_User_CompanyAuth");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
