using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterHelper
    {
        public Rectangle kill;
        public Rectangle moving;
        public int killLimiter { get; set; } = 30;
        public int movementLimiter { get; set; } = 20;
        public int hidingLimiter { get; set; } = 60;
        public Vector2 killFrame;
        public Vector2 movingFrame;
        public static int size { get; set; } = 16;
        public static int nvelocity { get; set; } = -1;

        public WallmasterHelper()
        {
            kill = new Rectangle(138, 185, 16, 16);
            moving = new Rectangle(393, 11, 16, 16);
            killFrame = new Vector2(1, 3);
            movingFrame = new Vector2(1, 2);
        }
    }
}
