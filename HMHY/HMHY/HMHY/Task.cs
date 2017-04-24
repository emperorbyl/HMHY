using System;

namespace HMHY
{
    public class Task
    {

        public string taskName { get; set; }
        public string reminder { get; set; }
        private int id { get; set; }

        public void createTask(string taskName, string reminder) { }
        public void setTaskName(string taskName) { }
        public void setReminder(string reminder) { }

    }
}
