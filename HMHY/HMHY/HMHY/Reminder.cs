using System;

namespace HMHY
{
    class Reminder
    {

        public string title;
        public string note;
        public DateTime reminderTime;
        private int id;

        public void createReminder(string title, string note, DateTime reminderTime);
        public void setTitle(string title);
        public void setNote(string note);
        public void setReminderTime(DateTime reminderTime);
        private void appendToCalendar(string googleReminder);

    }
}
