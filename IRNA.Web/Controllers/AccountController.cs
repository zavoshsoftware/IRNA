using IRNA.Web.Services;
using IRNA.Web.Services.Interfaces;
using IRNA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace IRNA.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService _accountService;
        public AccountController()
        {
            _accountService = new Service();
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
            //var phone = $"{login.CityCode.Remove(0, 1)}{login.Phone.Replace(" ",string.Empty).Remove(0, 1)}";
            var phone = login.Phone.StartsWith("0") ? login.Phone.Trim().Replace(" ", string.Empty).Remove(0, 1) : login.Phone.Trim();
            var url = $"{Settings.BaseUrl}iptv/irna/access/rest/v2/auth/sendSmsCode?phoneNumber={phone}";
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
            var phone = mobile.Replace(" ", "");
            var url1 = $"{Settings.BaseUrl}iptv/irna/access/rest/v2/auth/verifySmsCode?" +
           $"phoneNumber={phone}&verificationCode={confirm}";
            var res1 = _accountService.GetApiResponse<VerifySmsCodeDtoRoot>(url1).GetAwaiter().GetResult();
            TempData["Err"] += Helper.StringConcatenator(" _ ", url1, GlobalVariable.CurrentApiResponse, nameof(res1));
            if (res1.code == (int)HttpStatusCode.OK)
            {
                var url2 = $"{Settings.BaseUrl}iptv/irna/access/rest/v2/auth/registerBySms";
                //$"?" +
                //$"email={res1.more.result.email}&name={res1.more.result.name}&family={res1.more.result.family}&" +
                //$"phoneNumber={phone}&verificationCode={confirm}").Replace("&", "&amp;");

                var res2 = _accountService.GetApiResponse<ResponseVM>(url2,new Dictionary<string, object> {
                    { "email", res1.more.result.email },
                    { "name", res1.more.result.name },
                    { "family", res1.more.result.family },
                    { "phoneNumber", mobile },
                    { "verificationCode",confirm } 
                    }).GetAwaiter().GetResult();
                TempData["Verify"] = res2.localizedMessages.fa; 
                TempData["Err"] += Helper.StringConcatenator(" _ ", res1.more.result.email, res1.more.result.name, res1.more.result.family, res1.more.result.telephone, res1.more.result.verificationCode, GlobalVariable.CurrentApiResponse, nameof(res2));
                if (res2.code == (int)HttpStatusCode.OK)
                {
                    var url3 = $"{Settings.BaseUrl}iptv/irna/access/rest/v2/auth/getRandom";
                    var res3 = _accountService.GetApiResponse<getRandomResponseVM>(url3).GetAwaiter().GetResult();
                    TempData["Verify"] = res3.localizedMessages.fa;
                    TempData["Err"] += res3.localizedMessages.fa + nameof(res3);

                    if (res3.code == (int)HttpStatusCode.OK)
                    {
                        var hashedPassword = Security.ComputeSHA256(Security.CreateMD5(confirm) + res3.more.random + "gsfb97FGD^%R%$");
                        var url4 = $"{Settings.BaseUrl}iptv/irna/access/rest/v2/auth/loginByGet?" +
                     $"username={phone}&" +
                     $"domain=shared&" +
                     $"password={hashedPassword}&" +
                     $"serverSelfIds=&" +
                     $"sessionId={res3.more.sessionId}";
                        //var url4 = $"{Settings.BaseUrl}iptv/irna/access/rest/v2/auth/loginByGet?" +
                        //$"username={phone}&password={res3.more.random}";
                        var res4 = _accountService.GetApiResponse<LoginByGetResponseVM>(url4).GetAwaiter().GetResult();
                        TempData["Verify"] = res2.localizedMessages.fa;
                        TempData["Err"] += res4.localizedMessages.fa + nameof(res4);

                        var token = res4.more.token;
                        Response.Cookies.Add(Settings.CreateCookie(token));
                       
                        return Redirect("/");
                    }
                }
            }
            return Redirect("/login");
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
            }
            return View();
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies["Token"] != null)
            {
                string token = null;
                Response.Cookies.Add(Settings.CreateCookie(token));
            }
            return Redirect("/");
        }

    }
}