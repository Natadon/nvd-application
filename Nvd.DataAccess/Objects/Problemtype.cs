using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Problemtype
    {
        // Created by KP
        public int ID { get; set; }

        public ICollection<Problemtype_Data> problemtype_data { get; set; }  // public Problemtype_Data[] problemtype_data { get; set; }
    }
}
