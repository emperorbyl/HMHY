using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace HMHY
{ 
    class HttpRequestService
    {
        public RestClient Client;
        Core core;
        public HttpRequestService()
        {
            core = new Core();
            Client = new RestClient();
            Client.BaseUrl = core.ApiLocation;
        }

        public RestRequest MakeConnection(string path, Method connectionType)
        {
            RestRequest request;
            string result = string.Empty;
            try
            {          
                request = new RestRequest(path);
                request.AddHeader("Accept", "Application/xml");
                request.Method = connectionType;
            }
            catch (Exception e) { return null; }

            return request;
        }
    }
}
