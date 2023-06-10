using IRNA.Web.Services;
using IRNA.Web.Services.Interfaces;
using IRNA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


        public ActionResult Last(int page = 0, int pageSize = 10)
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
            if (res != null && res.vodResult == null)
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

        public ActionResult Comments(int id, int page = 0, int pageSize = 10)
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
            ViewBag.Cookie = null;
            ViewBag.LastPlayed = 0;
            try
            {
                HttpCookie cookie = Request.Cookies["Token"];

                ViewBag.ContentId = id;

                //string token = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiI5ODkzMzU0MzE3NjQiLCJleHAiOjE2ODYzOTI5MTQsImlhdCI6MTY4NjM3NDkxNH0.lifMnpeTi-HJ19vvCYHENX0IoUK2tvwg-aJRtOMrg8OJUvfZ6dSu_xyz7Zj6JiTPDIXqVfQSgdvMBOWiIi3xjg";
                if (cookie == null)
                {
                withouttoken:
                    string url = "";
                    //if (Request.Cookies["Token"] != null)
                    //{ 
                    //    HttpCookie cookie = Request.Cookies["Token"];
                    //    token = cookie.Value;
                    // url = $"{Settings.BaseUrl}iptv/irna/rtmpPlayAlbum?albumId={id}&lang=fa&token={token}";
                    //}
                    //else
                    //{
                    url = $"{Settings.BaseUrl}iptv/irna/rtmpPlayAlbum?albumId={id}&lang=fa";

                    var res = _apiService.GetApiResponse<RtmpPlayAlbumRoot>(url).GetAwaiter().GetResult();
                    if (!res?.list?.Any() ?? true)
                    {
                        return View("~/Views/Shared/NotFound.cshtml");
                    }
                    List<RtmpPlayAlbumList> videos = res.list;
                    ViewBag.ApiResponse = GlobalVariable.CurrentApiResponse;
                    return View(videos);
                }
                else
                {
                    string token;
                    token = cookie.Value;
                    ViewBag.Cookie = token;
                    string url = "";
                    url = $"{Settings.BaseUrl}iptv/irna/rtmpPlayAlbum?albumId={id}&lang=fa&token={token}";

                    var res = _apiService.GetApiResponse<RtmpPlayAlbumRoot>(url).GetAwaiter().GetResult();

                    if (!res?.list?.Any() ?? true)
                    {
                        return View("~/Views/Shared/NotFound.cshtml");
                    }


                    url = $"{Settings.BaseUrl}iptv/irna/rtmpPlayAlbum?albumId={id}&lang=fa";

                    res = _apiService.GetApiResponse<RtmpPlayAlbumRoot>(url).GetAwaiter().GetResult();
                    if (!res?.list?.Any() ?? true)
                    {
                        return View("~/Views/Shared/NotFound.cshtml");
                    }
                    var video2 = res.list;
                    ViewBag.ApiResponse = GlobalVariable.CurrentApiResponse;

                    var lastPlayed = _apiService.GetApiResponse<RootLastPlayedViewModel>($"{Settings.BaseUrl}" +
                        $"iptv/irna/v2/content/getLastPlay?diskId={id}&token={token}").GetAwaiter().GetResult();
                    ViewBag.LastPlayed = lastPlayed.more.time;

                    return View(video2);

                }
            }
            catch (Exception ex)
            {
                var url = $"{Settings.BaseUrl}iptv/irna/rtmpPlayAlbum?albumId={id}&lang=fa";

                var res = _apiService.GetApiResponse<RtmpPlayAlbumRoot>(url).GetAwaiter().GetResult();
                if (!res?.list?.Any() ?? true)
                {
                    return View("~/Views/Shared/NotFound.cshtml");
                }
                List<RtmpPlayAlbumList> videos = res.list;
                ViewBag.ApiResponse = GlobalVariable.CurrentApiResponse;
                return View(videos);
            }
        }

        [HttpPost]
        [Route("PostLastPlayed")]
        public ActionResult PostLastPlayed(int id, double currentTime)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Token"];
                //var token = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiI5ODkzMzU0MzE3NjQiLCJleHAiOjE2ODYzOTI5MTQsImlhdCI6MTY4NjM3NDkxNH0.lifMnpeTi-HJ19vvCYHENX0IoUK2tvwg-aJRtOMrg8OJUvfZ6dSu_xyz7Zj6JiTPDIXqVfQSgdvMBOWiIi3xjg";
                var token = cookie.Value;
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, $"{Settings.BaseUrl}iptv/irna/v2/content/saveLastPlay?diskId={id}" +
                    $"&token={token}&milliseconds={currentTime}");
                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("Cookie", "JSESSIONID=3A5D08B1D75782A47B9A98ED25E25E1E");
                var content = new StringContent(string.Empty);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = content;
                var response = client.SendAsync(request).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                return Json(new { result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult() });
            }
            catch (Exception)
            {
                return Json(new { result = ""});
            }
        }




        [Route("Channel")]
        public ActionResult Channel()
        {
            RtmpPlayAlbumList video = new RtmpPlayAlbumList();

            var url = $"{Settings.BaseUrl}iptv/irna/api/v2/channels/open?radio=false&lang=fa";

            ChannelRootVM res = _apiService.GetApiResponse<ChannelRootVM>(url).GetAwaiter().GetResult();

            return View(res);
        }

        [Route("Live")]
        public ActionResult Live(long id)
        {
            RtmpPlayAlbumList video = new RtmpPlayAlbumList();

            var url = $"{Settings.BaseUrl}iptv/irna/api/v2/channels/open?radio=false&lang=fa";

            url = $"{Settings.BaseUrl}iptv/irna/api/v1/stream/open?id={id}";

            StreamRoot streamRes = _apiService.GetApiResponse<StreamRoot>(url).GetAwaiter().GetResult();


            return View(streamRes);
        }

        [HttpGet]
        [Route("Content/LikePost/{id}/{stat}/{mobile}")]
        public JsonResult LikePost(int id, bool stat, string mobile)
        {
            var url = $"{Settings.BaseUrl}iptv/irna/v2/content/like?username={mobile}&name={mobile}&dislike={!stat}&value=true&diskId={id}";
            var res = _apiService.GetApiResponse<object>(url).GetAwaiter().GetResult();
            return Json(new { result = res });
        }



        [HttpGet]
        [Route("Content/Played")]
        public ActionResult Played()
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Token"];

                if (cookie == null)
                {
                    var url = $"{Settings.BaseUrl}iptv/irna/v2/sessions/played?page=0&pageSize=10";
                    var played_result = _apiService.GetApiResponse<RootPlayedViewModel>(url).GetAwaiter().GetResult();

                    var last_result_url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                    $"?lang=fa&page=0&pageSize=100&ids={played_result.more.result.list.FirstOrDefault()}";

                    var last_result = _apiService.GetApiResponse<ContentResponseVM>(last_result_url).GetAwaiter().GetResult();

                    return View(last_result);
                }
                else
                {
                    var url = $"{Settings.BaseUrl}iptv/irna/v2/sessions/played?page=0&pageSize=10&token={cookie.Value}";
                    var played_result = _apiService.GetApiResponse<RootPlayedViewModel>(url).GetAwaiter().GetResult();

                    var last_result_url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                    $"?lang=fa&page=0&pageSize=100&ids={played_result.more.result.list.FirstOrDefault()}";

                    var last_result = _apiService.GetApiResponse<ContentResponseVM>(last_result_url).GetAwaiter().GetResult();

                    return View(last_result);
                }
            }
            catch (Exception)
            {
                var last_result_url = $"{Settings.BaseUrl}iptv/irna/v2/content/last" +
                $"?lang=fa&page=0&pageSize=100";

                var last_result = _apiService.GetApiResponse<ContentResponseVM>(last_result_url).GetAwaiter().GetResult();
                last_result.list = last_result.list.Take(new Random().Next(3, 7)).ToList();
                return View(last_result);
            }
        }



    }
}