using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace IRNA.Web.Services
{
    public static class Helper
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string ReplaceWhitespace(this string input)
        => Regex.Replace(input, @"\s", "");

        public static string ToShamsi(this DateTime d,char type = 'a')
        {
            PersianCalendar pc = new PersianCalendar();
            string result = string.Empty; 
            switch (type)
            {
                case 'a':
                   result = string.Format("{0}/{1}/{2}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d));
                    break;
                case 'h':
                   result = string.Format("{0}:{1}", pc.GetHour(d),pc.GetMinute(d));
                    break;
                     
            }
            return result;
        }
    }
}