using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class CVE_Items
    {
        // Created by KP
        public int ID { get; set; }

        public Cve cve { get; set; }
        public Configurations configurations { get; set; }
        public Impact impact { get; set; }
        public string publishedDate { get; set; }
        public string lastModifiedDate { get; set; }
    }
}