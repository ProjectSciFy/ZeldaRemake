using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{

    public class AquamentusHelper
    {
        public Rectangle spawn;
        public Rectangle moving;
        public Rectangle roaring;
        public static int xsize { get; set; } = 24;
        public static int ysize { get; set; } = 32;
        public int spawnLimiter { get; set; } = 30;
        public int movementLimiter { get; set; } = 15;
        public Vector2 spawnFrame;
        public Vector2 movingFrame;
        public static int three { get; set; } = 3;
        public static int two { get; set; } = 2;
        public static int minustwo { get; set; } = -2;

        public AquamentusHelper()
        {
            spawn = new Rectangle(138, 185, 16, 16);
            moving = new Rectangle(49, 11, 24, 32);
            roaring = new Rectangle(1, 11, 24, 32);
            spawnFrame = new Vector2(1, 3);
            movingFrame = new Vector2(1, 2);
        }
    }
}
