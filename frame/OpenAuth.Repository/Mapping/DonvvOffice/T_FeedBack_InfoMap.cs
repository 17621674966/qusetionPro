using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_FeedBack_InfoMap: EntityTypeConfiguration<T_FeedBack_Info>
    {
        public T_FeedBack_InfoMap()
        {
            this.ToTable("T_FeedBack_Info");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
