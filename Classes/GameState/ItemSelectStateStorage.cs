using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class ItemSelectStateStorage
    {
        public readonly int fpsLimiter = 10;
        public readonly Rectangle topRectangle = new Rectangle(1, 11, 260, 100);
        public readonly Rectangle midRectangle = new Rectangle(258, 111, 260, 99);
        public readonly Rectangle mapRectangle = new Rectangle(601, 156, 8, 16);
        public readonly Rectangle compassRectangle = new Rectangle(613, 157, 13, 14);
        public readonly int mapXAdjust = 142;
        public readonly int mapYAdjust = 70;
        public readonly int compassXAdjust = 136;
        public readonly int compassYAdjust = 190;
        public readonly int weaponYAdjust = 144;
        public readonly int weaponHoldingXAdjust = 201;
        public readonly int weapon1XAdjust = 390;
        public readonly int weapon2XAdjust = 460;
        public readonly int weapon3XAdjust = 530;
        public readonly int hudBotPos = 612;
        public readonly int hudTopPos = 25;
        public ItemSelectStateStorage()
        {
        }
    }
}
