using System;

using Android.App;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;

namespace HMHY.Droid
{
	[Activity (Label = "HMHY.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

        SyncService syncService;

		protected override void OnCreate (Bundle bundle)
		{


			base.OnCreate (bundle);

            syncService = new SyncService();
            StartService(new Intent(this, syncService.GetType()));

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.AddGoal);
            // Get all of the information entered by the user.
            EditText titleText = FindViewById<EditText>(Resource.Id.goalTitleText);
            EditText descriptionText = FindViewById<EditText>(Resource.Id.goalDescriptionText);
            EditText startDate = FindViewById<EditText>(Resource.Id.startDateDate);
            EditText endDate = FindViewById<EditText>(Resource.Id.endDateDate);
            // Convert the text to DateTimes.
            DateTime actualStartDate = DateTime.Now;
            DateTime.TryParse(startDate.ToString(), out actualStartDate);
            DateTime actualEndDate = DateTime.Now;
            DateTime.TryParse(endDate.ToString(), out actualEndDate);
			button.Click += (object sender, EventArgs e) => {
                var info = LoginPage.addNewGoal(titleText.ToString(), descriptionText.ToString(), actualStartDate, actualEndDate);
                CreateEvent();
			};

           
        }

        public void CreateEvent()
        {

            AndroidCalendar userCalendar = new AndroidCalendar();

            string[] sourceColumns = {
                 CalendarContract.Events.InterfaceConsts.Title,
                 CalendarContract.Events.InterfaceConsts.Dtstart };

            int[] targetResources = {
                Resource.Id.goalTitle,
                  Resource.Id.startDate };

            var adapter = new SimpleCursorAdapter(this, Resource.Layout.Main, userCalendar.GetEventIcursor(userCalendar.GetEventsUri(), userCalendar.GetUserCalendarEvents(), 0), sourceColumns, targetResources);

            IListAdapter ListAdapter = adapter;
        }

        private void SyncDatabase()
        {
            /* Check for recent user password change. If no user is stored in the local db, prompt login
            *
            * Check for recent goal changes to the users goal since last login
            * 
            * Update other changes
            * 
            * Changes on the phone trump local changes
            */
        }
	}
}


