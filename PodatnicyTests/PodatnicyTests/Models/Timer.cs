using System;
using System.Collections.Generic;
using System.Text;

namespace PodatnicyTests.Models
{
    class Timer
    {
        public static DateTime DateTimeNow { get; set; }

        public static void SetDateResponse(DateTime responseDate)
        {
            DateTimeNow = responseDate;
        }
        public static DateTime GetDateResponse()
        {
            return DateTimeNow;
        }

    }
}
