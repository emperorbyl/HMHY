using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft;
using HMHY;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Accounts;
using HMHY;
namespace HMHY.Droid
{
    [Service]
    class SyncService : Service
    {
       

        public SyncService()
        {

        }


        // Sync dbs on startup.
        public override void OnCreate()
        {
            // Check for local changes
            //List<Goal> goals = LoginPage.viewGoals("test");
            // Check for remote changes

            // Compare changes 
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }    
}