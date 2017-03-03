using System;

namespace HMHY
{
    class Reminder
    {

        public string title { get; set; }
        public string note { get; set; }
        public DateTime reminderTime { get; set; }
        private int id { get; set; }

        public void createReminder(string title, string note, DateTime reminderTime) { }
        public void setTitle(string title) { }
        public void setNote(string note) { }
        public void setReminderTime(DateTime reminderTime) { }
        private void appendToCalendar(string googleReminder) { }

    }
}
