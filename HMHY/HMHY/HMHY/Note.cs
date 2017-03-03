using System;

namespace HMHY
{
    class Note
    {

        public string title;
        public string note;
        private int id;

        public void createNote(string title, string note);
        public void setTitle(string title);
        public void setNote(string note);

    }
}
