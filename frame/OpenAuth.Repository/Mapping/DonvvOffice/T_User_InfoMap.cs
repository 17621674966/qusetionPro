using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_User_InfoMap : EntityTypeConfiguration<T_User_Info>
    {

        public T_User_InfoMap() {
            this.ToTable(" T_User_Info");
            this.HasKey(x=>x.RowGuid);
        }


    }
}
