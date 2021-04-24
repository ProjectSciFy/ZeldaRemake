using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Goriya
{
    public class GoriyaHelper
    {
        public Rectangle spawn;
        public Rectangle up;
        public Rectangle down;
        public Rectangle leftOrRight;
        public int spawnLimiter { get; set; } = 30;
        public int movementLimiter { get; set; } = 10;
        public Vector2 spawnFrame;
        public Vector2 movingFrame;
        public static int xsize { get; set; } =16;
        public static int ysize { get; set; } = 16;
        public static int nvelocity { get; set; } = -1;
        public GoriyaHelper()
        {
            up = new Rectangle(322, 28, 16, 16);
            spawn = new Rectangle(138, 185, 16, 16);
            down = new Rectangle(290, 28, 16, 16);
            leftOrRight = new Rectangle(254, 11, 16, 16);
            spawnFrame = new Vector2(1, 3);
            movingFrame = new Vector2(1, 2);
        }
    }
}
