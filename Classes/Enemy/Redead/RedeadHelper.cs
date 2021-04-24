using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead
{
    public class RedeadHelper
    {
        public Rectangle spawn;
        public Rectangle moving;
        public Rectangle idle;
        public Vector2 spawnFrame;
        public Vector2 movingFrame;
        public int spawnLimiter { get; set; } = 30;
        public int movementlimiter { get; set; } = 10;
        public static int size { get; set; } = 16;
        public static int three { get; set; } = 3;
        public static int two { get; set; } = 2;
        public static int nvelocity { get; set; } = -1;
        public RedeadHelper()
        {
            spawn = new Rectangle(138, 185, 16, 16);
            moving = new Rectangle(383, 164, 16, 16);
            idle = new Rectangle(416, 164, 16, 16);
            spawnFrame = new Vector2(1, 3);
            movingFrame = new Vector2(1, 2);
        }
    }
}
