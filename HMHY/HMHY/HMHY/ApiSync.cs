using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.Serializers;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HMHY
{
    /// <summary>
    /// This class handles syncing the local phone db to the server db. 
    /// </summary>
    public class ApiSync
    {
        public Core core;
        public ApiSync() { core = new Core(); }

        public List<T> GetTable<T>(string resource)
        {
            try
            {
                var connection = new HttpRequestService();
                var queryString = connection.Client.BaseAddress + resource;
                var response = connection.Client.GetAsync(queryString);
                var jsonObj = response.Result.Content.ReadAsStringAsync();

                var deserObj = JsonConvert.DeserializeObject<List<T>>(jsonObj.Result);

                return deserObj;
               
            }
            catch(Exception e)
            {

                throw;
            }
        }

        //public T GetRow<T>(string connection)
        //{
        //    try
        //    {
        //        var con = new HttpRequestService();
        //        var request = con.MakeConnection(connection, Method.GET);
        //        var response = con.Client.Execute<T>(request);
        //        T row = response.Result.Data;
        //        return row;
        //    }
        //    catch(Exception e) { throw; }
        //}

        //public bool UpdateRow<T>(T row, string connection)
        //{
        //    try
        //    {
        //        var con = new HttpRequestService();
        //        var request = con.MakeConnection(connection, Method.PUT);
        //        var ser = new XmlSerializer(typeof(T));
        //        var strWtr = new StringWriter();
        //        Task<IRestResponse> response;
        //        using (XmlWriter writer = XmlWriter.Create(strWtr))
        //        {
        //            ser.Serialize(writer, row);
        //            var xml = strWtr.ToString();
        //            request.AddXmlBody(xml);
        //            response = con.Client.Execute(request);
        //        }

        //        if (!response.IsCompleted || response.IsCanceled || response.IsFaulted)
        //        {
        //            return false;
        //        }

        //        return true;
        //    }
        //    catch(Exception e) { return false; }
        //}

        //public bool AddRow<T>(T row, string connection)
        //{
        //    try
        //    {
        //        var con = new HttpRequestService();
        //        var request = con.MakeConnection(connection, Method.POST);
        //        var ser = new XmlSerializer(typeof(T));
        //        var strWtr = new StringWriter();
        //        Task<IRestResponse> response;
        //        using (XmlWriter writer = XmlWriter.Create(strWtr))
        //        {
        //            ser.Serialize(writer, row);
        //            var xml = strWtr.ToString();
        //            request.AddXmlBody(xml);
        //            response = con.Client.Execute(request);
        //        }

        //        if (!response.IsCompleted || response.IsCanceled || response.IsFaulted)
        //        {
        //            return false;
        //        }

        //        return true;
        //    }
        //    catch(Exception e) { return false; }
        //}
    }
}
