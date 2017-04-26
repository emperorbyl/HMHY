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
        ApiSync syncService;
        Core core;
        public SyncService()
        {
            syncService = new ApiSync();
            core = new Core();
        }


        // Sync dbs on startup.
        public override void OnCreate()
        {
            try
            {
                // Check for local changes
                List<DbGoal> phGoals = new List<DbGoal>();
                phGoals.Add(new DbGoal { deadline = Convert.ToDateTime("04/25/2017"), description = "test", id = 1, reminderId = 0, startDate = DateTime.Now, title = "test1", Type = DbGoal.TYPE.breaking, TypeId = 0 });
                List<DbGoal> dbGoals = syncService.GetTable<DbGoal>(core.GoalApiGetRequest);

                // Check for remote changes

                // Compare changes 

            }
            catch(Exception e)
            {
                var message = e.Message;
                // log error to log
            }
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }    
}