﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueForecast.Common.Models
{
    public class LocationModel
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public bool IsActive { get; set; }
    }
}
