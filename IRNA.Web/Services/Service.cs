using IRNA.Web.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IRNA.Web.Services
{
    public class Service: IService
    {
        private  string[] mobileDevices = new string[] {"iphone","ppc",
                                                      "windows ce","blackberry",
                                                      "opera mini","mobile","palm",
                                                      "portable","opera mobi" };
        public  async Task<T> GetApiResponse<T>(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request); 
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
        }


        //public  async Task<T> GetApiResponse2<T>(string url)
        //{
        //    var client = new RestClient(url);
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = client.Execute(request);
        //    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomResponseViewModel>(response.Content);
        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result.Extra.ToString());
        //}

        public async Task<T> PostApiResponse<T>(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
        }


        public bool IsMobileDevice( string userAgent) => mobileDevices.Any(x => userAgent.ToLower().Contains(x));


    }
}