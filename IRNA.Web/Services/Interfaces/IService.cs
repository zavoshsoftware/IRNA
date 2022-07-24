using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRNA.Web.Services.Interfaces
{
   public interface IService
    {
        Task<T> GetApiResponse<T>(string url);
        
         //Task<T> GetApiResponse2<T>(string url);

          bool IsMobileDevice(string userAgent);

       
    }
}
