using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Commont
{
    public static class StringHelep
   {
       public static Guid TryParseGuid(this string obj)
       {
           Guid gid = Guid.Empty;
           if (string.IsNullOrWhiteSpace(obj))
           {
               return gid;
           }

           Guid.TryParse(obj, out gid);
           return gid;
       }

    }
}
