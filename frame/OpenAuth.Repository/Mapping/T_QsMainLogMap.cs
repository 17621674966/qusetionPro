using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth.Repository.Mapping
{
   public class T_QsMainLogMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OpenAuth.Repository.Domain.T_QsMainLog>
    {
        public T_QsMainLogMap()
        {
            ToTable("T_QsMainLog", "dbo");
            HasKey(t => t.Id);
        }
    }
}
