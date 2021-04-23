using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles.KiBlastUtility
{
    public class KiBlastStorage
    {
        public static int HITBOX_OFFSET = 60;
        public static int DOUBLE_OFFSET = HITBOX_OFFSET * 2;
        public static int TRIPLE_OFFSET = HITBOX_OFFSET * 3;
        public static int STARTING_TIMER = 60;
        public static Vector2 DRAWLOCATION_OFFSET = new Vector2(40 * 3, 16 * 3);
    }
}
