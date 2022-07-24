using IRNA.Web.Services.Interfaces;
using IRNA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRNA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;
        public HomeController()
        {
            _service = new Services.Service();
        }
        // GET: Home
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult Menu(int page=0,int pageSize=10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/genres?page={page}&pageSize={pageSize}";
            var res = _service.GetApiResponse<ViewModels.ContentResponseVM>(url).GetAwaiter().GetResult();
           
            return PartialView(res);
        }
        
        public ActionResult Slider(int page = 0, int pageSize = 10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&tags=اسلایدر&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }

        public ActionResult LatestContents(int page = 0, int pageSize = 10)
       {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
             return PartialView(res);
        }
 

        public ActionResult PopularContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/userRate" +
                  $"?lang=fa&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();

            return PartialView(res);
        }
        
        public ActionResult MostVisitedContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/consumed" +
                  $"?lang=fa&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
          
            return PartialView(res);
        }

        public ActionResult RandomContents(int page = 0,int pageSize = 10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/random" +
               $"?lang=fa&page={page}&pageSize={pageSize}";

            ContentResponseVM res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();

            return PartialView(res);
        }

        public ActionResult SuggestedContents(ContentFilterVM content, int page = 0, int pageSize = 10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/consumed" +
                  $"?lang=fa&page={page}&pageSize={pageSize}" +
                  $"&keyword={content.keyword}" +
                  $"&genres={content.genres}";
            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();

            var final = new ContentResponseVM()
            {
                list = res.list.Where(l => l.id != content.Id).ToList(),
                galleryRoot = res.galleryRoot,
                info = res.info,
                numberOfPages = res.numberOfPages,
                numberOfRecords = res.numberOfRecords,
                page = res.page,
                pageSize = res.pageSize,
                priceUnit = res.priceUnit,
                root = res.root
            };
            return PartialView(final);
        }

        public ActionResult AdsContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&special=true&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }

        public ActionResult EventsContents(int page = 0,int pageSize = 10)
        {
            var url = $"{Services.Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&tags=مناسبت&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }

        [Route("About")]
        public ActionResult About()
        {
            return View();
        }

        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Faq")]
        public ActionResult Faq()
        {
            return View();
        }


    }
}