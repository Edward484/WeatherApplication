﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Model
{
    public class Temperature
    {
        public MeasurementUnit Metric { get; set; }
        public MeasurementUnit Imperial { get; set; }
    }
}
