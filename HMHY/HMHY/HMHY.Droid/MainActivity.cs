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

		protected override void OnCreate (Bundle bundle)
		{


			base.OnCreate (bundle);
            Xamarin.Forms.Forms.Init(this, bundle);  

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.AddGoal);
            // Get all of the information entered by the user.
            
            button.Click += (object sender, EventArgs e) => {
                
                try
                {
                    EditText titleText = FindViewById<EditText>(Resource.Id.goalTitleText);
                    EditText descriptionText = FindViewById<EditText>(Resource.Id.goalDescriptionText);
                    EditText startDate = FindViewById<EditText>(Resource.Id.startDateDate);
                    EditText endDate = FindViewById<EditText>(Resource.Id.endDateDate);
                    // Convert the text to DateTimes.
                    DateTime actualStartDate = DateTime.Now;
                    DateTime.TryParse(startDate.Text.ToString(), out actualStartDate);
                    DateTime actualEndDate = DateTime.Now;
                    DateTime.TryParse(endDate.Text.ToString(), out actualEndDate);
                    string titleString = titleText.Text.ToString();
                    string desString = descriptionText.Text.ToString();
                    //var info = LoginPage.addNewGoal(titleString, desString, actualStartDate, actualEndDate);
                    //CreateEvent();
                    string newGoal = titleText.Text.ToString() + ", " + descriptionText.Text.ToString() + ", " + actualStartDate + ", " + actualEndDate;
                    TextView goalView = FindViewById<TextView>(Resource.Id.textView2);
                    goalView.Append(newGoal);
                    //goalView.Append(pullGoals());
                }
                catch(Exception ex)
                {
                    string message = ex.InnerException.Message;
                }
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

        public string pullGoals()
        {
            string user = "emperorbyl";
            string allGoals = "";
            System.Collections.Generic.List<string> goalList = LoginPage.viewGoals(user);
            foreach (string goal in goalList)
                allGoals += goal;
            return allGoals;
        }
	}
}


