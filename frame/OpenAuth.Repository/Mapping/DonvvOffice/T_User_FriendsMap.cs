using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public  class T_User_FriendsMap: EntityTypeConfiguration<T_User_Friends>
    {
        public T_User_FriendsMap()
        {
            this.ToTable("T_User_Friends");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
