using System;

namespace HMHY
{
    public class Login
    {

        private string databaseId { get; set; }
        private string userName { get; set; }
        private string password { get; set; }
        private int userId { get; set; }
        public bool privilege { get; set; }

        private bool setPrivilege(string databaseId) { return true; }
        public void setUserName(string userName) { }
        public void setPassword(string password) { }
        public int getUserId(string databaseId) { return 0; }

    }
}
