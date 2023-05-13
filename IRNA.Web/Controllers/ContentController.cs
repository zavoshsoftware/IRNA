using IRNA.Web.Services;
using IRNA.Web.Services.Interfaces;
using IRNA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using static IRNA.Web.ViewModels.LiveViewModel;

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

            RootContentDetailsVM res = _apiService.GetApiResponse<RootContentDetailsVM>(url).GetAwaiter().GetResult();
            if (res!=null && res.vodResult==null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }


             url = $"{Settings.BaseUrl}iptv/irna/v2/content/listLikesOfDisk?diskId={id}&page=0&pageSize=10000";
            LikeRootVM likeres = _apiService.GetApiResponse<LikeRootVM>(url).GetAwaiter().GetResult();

            res.LikeRoot = likeres;
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
        [Route("Content/Display")] 
        [HttpPost]
        public ActionResult Display(int id)
        {
            HttpCookie cookie = Request.Cookies["Token"];
            var url = $"{Settings.BaseUrl}iptv/irna/rtmpPlayAlbum?albumId={id}&quality=&lang=fa&token={cookie.Value}";

            var res = _apiService.GetApiResponse<RtmpPlayAlbumRoot>(url).GetAwaiter().GetResult();
            
            if (!res?.list?.Any()??true)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            RtmpPlayAlbumList video = res.list.LastOrDefault();
            return View(video);
        }

        [Route("Live")]
        public ActionResult Live()
        {
            RtmpPlayAlbumList video =new RtmpPlayAlbumList();

            var url = $"{Settings.BaseUrl}iptv/irna/api/v2/channels/open?radio=false&lang=fa";

            var res = _apiService.GetApiResponse<ChannelRootVM>(url).GetAwaiter().GetResult();

            url = $"{Settings.BaseUrl}iptv/irna/api/v1/stream/open?id={res.data.FirstOrDefault().id}";

            StreamRoot streamRes = _apiService.GetApiResponse<StreamRoot>(url).GetAwaiter().GetResult();


            return View(streamRes);
        }
         
        [HttpGet]
        [Route("Content/LikePost/{id}/{stat}/{mobile}")]
        public JsonResult LikePost(int id,bool stat,string mobile)
        { 
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/like?username={mobile}&name={mobile}&dislike={!stat}&value=true&diskId={id}";
            var res = _apiService.GetApiResponse<object>(url).GetAwaiter().GetResult();
            return Json(new { result = res});
        }



        [HttpGet]
        [Route("Content/Played")]
        public ActionResult Played()
        {
            HttpCookie cookie = Request.Cookies["Token"];
            var url = $"{Settings.BaseUrl}iptv/irna/v2/sessions/played?page=0&pageSize=10&token={cookie.Value}";
            var played_result = _apiService.GetApiResponse<RootPlayedViewModel>(url).GetAwaiter().GetResult();

            var last_result_url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
            $"?lang=fa&page=0&pageSize=100&ids={played_result.more.result.list.FirstOrDefault()}";

            var last_result = _apiService.GetApiResponse<ContentResponseVM>(last_result_url).GetAwaiter().GetResult();

            return View(last_result);
        }



    }
}