using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JogaFacil.App.Util
{
    public class TimeRangeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;

            if (date.CompareTo(DateTime.Now) < 0)
            {
                return false;
            }

            return true;
        }
    }
}
