using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
  public  class T_QsDetailLog4Map : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsDetailLog4>
    {

        public T_QsDetailLog4Map()
        {
            ToTable("T_QsDetailLog4", "dbo");
            HasKey(t => t.Id);
        }
    }
}
