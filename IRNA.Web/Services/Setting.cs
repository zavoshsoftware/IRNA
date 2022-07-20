using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IRNA.Web.Services
{
    public static class Settings
    {

        public static string BaseUrl
        {
            get
            {
                //api base url
                return Setting<string>("BaseUrl");
                //return Setting<string>("LocalBaseUrl");
            }
        } 
        private static T Setting<T>(this string name)
        {
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                throw new Exception(String.Format("Could not find setting '{0}',", name));
            }

            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
        public static HttpCookie CreateCookie(string value, int days=3)
        {
            HttpCookie irnaookies = new HttpCookie("Token");
            irnaookies.Value = value;
            irnaookies.Expires = DateTime.Now.AddDays(days);
            return irnaookies;
        }
    }

}