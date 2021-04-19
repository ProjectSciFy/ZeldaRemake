using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0
{
    public class GameUtility
    {
        public enum Enemies { Stalfos, Gel, Keese, BladeTrap, Goriya, Aquamentus, Wallmaster, OldMan }
        public float spriteScalar { get; set; } = 3;
        public float hudScalar { get; set; } = 1;

        //counter variables that are displayed in HUD graphically:
        public int numKeys { get; set; }
        public int numBrups { get; set; }
        public int numYrups { get; set; }
        public int numLives { get; set; }

        //map for HUD:
        public bool hasMap { get; set; }
        public bool hasCompass { get; set; }
        public bool linkInd { get; set; }
        //item select state code:
        public bool finishTransition { get; set; }
        public int selectSpeed { get; set; }
        public bool selecting { get; set; }
        public int roomNumber { get; set; }

        public bool keyPressedTempVariable { get; set; } = false;


        public bool paused { get; set; } = false;
        public bool inventory { get; set; } = false;
        public bool itemScreen { get; set; } = false;

        public GameUtility()
        {
            //Initialize counter variables for HUD:
            numKeys = 0;
            numBrups = 0;
            numYrups = 0;
            numLives = 3;
            //map
            hasMap = false;
            linkInd = true;
            //compass
            hasCompass = false;
            //Initialize room number counter
            roomNumber = 2;

            //item select state code:
            // not selecting
            selecting = false;
            selectSpeed = 6;
            finishTransition = true;
        }
    }
}
