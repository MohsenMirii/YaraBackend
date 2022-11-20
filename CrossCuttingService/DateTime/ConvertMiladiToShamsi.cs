using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CrossCuttingService.DateTime
{
    public partial class DateTime_BL
    {
        public string ConvertMiladiToShamsi(System.DateTime? DateTime, string seperator = null)
        {
            if (DateTime.HasValue == false)
            {
                return null;
            }

            if (string.IsNullOrEmpty(seperator))
            {
                seperator = string.Empty;
            }
            PersianCalendar PerCal = new PersianCalendar();
            string Year, Day, Month;
            Year = PerCal.GetYear(DateTime.Value).ToString();
            Month = PerCal.GetMonth(DateTime.Value).ToString();
            Day = PerCal.GetDayOfMonth(DateTime.Value).ToString();
            if (Day.Length == 1)
            {
                Day = PerCal.GetDayOfMonth(DateTime.Value).ToString().Insert(0, "0");
            }
            if (Month.Length == 1)
            {
                Month = PerCal.GetMonth(DateTime.Value).ToString().Insert(0, "0");
            }
            return Year + seperator + Month + seperator + Day;
        }
    }
}
