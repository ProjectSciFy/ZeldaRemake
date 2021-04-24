using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Stalfos
{
    public class StalfosHelper
    {
        public Rectangle spawn;
        public Rectangle moving;
        public Vector2 spawnFrame;
        public Vector2 movingFrame;
        public int spawnLimiter { get; set; } = 30;
        public int movementLimiter { get; set; } = 10;
        public static int size { get; set; } = 16;
        public static int nvelocity { get; set; } = -1;
        public StalfosHelper()
        {
            spawnFrame = new Vector2(1, 3);
            movingFrame = new Vector2(1, 2);
            spawn = new Rectangle(138, 185, 16, 16);
            moving = new Rectangle(383, 146, 16, 16);

        }
    }
}
