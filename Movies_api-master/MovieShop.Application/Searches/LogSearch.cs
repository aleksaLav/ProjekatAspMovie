﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Application.Searches
{
    public class LogSearch : PagedSearch
    {
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; } = DateTime.UtcNow;
    }
}
