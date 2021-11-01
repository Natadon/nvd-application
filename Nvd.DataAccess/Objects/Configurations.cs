using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Configurations
    {
        // Created by KP
        public int ID { get; set; }

        public string CVE_data_version { get; set; }
        public ICollection<Node> nodes { get; set; }  //public Node[] nodes { get; set; }
    }
}
