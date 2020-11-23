using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
  public  class T_QsDetailLog6Map : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsDetailLog6>
    {

        public T_QsDetailLog6Map()
        {
            ToTable("T_QsDetailLog6", "dbo");
            HasKey(t => t.Id);
        }
    }
}
