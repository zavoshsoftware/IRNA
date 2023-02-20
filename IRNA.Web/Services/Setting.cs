using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

 
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


    public static string GetCookieOrDefault(this HttpRequestBase request, string name)
    {
        return request.Cookies[name] == null ? "" : request.Cookies[name]?.Value??"";
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

    /// <summary>
    /// کد تصویر اسلایدر صفحه اصلی 
    /// </summary>
    public static string IndexSliderCode
    {
        get
        {
            return "slider";
        }
    } 
    
    /// <summary>
    /// کد تصویر اسلایدر صفحه اصلی 
    /// </summary>
    public static string IndexSliderCode2
    {
        get
        {
            return "mslider";
        }
    } 

    /// <summary>
    /// کد تصویر بنر اصلی صفحه جزئیات یک محتوا
    /// </summary>
    public static string ContentDetailsBannerCode
        {
            get
            {
                return "banner";
            }
        }

        /// <summary>
        /// کد تصویر گالری صفحه جزئیات یک محتوا
        /// </summary>
        public static string ContentDetailsGalleryCode
        {
            get
            {
                return "300x400";
            }
        }
        /// <summary>
        /// کد تصویرمناسبت
        /// </summary>
        public static string EventCode
        {
            get
            {
                return "event";
            }
        }
        /// <summary>
        /// کد تصویرتبلیغات
        /// </summary>
        public static string AdsCode
        {
            get
            {
                return "ads";
            }
        }
    } 