using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMHY
{
    /// <summary>
    /// This class handles syncing the local phone db to the server db. 
    /// </summary>
    class ApiSync
    {
        public Core core;
        public ApiSync() { core = new Core(); }

        public void SyncUsers()
        {
            
            
            
        }

        public void AddUser()
        {

        }

        public MainUser GetUsers()
        {
            var con = new HttpRequestService();
            var request = con.MakeConnection(core.MainUserApiGetRequest, CallType.GET);
            var response = con.Client.Execute<MainUser>(request);
            MainUser user = response.Result.Data;
            return user;
        }

        public MainUser GetUser()
        {
            var con = new HttpRequestService();
            var request = con.MakeConnection(core.MainUserApiGetRequest, CallType.GET);
            var response = con.Client.Execute<MainUser>(request);
            MainUser user = response.Result.Data;
            return user;
        }

        public void UpdateUser()
        {

        }

        




    }
}
