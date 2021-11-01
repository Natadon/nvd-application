﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nvd.DataAccess.Objects
{
    public class NvdSearchResult
    {
        // Created by KP
        public int ID { get; set; }

        public int resultsPerPage { get; set; }
        public int startIndex { get; set; }
        public int totalResults { get; set; }
        public Result result { get; set; }
    }
}
