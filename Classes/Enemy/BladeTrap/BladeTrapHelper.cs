using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.BladeTrap
{
    public class BladeTrapHelper
    {
        public Rectangle trap;
        public int spawnLimiter { get; set; }
        public int movementLimiter { get; set; }
        public BladeTrapHelper()
        {
            trap = new Rectangle(164, 59, 16, 16);
            spawnLimiter = 30;
            movementLimiter = 10;
        }
    }
}
