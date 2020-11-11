using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public  class T_Needs_AttachMap: EntityTypeConfiguration<T_Needs_Attach>
    {
        public T_Needs_AttachMap()
        {
            this.ToTable("T_Needs_Attach");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
