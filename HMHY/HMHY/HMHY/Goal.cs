using System;

namespace HMHY
{
    class Goal
    {

        public string title;
        public string description;
        public DateTime deadline;
        public Task[] tasks;
        public Note[] notes;
        public enum FREQUENCY { hourly, daily, weekly }; //just for now
        private int id;
        private enum TYPE { making, breaking };

        public void createGoal(string title, string description, DateTime deadline);
        public void setTitle(string title);
        public void setDescription(string description);
        public void setDeadline(DateTime dealine);
        public void setReminder(Reminder reminder);
        public void setTask(Task task);
        public void setNote(Note note);
        public void setFrequency(FREQUENCY frequency);
        public void createEvent(Event eventname);

    }
}
