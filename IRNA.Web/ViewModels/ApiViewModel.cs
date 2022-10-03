using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRNA.Web.ViewModels
{
    public class BaseResponseVM
    {
        public int code { get; set; }
        public localizedMessagesVM localizedMessages { get; set; }
    }
    public class ResponseVM : BaseResponseVM
    {
        public moreVM more { get; set; }
    }
    public partial class localizedMessagesVM
    {
        public string fa { get; set; }
        public string en { get; set; }
        public string ar { get; set; }
    }

    public partial class moreVM
    {
        public string result { get; set; }
    } 
}
