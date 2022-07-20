using IRNA.Web.Services;
using IRNA.Web.Services.Interfaces;
using IRNA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IRNA.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService _accountService;
        public AccountController()
        {
            _accountService = new IRNA.Web.Services.Service();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        public ActionResult Login()
        {

            return View();
        }

        [Route("Verify")]
        [HttpPost]
        public ActionResult Verify(LoginVM login)
        {
            var phone = $"{login.CityCode.Remove(0, 1)}{login.Phone.Replace(" ",string.Empty).Remove(0, 1)}";
            var url = $"{Services.Settings.BaseUrl}iptv/irna/access/rest/v2/auth/sendSmsCode?phoneNumber={phone}";
            var res = new VerifyVM
            {
                Response = _accountService.GetApiResponse<ResponseVM>(url).GetAwaiter().GetResult(),
                Login = login
            };
            if (res.Response.code == (int)HttpStatusCode.OK)
            {
                return View(res);
            }
            else if (res.Response.code == (int)HttpStatusCode.ServiceUnavailable)
            {
                TempData["Verify"] = res.Response.localizedMessages.fa;
                return Redirect("/login");
            }
            else if (res.Response.code == (int)HttpStatusCode.GatewayTimeout)
            {
                TempData["Verify"] = res.Response.localizedMessages.fa;
                return Redirect("/login");
            }
            else if (res.Response.code == 436)
            {
                TempData["Verify"] = res.Response.localizedMessages.fa;
                return Redirect("/login");
            }
            else
            {
                TempData["Verify"] = "خطایی پیش آمده لطفا دوباره تلاش کنید";
                return Redirect("/login");
            }
        }

        [Route("VerifyAuth")]
        [HttpPost]
        public ActionResult VerifyAuth(string mobile, string confirm)
        {
            var phone = mobile.Replace(" ","");
            var url1 = $"{Services.Settings.BaseUrl}iptv/irna/access/rest/v2/auth/verifySmsCode?" +
           $"phoneNumber={phone}&verificationCode={confirm}";
            var res1 = _accountService.GetApiResponse<VerifySmsCodeVM>(url1).GetAwaiter().GetResult();
            if (res1.code == (int)HttpStatusCode.OK)
            { 

                var url2 = $"{Services.Settings.BaseUrl}iptv/irna/access/rest/v2/auth/registerBySms" +
                $"?email={res1.more.email}&name={res1.more.name}&family={res1.more.family}&" +
                $"phoneNumber={phone}&verificationCode={confirm}";
                var res2 = _accountService.GetApiResponse<ResponseVM>(url2).GetAwaiter().GetResult();
                TempData["Verify"] = res2.localizedMessages.fa;

                if (res2.code == (int)HttpStatusCode.OK)
                {
                    var url3 = $"{Services.Settings.BaseUrl}iptv/irna/access/rest/v2/auth/getRandom";
                    var res3 = _accountService.GetApiResponse<getRandomResponseVM>(url3).GetAwaiter().GetResult();
                    TempData["Verify"] = res3.localizedMessages.fa;

                    if (res3.code == (int)HttpStatusCode.OK)
                    {
                        var url4 = $"{Services.Settings.BaseUrl}iptv/irna/access/rest/v2/auth/loginByGet?" +
                        $"username={phone}&password={res3.more.random}";
                        var res4 = _accountService.GetApiResponse<LoginByGetResponseVM>(url4).GetAwaiter().GetResult();
                        TempData["Verify"] = res2.localizedMessages.fa;
                        var token = res4.more.token;
                        Response.Cookies.Add(Settings.CreateCookie(token));
                        return Redirect("/Profile");
                    }
                }
            }
            return Redirect("/Verify");
        }
         
        [Route("Profile")]
        public ActionResult Profile()
        {
            var cookie = Request.Cookies["Token"];
            if (cookie != null)
            {
                var token = cookie.Value;
                var url = $"{Settings.BaseUrl}iptv/irna/access/rest/v2/profiles/getProfile?token={token}";
                var res = _accountService.GetApiResponse<VerifySmsCodeVM>(url).GetAwaiter().GetResult();
                ;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies["Token"] != null)
            {
                var c = new HttpCookie("Token");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Remove("Token");
            }
            return Redirect("/");
        }

    }
}