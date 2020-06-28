﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.Api
{
    public class AppSettings
    {
        public string GeocodingApiUrl { get; set; }
        public string GeocodingApiToken { get; set; }
        public string FoursquareApiUrl { get; set; }
        public string FoursquareApiId { get; set; }
        public string FoursquareApiSecret { get; set; }
    }
}
