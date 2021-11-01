using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Reference_Data
    {
        // Created by KP
        public int ID { get; set; }

        public string url { get; set; }
        public string name { get; set; }
        public string refsource { get; set; }
        [NotMapped]
        public string[] tags { get; set; }
    }
}
