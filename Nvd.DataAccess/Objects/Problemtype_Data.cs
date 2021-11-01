using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Problemtype_Data
    {
        // Created by KP
        public int ID { get; set; }

        public ICollection<Description> description { get; set; } // public Description[] description { get; set; }
    }
}
