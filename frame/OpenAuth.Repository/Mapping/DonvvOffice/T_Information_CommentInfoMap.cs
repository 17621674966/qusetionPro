using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public class T_Information_CommentInfoMap: EntityTypeConfiguration<T_Information_CommentInfo>
    {
        public T_Information_CommentInfoMap()
        {
            this.ToTable("T_Information_CommentInfo");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
