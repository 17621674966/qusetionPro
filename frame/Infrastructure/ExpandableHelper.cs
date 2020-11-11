using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public  class ExpandableHelper
    {
        public static IQueryable<T> GetExpandable<T>(IQueryable<T> obj)
        {
            return obj.AsExpandable() as IQueryable<T>;
        }
    }
}
