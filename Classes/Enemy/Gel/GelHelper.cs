using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Gel
{
    public class GelHelper
    {
        public Rectangle spawn;
        public Rectangle movement;
        public Vector2 spawnFrame;
        public Vector2 movementFrame;
        public int spawnLimiter { get; set; } = 30;
        public int movementLimiter { get; set; } = 2;
        public static int pvelocity { get; set; } = 2;
        public static int nvelocity { get; set; } = -2;
        public static int size { get; set; } = 16;
        public GelHelper()
        {
            spawn = new Rectangle(138, 185, 16, 16);
            movement = new Rectangle(1, 11, 8, 16);
            spawnFrame = new Vector2(1, 3);
            movementFrame = new Vector2(1, 2);
        }
    }
}
