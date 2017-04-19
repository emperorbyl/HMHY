using System;
using System.Data;
using Android.Database.Sqlite;
using System.Data.SqlClient;
using System.Collections.Generic;
using Windows.Storage;
using Xamarin.Forms;






namespace HMHY.Droid
{


    public static class LoginPage
    {
        static string connection = "Data Source=database.db";
        static string dbConnection;

        static string phoneConnection = DependencyService.Get<PhoneDB>().getLocalFilePath("SQLite.db3");
        static string local = "../GitHub/HMHY/HMHY/";
        //static string appConnection = Windows.ApplicationModel.Package.Current.InstalledLocation.ToString();

        static LoginPage() { dbConnection = "hmhy-global.database.windows.net"; }

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
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase(phoneConnection, null, DatabaseOpenFlags.OpenReadwrite);
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
            db.Insert(query, "id, title, goalDescription, StartTime, EndTime", values);
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
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase(phoneConnection, null, DatabaseOpenFlags.OpenReadwrite);
            string query = @"INSERT INTO Reminder
            Values(id, @message, @startTime)";
            // Add the values passed in to a Content Vales
            Android.Content.ContentValues values = new Android.Content.ContentValues(3);
            values.Put("0", "0");
            values.Put("1", message);
            values.Put("2", remindTime.ToString());
            // Execute the query to inset into the phone database.
            db.Insert(query, "id, messageText, reminderTime", values);
            // Create the reminder.
            UserReminderInfo info = new UserReminderInfo();
            info.Title = message;
            info.StartTime = remindTime;
            info.Id = "0";
            return info;
        }

        public static void addNewNote(string title, int userID, string body)
        {
            // Open the connection for the query.
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase(phoneConnection, null, DatabaseOpenFlags.OpenReadwrite);
            string query = @"INSERT INTO Note
            Values(id, @title, @userID, @body)";
            // Add the values passed in to a Content Vales
            Android.Content.ContentValues values = new Android.Content.ContentValues(4);
            values.Put("0", "0");
            values.Put("1", title);
            values.Put("2", userID.ToString());
            values.Put("3", body);
            // Execute the query to inset into the phone database.
            db.Insert(query, "id, title, userId, body", values);
        }

        public static List<string> viewGoals(string userName)
        {
            List<string> allDaGoals = new List<string>();
            bool next = false;
            // Open the connection for the query.
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase(phoneConnection, null, DatabaseOpenFlags.OpenReadwrite);
            string query = @"SELECT gl.title, gl.goalDescription
            FROM MainUser us
            JOIN Goal gl ON gl.id = us.goalId
            WHERE us.name LIKE @userName";
            string []values;
            values = new string[1];
            values[0] = userName;
            // Execute the query.
            Android.Database.ICursor curse = db.RawQuery(query, values);
            // Loop throughthe results of the query to get all of the goals.
            while (!curse.IsLast && next)
            {
                string title = curse.GetString(1);
                string desc = curse.GetString(2);
                string goal = title + ", " + desc;
                // Add the goals to a list to be returned.
                allDaGoals.Add(goal);
                next = curse.MoveToNext();
            }
            return allDaGoals;
        }

        public static List<string> viewNotes (string goalName)
        {
            List<string> allDaNotes = new List<string>();
            bool next = false;
            // Open the connection for the query.
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase(phoneConnection, null, DatabaseOpenFlags.OpenReadwrite);
            string query = @"SELECT nt.title, nt.body
            FROM Goal gl
            JOIN Note nt ON nt.id = us.noteId
            WHERE gl.title LIKE @goalName";
            string[] values;
            values = new string[1];
            values[0] = goalName;
            // Execute the query.
            Android.Database.ICursor curse = db.RawQuery(query, values);
            // Loop throughthe results of the query to get all of the notes.
            while (!curse.IsLast && next)
            {
                string title = curse.GetString(1);
                string body = curse.GetString(3);
                string note = title + ", " + body;
                // Add the notes to a list to be returned.
                allDaNotes.Add(note);
                next = curse.MoveToNext();
            }
            return allDaNotes;
        }

        public static void addNewUser(string userName, bool priv)
        {
            // Open the connection for the query.
            SQLiteDatabase db = SQLiteDatabase.OpenDatabase(phoneConnection, null, DatabaseOpenFlags.OpenReadwrite);
            string query = @"INSERT INTO Goal
            Values(id, @userName, @privlage, goalId, noteId, calendarId, userGroupId)";
            // Add the values passed in to a Content Vales
            Android.Content.ContentValues values = new Android.Content.ContentValues(7);
            values.Put("0", "0");
            values.Put("1", userName);
            values.Put("2", priv.ToString());
            values.Put("3", "0");
            values.Put("4", "0");
            values.Put("5", "0");
            values.Put("6", "0");
            // Execute the query to inset into the phone database.
            db.Insert(query, "id, userName, privelage, goalId, noteId, calendarId, userGroupId", values);
        }
    }
}