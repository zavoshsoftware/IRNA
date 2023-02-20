using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
                   result = string.Format("{0}:{1}", pc.GetHour(d.AddHours(4)) ,pc.GetMinute(d.AddMinutes(30)));
                    break; 
                case 's':
                   result = string.Format("{0}/{1}/{2}-{3}:{4}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), pc.GetHour(d.AddHours(4)) ,pc.GetMinute(d.AddMinutes(30)));
                    break; 
            }
            return result;
        }
        
        public static string ToShamsi(this long time,char type = 'a')
        =>  ToShamsi((new DateTime(1970, 1, 1)).AddMilliseconds(time), type);


        public static string GetObjectInfo(object myObject)
        {
            string result="";
            Type myType = myObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(myObject, null);
                result = result + propValue.ToString();
                // Do something with propValue
            }
            return result;
        }
        public static string StringConcatenator(string seprator, params string[] ps)
        => string.Join(seprator, ps.ToList());
    }
}