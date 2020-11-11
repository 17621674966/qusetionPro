using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public  class T_User_FriendMsgMap: EntityTypeConfiguration<T_User_FriendMsg>
    {
        public T_User_FriendMsgMap()
        {
            this.ToTable("T_User_FriendMsg");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
