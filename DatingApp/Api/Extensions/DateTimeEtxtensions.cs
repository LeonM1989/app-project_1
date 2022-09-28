using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public static class DateTimeEtxtensions
    {
        public static int CalculateAge(this DateTime bob)
        {
            var age = DateTime.Today.Year - bob.Year;
            if(bob.AddYears(age)> DateTime.Today)
            age--;

            return age;
        }
    }
}