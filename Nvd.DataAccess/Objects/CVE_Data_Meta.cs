using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class CVE_Data_Meta
    {
        [Key]
        public int PrimaryKey { get; set; }
        public string ID { get; set; }
        public string ASSIGNER { get; set; }
    }
}
