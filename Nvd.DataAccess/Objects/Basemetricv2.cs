using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Basemetricv2
    {
        // Created by KP
        public int ID { get; set; }

        public Cvssv2 cvssV2 { get; set; }
        public string severity { get; set; }
        public float exploitabilityScore { get; set; }
        public float impactScore { get; set; }
        public bool acInsufInfo { get; set; }
        public bool obtainAllPrivilege { get; set; }
        public bool obtainUserPrivilege { get; set; }
        public bool obtainOtherPrivilege { get; set; }
        public bool userInteractionRequired { get; set; }
    }
}
