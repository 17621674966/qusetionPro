using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
  public  class T_QsDetailLog2Map : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsDetailLog2>
    {

        public T_QsDetailLog2Map()
        {
            ToTable("T_QsDetailLog2", "dbo");
            HasKey(t => t.Id);
        }
    }
}
