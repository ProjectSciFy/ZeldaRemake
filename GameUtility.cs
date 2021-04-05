using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0
{
    public class GameUtility
    {
        public enum Enemies { Stalfos, Gel, Keese, BladeTrap, Goriya, Aquamentus, Wallmaster, OldMan }

        //PASS THIS TO ENTITIES FOR UPSCALING THEM UNIFORMLY
        public float spriteScalar = 3;

        //Seperate scalar for all HUD entities, still needs proper implementation:
        public float hudScalar = 1;

        //counter variables that are displayed in HUD graphically:
        public int numKeys;
        public int numBrups;
        public int numYrups;
        public int numLives;

        //map for HUD:
        public bool hasMap;

        public int roomNumber;

        public bool keyPressedTempVariable = false;

        public GameUtility()
        {
            //Initialize counter variables for HUD:
            numKeys = 0;
            numBrups = 0;
            numYrups = 0;
            numLives = 3;
            //map
            hasMap = false;
            //Initialize room number counter
            roomNumber = 2;
        }
    }
}
