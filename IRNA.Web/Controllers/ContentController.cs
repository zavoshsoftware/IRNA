using IRNA.Web.Services;
using IRNA.Web.Services.Interfaces;
using IRNA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRNA.Web.Controllers
{
    public class ContentController : Controller
    {
        private readonly IService _apiService;
        public ContentController()
        {
            _apiService = new Service();
        }
        // GET: Content
        public ActionResult Index()
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/last?lang=fa&page=0&pageSize=10";

            //iptv/irna/v2/content/last?lang=fa&page=0&pageSize=10&classes=

            return View();
        }


        public ActionResult Last(int page=0,int pageSize=10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                $"?lang=fa&page={page}&pageSize={pageSize}";
            
             var res = _apiService.GetApiResponse<ContentResponseVM>(url).GetAwaiter().GetResult();

            return PartialView(res);
        }

        [Route("Content/{id}")]
        public ActionResult Details(int id)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/contentStatus?lang=fa&albumId={id}";

            var res = _apiService.GetApiResponse<RootContentDetailsVM>(url).GetAwaiter().GetResult();
            if (res!=null && res.vodResult==null)
            {
                return HttpNotFound();
            }
            return View(res);
        }

        [HttpPost]
        [Route("Content/SendComment")]
        public ActionResult SendComment(CommentVM comment)
        {
            //iptv/irna/v2/content/comment?language=fa&username=989335431764&diskId=2&name=سعید&body=سلام عالی&rate=3

            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/comment?" +
                $"language=fa&username=989335431764&diskId={comment.id}&name=&body={comment.body}&rate=0";
            var res = _apiService.GetApiResponse<RootCommentVM>(url).GetAwaiter().GetResult();
            return Json(new { res = res });
            //return Redirect($"/Content/{id}");
        }

        public ActionResult Comments(int id,int page=0,int pageSize=10)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/listCommentsOfDisk?" +
                $"language=fa&diskId={id}&page={page}&pageSize={pageSize}";
            CommentListVM res = _apiService.GetApiResponse<RootCommentVM>(url).GetAwaiter().GetResult().more.list;
            return PartialView(res);
        }

        public ActionResult Display()
        {
            return View();
        }

    }
}