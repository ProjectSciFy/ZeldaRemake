using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Level.BackgroundUtility
{
    public class BackgroundStorage
    {
        public int roomLimiter { get; set; } = 10;
        public int drawOffset { get; set; } = 96;
        public int specialRoomNumber { get; set; } = 16;
        public BackgroundStorage()
        {
        }
    }
}
