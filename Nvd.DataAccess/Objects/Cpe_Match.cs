using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Cpe_Match
    {
        // Created by KP
        public int ID { get; set; }

        public bool vulnerable { get; set; }
        public string cpe23Uri { get; set; }
        public string versionEndIncluding { get; set; }
        [NotMapped]
        public object[] cpe_name { get; set; } // used to be object[]
        public string versionStartIncluding { get; set; }
    }
}
