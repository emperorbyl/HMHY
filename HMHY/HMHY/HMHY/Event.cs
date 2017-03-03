using System;

namespace HMHY
{
    class Event
    {

        public string title { get; set; }
        public string description { get; set; }
        public DateTime eventTime { get; set; }

        public void createEvent(string title, string description, DateTime eventTime) { }
        public void setTitle(string title) { }
        public void setDescription(string description) { }
        public void seteEventTime(DateTime eventtime) { }
        private void pushToCalendar(string googleEvent) { }

    }
}
