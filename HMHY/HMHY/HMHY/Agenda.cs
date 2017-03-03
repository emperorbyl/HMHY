using System;

namespace HMHY
{
    class Agenda
    {

        public Goal[] goals { get; set; }
        public Task[] tasks { get; set; }
        public Note[] notes { get; set; }
        private string calendarId { get; set; }

        private Agenda() { }
        public void addGoal(Goal goal) { }
        public void addTask(Task task) { }
        public void addNote(Note note) { }
        public void addCalendar(string calendarId) { }
        public void createEvent(Event eventName) { }
        public void createReminder(Reminder reminder) { }

    }
}