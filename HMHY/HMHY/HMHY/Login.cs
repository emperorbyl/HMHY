using System;

namespace HMHY
{
    class Login
    {

        private string databaseId;
        private string userName;
        private string password;
        private int userId;
        public bool privilege;

        private bool setPrivilege(string databaseId);
        public void setUserName(string userName);
        public void setPassword(string password);
        public int getUserId(string databaseId);

    }
}
