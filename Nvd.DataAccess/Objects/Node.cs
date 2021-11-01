using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class Node
    {
        // Created by KP
        public int ID { get; set; }

        public string _operator { get; set; }
        [NotMapped]
        public object[] children { get; set; }
        public ICollection<Cpe_Match> cpe_match { get; set; }  // public Cpe_Match[] cpe_match { get; set; }
    }
}
