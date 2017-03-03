using System;

namespace HMHY
{
    class Goal
    {

        public string title { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public Task[] tasks { get; set; }
        public Note[] notes { get; set; }
        public enum FREQUENCY { hourly, daily, weekly }  //just for now
        private int id { get; set; }
        private enum TYPE { making, breaking }

        public void createGoal(string title, string description, DateTime deadline) { }
        public void setTitle(string title) { }
        public void setDescription(string description) { }
        public void setDeadline(DateTime dealine) { }
        public void setReminder(Reminder reminder) { }
        public void setTask(Task task) { }
        public void setNote(Note note) { }
        public void setFrequency(FREQUENCY frequency) { }
        public void createEvent(Event eventname) { }

    }
}
