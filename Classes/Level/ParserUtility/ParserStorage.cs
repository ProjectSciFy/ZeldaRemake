namespace CSE3902_Game_Sprint0.Classes.Level.BackgroundUtility
{
    public class ParserStorage
    {
        public int roomLimiter { get; set; } = 10;
        public int drawOffset { get; set; } = 96;
        public int undergroundRoomNumber { get; set; } = 16;
        public int outsideRoomNumber { get; set; } = 17;

        public int singleDigitRoomCap { get; set; } = 10;
        public int bladeTrapX = 265;
        public int bladeTrapY = 130;
        public int numberOfDoors = 4;
        public int doorKeyScaleValue = 10;
        public int lockedDoorValue = 2;
        public int openDoorValue = 1;
        public int portalDoorValue = 6;
        public int topDoorLeftPos = 6;
        public int topDoorRightPos = 6;
        public int undergroundXPos = 1;
        public int undergroundYPos = -1;
        public int undergroundWallXPos = 2;
        public int outsideStairX = 7;
        public int outsideStairY = 4;
        public int topDoorX = 6;
        public int leftDoorY = 4;
        public int rightDoorX = 13;
        public int rightDoorY = 4;
        public int bottomDoorX = 6;
        public int bottomDoorY = 8;
        public int bottomDoorWallX = 7;
        public int doorValueDefault = 0;
        public int topKey = 0;
        public int leftKey = 1;
        public int rightKey = 2;
        public int bottomKey = 3;


        public ParserStorage()
        {
        }
    }
}
