using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
  public  class T_QsDetailLog5Map : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsDetailLog5>
    {

        public T_QsDetailLog5Map()
        {
            ToTable("T_QsDetailLog5", "dbo");
            HasKey(t => t.Id);
        }
    }
}
