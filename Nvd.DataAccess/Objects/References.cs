using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{

    public class References
    {
        // Created by KP
        public int ID { get; set; }

        public ICollection<Reference_Data> reference_data { get; set; } // public Reference_Data[] reference_data { get; set; }
    }
}
