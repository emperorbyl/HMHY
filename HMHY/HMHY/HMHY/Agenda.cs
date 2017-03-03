using System;

namespace HMHY
{
    class Agenda
    {

        public Goal[] goals;
        public Task[] tasks;
        public Note[] notes;
        private string calendarId;

        private Agenda();
        public void addGoal(Goal goal);
        public void addTask(Task task);
        public void addNote(Note note);
        public void addCalendar(string calendarId);
        public void createEvent(Event eventName);
        public void createReminder(Reminder reminder);

    }
}
