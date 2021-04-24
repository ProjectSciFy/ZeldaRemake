using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese
{
    public class KeeseHelper
    {
        public Rectangle spawn;
        public Rectangle moving;
        public int spawnLimiter { get; set; } = 30;
        public int flyingLimiter { get; set; } = 10;
        public int landigLimiter { get; set; } = 20;
        public Vector2 spawnFrame;
        public Vector2 movingFrame;
        public static int size { get; set; } = 16;
        public KeeseHelper()
        {
            spawn = new Rectangle(138, 185, 16, 16);
            moving = new Rectangle(183, 11, 16, 16);
            spawnFrame = new Vector2(1, 3);
            movingFrame = new Vector2(1, 2);
        }
    }
}
