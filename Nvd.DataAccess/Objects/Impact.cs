using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Impact
    {
        // Created by KP
        public int ID { get; set; }

        public Basemetricv3 baseMetricV3 { get; set; }
        public Basemetricv2 baseMetricV2 { get; set; }
    }
}
