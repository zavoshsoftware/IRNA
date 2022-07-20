using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRNA.Web.ViewModels
{
    public class ContentViewModel
    {
    }
    public class ContentListVM
    {
        public int id { get; set; }
        public bool music { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
        public object gallery { get; set; }
    }

    public class ContentResponseVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfRecords { get; set; }
        public int numberOfPages { get; set; }
        public string root { get; set; }
        public string galleryRoot { get; set; }
        public object priceUnit { get; set; }
        public List<ContentListVM> list { get; set; }
        public object info { get; set; }
    }

}