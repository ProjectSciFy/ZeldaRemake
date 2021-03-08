using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSE3902_Game_Sprint0.Classes.Rooms.RoomParser
{
    public class Parser
    {
        private EeveeSim game;
        private String room;
        public Parser(EeveeSim game)
        {
            this.game = game;
            this.room = "";
        }

        public void ParseRoom(String roomFileName)
        {
            //Get the full file name, we can decide if we want to include the '.txt' in the parameter or use this method instead.
            this.room = roomFileName + ".txt";
        }
    }
}
