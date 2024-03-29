﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Models
{
    public class OpenHours
    {
        public int Id { get; set; }

        public OpenHoursDay Monday { get; set; }

        public OpenHoursDay Tuesday { get; set; }

        public OpenHoursDay Wednesday { get; set; }

        public OpenHoursDay Thursday { get; set; }

        public OpenHoursDay Friday { get; set; }

        public OpenHoursDay Saturday { get; set; }

        public OpenHoursDay Sunday { get; set; }
    }

    public class OpenHoursDay
    {
        public int Id { get; set; }

        public DateTime OpeningHour { get; set; }

        public DateTime ClosingHour { get; set; }
    }
}
