using System;
using System.Data;
using Android.Database.Sqlite;
using System.Data.SqlClient;





namespace HMHY.Droid
{


    public static class LoginPage
    {
        public static bool getUserCredentials(string username)
        {
            bool privledge = false;
            DataTable table = new DataTable("UserCredentials");
            DataRow[] rows;
            rows = table.Select(username);
            if (rows != null)
            {
                Boolean.TryParse(rows[2].ToString(), out privledge);
            }
            return privledge;
        }

        public static UserEventInfo addNewGoal(string titleA, string descriptionA, DateTime startTimeA, DateTime endTimeA)
        {
            
            //TODO
            //Figure out how to access the database on a phone. This will be used instead of hmhy-global.
            // Open the connection for the query.
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase("hmhy-global.database.windows.net", null, DatabaseOpenFlags.OpenReadwrite);
            string query = @"INSERT INTO Goal
            Values(id, @title, @description, @startTime, @endTime, reminderId)";
            // Add the values passed in to a Content Vales
            Android.Content.ContentValues values = new Android.Content.ContentValues(5);
            values.Put("0", "0");
            values.Put("1", titleA);
            values.Put("2", descriptionA);
            values.Put("3", startTimeA.ToString());
            values.Put("4", endTimeA.ToString());
            // Execute the query to inset into the phone database.
            db.Insert(query, "Title, Description, StartTime, EndTime", values);
            // Add the goal as an event to the calendar.
            AndroidCalendar userCalendar = new AndroidCalendar();
            userCalendar.AddEvent("0", titleA, startTimeA, endTimeA,descriptionA);
            UserEventInfo info = new UserEventInfo();
            info.Id = "0";
            info.Title = titleA;
            info.StartDate = startTimeA;
            info.EndDate = endTimeA;

            return info;
        }

        public static UserReminderInfo addNewReminder(string message, DateTime remindTime)
        {
            // Open the connection for the query.
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase("hmhy-global.database.windows.net", null, DatabaseOpenFlags.OpenReadwrite);
            string query = @"INSERT INTO Reminder
            Values(id, @message, @startTime)";
            // Add the values passed in to a Content Vales
            Android.Content.ContentValues values = new Android.Content.ContentValues(3);
            values.Put("0", "0");
            values.Put("1", message);
            values.Put("2", remindTime.ToString());
            // Execute the query to inset into the phone database.
            db.Insert(query, "Id, Message, startTime", values);
            // Create the reminder.
            UserReminderInfo info = new UserReminderInfo();
            info.Title = message;
            info.StartTime = remindTime;
            info.Id = "0";
            return info;
        }
    }
}