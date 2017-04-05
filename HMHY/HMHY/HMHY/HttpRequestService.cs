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
using Windows.Data.Xml.Dom;
using Windows.Data.Xml;
using Windows.Data.Xml.Xsl;

using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace HMHY
{
    public enum CallType { GET, PUT, POST};
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

        public RestRequest MakeConnection(string path, CallType connectionType)
        {
            RestRequest request;
            string result = string.Empty;
            try
            {          
                request = new RestRequest("MainUser");
                request.AddHeader("Accept", "Application/xml");
            }
            catch (Exception e) { return null; }

            return request;
        }
    }
}
