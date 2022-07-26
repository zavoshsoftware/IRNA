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

        public ActionResult Menu(int page = 0, int pageSize = 10,bool isMobile=false)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/genres?page={page}&pageSize={pageSize}";
            var res = _service.GetApiResponse<ViewModels.ContentResponseVM>(url).GetAwaiter().GetResult();

            if (isMobile)
            {
                return PartialView("MenuMobile", res);
            }
            else
            {
                return PartialView(res); 
            }
        }

        public ActionResult Slider(int page = 0, int pageSize = 10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&selected=true&tags=اسلایدر&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }

        public ActionResult LatestContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }
         
        public ActionResult PopularContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/userRate" +
                  $"?lang=fa&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();

            return PartialView(res);
        }

        public ActionResult MostVisitedContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/consumed" +
                  $"?lang=fa&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();

            return PartialView(res);
        }

        public ActionResult RandomContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/random" +
               $"?lang=fa&page={page}&pageSize={pageSize}";

            ContentResponseVM res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();

            return PartialView(res);
        }

        public ActionResult SuggestedContents(ContentFilterVM content, int page = 0, int pageSize = 10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/consumed" +
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
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&special=true&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }

        public ActionResult EventsContents(int page = 0, int pageSize = 10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                  $"?lang=fa&tags=مناسبت&page={page}&pageSize={pageSize}";

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }

        public ActionResult FilterContents()
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/filters" +
         $"?language=fa&music=true&skipDefaults=true";

            var res = _service.GetApiResponse<RootFilterVM>(url).GetAwaiter().GetResult();
            return PartialView(res);
        }
         
        [Route("List")]
        public ActionResult List(int page=0,int pageSize=10, int genre = 0,string age="0",string qualityTypes="0"
            ,string countries = "0")
        {
            var genreObj = _service.GetGenres().GetAwaiter().GetResult().list.FirstOrDefault(l => l.id == genre);
            string genreQuery = genre == 0 ? "" : $"&genres={genre}";
            string ageQuery = age == "" || age == "0" ? "" : $"&ageGroups={age}";
            string qualityQuery = qualityTypes == "" || qualityTypes == "0" ? "" : $"&qualityType={qualityTypes}";
            string countryQuery = countries == "" || countries == "0" ? "" : $"&qualityType={countries}";
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
               $"?lang=fa&page={page}&pageSize={pageSize}" +
              genreQuery+
              ageQuery+
              qualityQuery+
              countryQuery
              ;

            var res = _service.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult(); 
            return View(res);
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

        [Route("Privacy")]
        public ActionResult Privacy()
        {
            return View();
        }
    }
}