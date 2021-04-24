using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class TransitionStateStorage
    {
        public static readonly int roomLimiter = 10;
        public static readonly int drawOffset = 96;
        public static readonly int timer = 128;
        public static readonly int animationSpeed = 6;
        public static readonly int roomTransitionX = 256;
        public static readonly int roomTransitionY = 176;
        public static readonly int specialRoomNumber = 16;
        public static readonly int interiorPosAdjust = 33;

        public static readonly int verticalDoorAdjust = 112;
        public static readonly int horizontalDoorAdjust = 224;
        public static readonly int smallAdjust = 72;
        public static readonly int largeAdjust = 144;
        public static readonly int linkAdjust = 88;
        public static readonly int linkSmallAdjust = 42;
        public static readonly int adjust = 8;
        public static readonly int temp = 110;

        public static Rectangle exteriorTemp = new Rectangle(521, 11, 256, 176);
        public static Rectangle exteriorActual = new Rectangle(421, 1011, 256, 176);
        public static Rectangle pushableTile = new Rectangle(1001, 11, 16, 16);
        public TransitionStateStorage()
        {
        }
    }
}
