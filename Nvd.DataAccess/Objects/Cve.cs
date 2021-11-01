using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Cve
    {
        // Created by KP
        public int ID { get; set; }

        public string data_type { get; set; }
        public string data_format { get; set; }
        public string data_version { get; set; }
        public CVE_Data_Meta CVE_data_meta { get; set; }
        public Problemtype problemtype { get; set; }
        public References references { get; set; }
        public Description1 description { get; set; }
    }
}
