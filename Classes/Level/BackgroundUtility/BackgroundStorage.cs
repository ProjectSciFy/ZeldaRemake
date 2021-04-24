using Microsoft.Xna.Framework;
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
        public Rectangle ROOM_RECTANGLE = new Rectangle(421, 1011, 256, 176);
        public float LAYERDEPTH = 0.0f;
        public Rectangle ROOM_EXTERIOR_RECTANGLE = new Rectangle(521, 11, 256, 176);

        public BackgroundStorage()
        {
        }
    }
}
