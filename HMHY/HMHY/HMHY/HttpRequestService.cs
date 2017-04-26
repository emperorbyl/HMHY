using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HMHY
{ 
    class HttpRequestService
    {
        public HttpClient Client;
        Core core;
        public HttpRequestService()
        {
            core = new Core();
            Client = new HttpClient();
            Client.BaseAddress = core.ApiLocation;
        }

        /// <summary>
        /// Creates a new http request message.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public HttpWebRequest MakeRequest(string resource, string method)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(resource));
            req.ContentType = "application/json";
            req.Method = method;

            return req;
        }
    }
}
