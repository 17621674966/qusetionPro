using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
  public  class T_QsDetailLog1Map : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsDetailLog1>
    {

        public T_QsDetailLog1Map()
        {
            ToTable("T_QsDetailLog1", "dbo");
            HasKey(t => t.Id);
        }
    }
}
