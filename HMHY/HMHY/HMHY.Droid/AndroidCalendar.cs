using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace HMHY.Droid
{
    /// <summary>
    /// This class is used to get data from the database and push it to the users calendar.
    /// </summary>
    class AndroidCalendar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AndroidCalendar()
        {
             

        }

        /// <summary>
        /// Gets the calendars uniform resource identifier. 
        /// </summary>
        /// <returns> The android uri object. </returns>
        public Android.Net.Uri GetUserCalendarUri()
        {
            return CalendarContract.Calendars.ContentUri;
        }

        /// <summary>
        /// Gets an object that consists of the id, calendar name, and account name.
        /// </summary>
        /// <returns> An object containing the user's calendar info. </returns>
        public UserCalendarInfo GetUserCalendarInfo()
        {
            var userCalendar = new UserCalendarInfo();
            userCalendar.Id = CalendarContract.Calendars.InterfaceConsts.Id;
            userCalendar.DisplayName = CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName;
            userCalendar.AccountName = CalendarContract.Calendars.InterfaceConsts.AccountName;

            return userCalendar;
        }

        /// <summary>
        /// Gets the ICursor for a calendar. Enables read/write access to the database.
        /// </summary>
        /// <param name="uri"> The current Uniform Resource Locator. </param>
        /// <param name="info"> The current user's calendar info. </param>
        /// <returns></returns>
        public ICursor GetCalendarIcursor(Android.Net.Uri uri, UserCalendarInfo info)
        {
            string[] calendarInfo = {
                info.Id,
                info.DisplayName,
                info.AccountName
            };

            return Application.Context.ContentResolver.Query(uri,calendarInfo , null, null, null);
        }

        /// <summary>
        /// Gets the uniform resource locator of the users events. 
        /// </summary>
        /// <returns></returns>
        public Android.Net.Uri GetEventsUri()
        {
            return CalendarContract.Events.ContentUri;
        }

        /// <summary>
        /// Gets the uniform resource locator of the users events. 
        /// </summary>
        /// <returns></returns>
        public Android.Net.Uri GetRemindersUri()
        {
            return CalendarContract.Reminders.ContentUri;
        }

        /// <summary>
        /// Gets the events from the users calendar.
        /// </summary>
        /// <param name="calId"></param>
        public UserEventInfo GetUserCalendarEvents()
        {      
            var userEvents = new UserEventInfo();
            userEvents.Id = CalendarContract.Events.InterfaceConsts.Id;
            userEvents.Title = CalendarContract.Events.InterfaceConsts.Title;
            DateTime startDate;
            if(DateTime.TryParse(CalendarContract.Events.InterfaceConsts.Dtstart, out startDate))
                userEvents.StartDate = startDate;

            DateTime endDate;
            if (DateTime.TryParse(CalendarContract.Events.InterfaceConsts.Dtend, out endDate))
                userEvents.EndDate = endDate;
            
            return userEvents;
        }

        /// <summary>
        /// Gets the cursor for user events.
        /// </summary>
        /// <param name="uri"> The uniform resource locator of the event. </param>
        /// <param name="info"> The event info. </param>
        /// <param name="calId"> The calendar id of where the event is located. </param>
        /// <returns></returns>
        public ICursor GetEventIcursor(Android.Net.Uri uri, UserEventInfo userInfo, int calId)
        {
            var milliseconds = userInfo.StartDate.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            string[] info =
            {
                userInfo.Id,
                userInfo.Title,
                milliseconds.ToString()
            };
            return Application.Context.ContentResolver.Query(uri, info, String.Format("calendar_id={0}", calId), null, "dtstart ASC");
        }

        /// <summary>
        /// Gets the info for user reminders.
        /// </summary>
        /// <returns></returns>
        public UserReminderInfo GetUserCalendarReminders()
        {
            var userReminders = new UserReminderInfo();
            userReminders.Id = CalendarContract.Reminders.InterfaceConsts.Id;
            userReminders.EventId = CalendarContract.Reminders.InterfaceConsts.EventId;

            // TODO Set these to try parse methods. 
            //userReminders.StartTime = Convert.ToDateTime(CalendarContract.Reminders.InterfaceConsts.Dtstart);
            //userReminders.EndTime = Convert.ToDateTime(CalendarContract.Reminders.InterfaceConsts.Dtend);
            userReminders.Description = CalendarContract.Reminders.InterfaceConsts.Description;
            userReminders.Count = CalendarContract.Reminders.InterfaceConsts.Count;
            userReminders.Title = CalendarContract.Reminders.InterfaceConsts.Title;
            userReminders.HasAlarm = CalendarContract.Reminders.InterfaceConsts.HasAlarm;

            return userReminders;
        }

        /// <summary>
        /// Gets the ICursor for the users reminders
        /// </summary>
        /// <param name="uri"> The current uniform resource identifier. </param>
        /// <param name="userInfo"> The current user reminder information. </param>
        /// <param name="calId"> The current user's calendar Id. </param>
        /// <returns></returns>
        public ICursor GetReminderICusor(Android.Net.Uri uri, UserReminderInfo userInfo, int calId)
        {
            string[] info =
            {
                userInfo.Id,
                userInfo.EventId,
                userInfo.Title,
                userInfo.StartTime.ToString()
            };

            return Application.Context.ContentResolver.Query(uri, info, String.Format("calendar_id={0}", calId), null, "dtstart ASC");
        }

        /// <summary>
        /// Method inserts an event into the users calendar. 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startDate"></param>
        /// <param name="description"></param>
        /// <param name="endDate"></param>
        public void AddEvent(string calId, string title, DateTime startDate, DateTime endDate, string description = "")
        {
            var eventValues = new ContentValues();
            DateTime sDate = startDate;
            DateTime eDate = endDate;
            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, calId);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title, title);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart, sDate.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString());
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend, eDate.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString());
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description, description);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,"UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");

            var calendarUri = CalendarContract.Calendars.ContentUri;

            var uri = Application.Context.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
        }

        // Add method here to accept event object from the CORE library. 

    }

    /// <summary>
    /// An object to hold the information about a user's calendar. 
    /// </summary>
    public class UserCalendarInfo
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string AccountName { get; set; }
        public UserCalendarInfo() { }
        
        public string[] GetInfoStringArray()
        {
            return new string[] { Id, DisplayName, AccountName };
    
        }
    }

    /// <summary>
    /// An object to store the user event info.
    /// </summary>
    public class UserEventInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserEventInfo() { }    
    }

    /// <summary>
    /// An object to store the info about a user reminder.
    /// </summary>
    public class UserReminderInfo
    {
        public string Count { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventId { get; set; }
        public string HasAlarm { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public UserReminderInfo() { }
    }
}