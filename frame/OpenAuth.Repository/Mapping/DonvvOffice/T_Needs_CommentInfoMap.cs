using OpenAuth.Repository.Domain.DonvvOffice;
using System.Data.Entity.ModelConfiguration;

namespace OpenAuth.Repository.Mapping.DonvvOffice
{
    public  class T_Needs_CommentInfoMap: EntityTypeConfiguration<T_Needs_CommentInfo>
    {
        public T_Needs_CommentInfoMap()
        {
            this.ToTable("T_Needs_CommentInfo");
            this.HasKey(x=>x.RowGuid);
        }
    }
}
