using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
  public  class T_QsDetailLog3Map : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsDetailLog3>
    {

        public T_QsDetailLog3Map()
        {
            ToTable("T_QsDetailLog3", "dbo");
            HasKey(t => t.Id);
        }
    }
}
