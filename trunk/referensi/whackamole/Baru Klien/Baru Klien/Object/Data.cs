using System;

namespace WhackAMole.Object
{
    [Serializable]
    class Data
    {
        public Game GameData;
        public User UserData;
        public bool Play;
        public string ServerMessage;

        public Data()
        {
            GameData = null;
            UserData = null;
            Play = false;
            ServerMessage = null;
        }
    }
}
