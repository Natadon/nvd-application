using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Description1
    {
        // Created by KP
        public int ID { get; set; }

        public ICollection<Description_Data> description_data { get; set; }  // public Description_Data[] description_data { get; set; }
    }
}
