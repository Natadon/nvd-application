using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Result
    {
        // Created by KP
        public int ID { get; set; }

        public string CVE_data_type { get; set; }
        public string CVE_data_format { get; set; }
        public string CVE_data_version { get; set; }
        public string CVE_data_timestamp { get; set; }
        public ICollection<CVE_Items> CVE_Items { get; set; } //public CVE_Items[] CVE_Items { get; set; }
    }
}
