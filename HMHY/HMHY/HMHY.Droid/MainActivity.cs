using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HMHY.Droid
{
	[Activity (Label = "HMHY.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

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
                LoginPage.addNewGoal(titleText.ToString(), descriptionText.ToString(), actualStartDate, actualEndDate);
			};
		}
	}
}


