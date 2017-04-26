using System;

using Android.App;
using Android.Content;
using Android.Net;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Database;

namespace HMHY.Droid
{
    [Activity(Label = "HMHY.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView listView;
        int count = 1;
        ICursor cursor;
        SimpleCursorAdapter adapter;
        static string phoneConnection = "";
        protected override void OnCreate(Bundle bundle)
        {


            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.AddGoal);
            string[] projection = new string[] { DBContentViewer.InterfaceConsts.Id, DBContentViewer.InterfaceConsts.Name };
            string[] fromColumns = new string[] { DBContentViewer.InterfaceConsts.Name };
            int[] toControlIds = new int[] { Android.Resource.Id.Text1 };


            cursor = ManagedQuery(DBContentViewer.CONTENT_URI, projection, null, null, null);
            var loader = new CursorLoader(this,
                DBContentViewer.CONTENT_URI, projection, null, null, null);
            cursor = (ICursor)loader.LoadInBackground();

            // create a SimpleCursorAdapter
            //adapter = new SimpleCursorAdapter(this, Android.Resource.Layout.SimpleListItem1, cursor,
            //  fromColumns, toControlIds);

            // listView.Adapter = adapter;
            button.Click += (object sender, EventArgs e) => {

                try
                {

                    // Create the necessary query for the gui.
                    string[] project = new string[] { "name" };
                    // This returns a null path right now because there is no 0 id.
                    var uri = Android.Net.Uri.WithAppendedPath(DBContentViewer.CONTENT_URI, DBContentViewer.InterfaceConsts.Id);
                    phoneConnection = uri.Path;

                    /*ICursor goalCursor = ContentResolver.Query(uri, project, null, new string[] {DBContentViewer.InterfaceConsts.Id, null);

                    string text = "";
                    if (goalCursor.MoveToFirst())
                    {
                        text = goalCursor.GetInt(0) + " " + goalCursor.GetString(1);
                        Android.Widget.Toast.MakeText(this, text, Android.Widget.ToastLength.Short).Show();
                    }

                    goalCursor.Close();*/
                    // Get all of the information entered by the user.
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
                    //var info = LoginPage.addNewGoal(titleString, desString, actualStartDate, actualEndDate, phoneConnection);
                    //CreateEvent();
                    string newGoal = titleText.Text.ToString() + ", " + descriptionText.Text.ToString() + ", " + actualStartDate + ", " + actualEndDate;
                    TextView goalView = FindViewById<TextView>(Resource.Id.textView2);
                    goalView.SetText("", TextView.BufferType.Normal);
                    goalView.Append(newGoal);
                    //goalView.Append(pullGoals());
                }
                catch (Exception ex)
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
        public string pullGoals()
        {
            string user = "emperorbyl";
            string allGoals = "";
            System.Collections.Generic.List<string> goalList = LoginPage.viewGoals(user, phoneConnection);
            foreach (string goal in goalList)
                allGoals += goal;
            return allGoals;
        }
    }
}


