using System;

namespace HMHY
{
    class Task
    {

        public string taskName;
        public string reminder;
        private int id;

        public void createTask(string taskName, string reminder);
        public void setTaskName(string taskName);
        public void setReminder(string reminder);

    }
}
