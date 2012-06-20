using System;

namespace WhackAMole.Object
{
    [Serializable]
    class User
    {
        public string UserName;
        public string Password;

        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
