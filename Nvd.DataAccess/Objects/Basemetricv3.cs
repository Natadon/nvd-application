using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Basemetricv3
    {
        // Created by KP
        public int ID { get; set; }

        public Cvssv3 cvssV3 { get; set; }
        public float exploitabilityScore { get; set; }
        public float impactScore { get; set; }
    }
}
