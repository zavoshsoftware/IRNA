using IRNA.Web.Services.Interfaces;
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
        public ActionResult LatestContents()
        {
            return PartialView();
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