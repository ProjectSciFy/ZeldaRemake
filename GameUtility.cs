using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0
{
    public class GameUtility
    {
        public enum Enemies { Stalfos, Gel, Keese, BladeTrap, Goriya, Aquamentus, Wallmaster, OldMan }
        public float spriteScalar { get; set; } = 3;
        public float hudScalar { get; set; } = 1;
        //counter variables that are displayed in HUD graphically:
        public int numKeys { get; set; }
        public int MAX_KEYS { get; set; } = 99;
        public int numBombs { get; set; }
        public int MAX_BOMBS { get; set; } = 99;
        public int numYrups { get; set; }
        public int MAX_RUPS { get; set; } = 99;
        public int numLives { get; set; }
        public int MAX_LIVES { get; set; } = 16;
        public int HALF_MAX_LIVES { get; set; } = 8;
        public int numXP { get; set; }
        public int XPPerLevel { get; set; } = 10;
        public int linkXPlevel { get; set; }
        public int difficultyMult { get; set; } = 1;
        //map for HUD:
        public bool hasMap { get; set; }
        public bool hasCompass { get; set; }
        public bool linkInd { get; set; }
        //item select state code:
        public int selectSpeed { get; set; }
        public Vector2 midPos;
        public Vector2 topPos;
        private readonly int x, y;
        public bool inSelect { get; set; }
        public bool hasBow { get; set; }
        public int roomNumber { get; set; }
        public bool keyPressedTempVariable { get; set; } = false;
        public bool paused { get; set; } = false;
        public bool inventory { get; set; } = false;
        public bool itemScreen { get; set; } = false;

        public int startingRoomNumber() { return 2; }
        public int numberOfRooms() { return 19; }

        public GameUtility()
        {
            //Initialize counter variables for HUD:
            numKeys = 0;
            numBombs = 3;
            numYrups = 5;
            numLives = 3;
            numXP = 0;
            linkXPlevel = 1;
            //map
            hasMap = true;
            linkInd = true;
            hasBow = false;
            //compass
            hasCompass = false;
            //Initialize room number counter
            roomNumber = startingRoomNumber();

            //item select state code:
            // not selecting
            selectSpeed = -6;
            x = 128;
            y = -186;

            //mid and top pos are used in the itemSelectState as a reference point for a couple of sprites, be careful if refactoring this code:
            midPos = new Vector2(x, y - 82);
            topPos = new Vector2(x, y - 87 * 3 - 120);
            inSelect = false;
        }
    }
}
