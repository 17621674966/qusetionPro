using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
   public  class T_QsSuggestMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsSuggest>
    {
        public T_QsSuggestMap() {
            ToTable("T_QsSuggest", "dbo");
            HasKey(t => t.Id);
        }
    }
}
