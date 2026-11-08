using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Utilities
{
    public static class DateHelper
    {
        public static string ToPersianDate(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                return string.Format("{}/{}/{}", pc.GetYear(dateTime).ToString().PadLeft(4, '0'), pc.GetMonth(dateTime).ToString().PadLeft(2, '0'), pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0'));
            }
            catch
            {
                return "";
            }
        }

        public static string ToPersianDate(this DateTime dateTime,string format)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            { string date = format.Replace("Y", pc.GetYear(dateTime).ToString().PadLeft(4, '0'))
             .Replace("M", pc.GetMonth(dateTime).ToString().PadLeft(2, '0'))
             .Replace("m", pc.GetMonth(dateTime).ToString())
             .Replace("D", pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0'))
             .Replace("d", pc.GetDayOfMonth(dateTime).ToString())
             .Replace("ms", GetMonthString(pc.GetMonth(dateTime)).ToString())
             .Replace("ds", GetDayOfWeekString((int)pc.GetDayOfWeek(dateTime)).ToString());
             return date;
            }
            catch
            {
                return "";
            }
        }

        private static string GetDayOfWeekString(int day)
        {
            string[] days = new[] { "جمعه", "پنج شنبه", "چهارشنبه", "سه شنبه", "دوشنبه", "یکشنبه", "شنبه" };
            if (day <= days.Length)
            {
                return days[day];
            }
            return "";
            
        }
        private static string GetMonthString(int month)
        {
            string[] months = new[] {"اسفند", "بهمن","دی","آذز","آبان","مهر", "شهریور ", "مرداد", " تیر", "خرداد", "اردیبهشت", "فروردین" };
            if (month <= months.Length)
            {
                return months[month-1];
            }
            return "";

        }
        public static string GetTimeAgo(this DateTime dateTime)
        { 
            var now=DateTime.Now;
            var year=now.Year-dateTime.Year;
            var month = now.Month - dateTime.Month;
            var day = now.Day    - dateTime.Day;
            var minute = now.Minute - dateTime.Minute;
            var second = now.Second - dateTime.Second;
            if (year > 0)
                return $"{year}سال پیش";
            if (month > 0)
                return $"{month}ماه پیش";
            if (day > 0)
                return $"{day}روز پیش";
            if (minute > 0)
                return $"{minute}دقیقه پیش";
            if (second > 0)
                return $"{second}ثانیه پیش";
            else
                return "لحظاتی پیش";








        }

    }
}
