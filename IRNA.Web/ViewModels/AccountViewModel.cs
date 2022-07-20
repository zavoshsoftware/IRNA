using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRNA.Web.ViewModels
{
    public class LoginVM
    {
        public string Phone { get; set; }
        public string CityCode { get; set; }
        public string Resend { get; set; }
    }


    public partial class SendSmsCodeRequestVM
    {
        public string phoneNumber { get; set; }
        public string Language { get; set; }
        public string resend { get; set; } 
    }

    public partial class VerifyVM
    {
        public LoginVM Login { get; set; }
        public ResponseVM Response { get; set; }
    }

    public partial class VerifySmsCodeVM:BaseResponseVM
    {
        public VerifySmsCodeMoreVM more { get; set; }
    }

    public class VerifySmsCodeMoreVM
    {
        public string email { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string telephone { get; set; }
        public string verificationCode { get; set; }
        public string language { get; set; }
    }

    public partial class getRandomResponseVM : BaseResponseVM
    {
        public getRandommore more { get; set; }
    }
    public partial class getRandommore
    {
        public string random { get; set; }
        public string sessionId { get; set; }
    }

    public partial class LoginByGetResponseVM:BaseResponseVM
    {
        public LoginByGetMoreVM more { get; set; }
    }

    public class LoginByGetMoreVM
    {
        public List<string> groups { get; set; }
        public List<object> services { get; set; }
        public Modules modules { get; set; }
        public string token { get; set; }
    }
    public class Modules
    {
    }


    public partial class RegisterVM
    {

        public string email { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string telephone { get; set; } 
    }

}