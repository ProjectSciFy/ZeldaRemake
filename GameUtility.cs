using CSE3902_Game_Sprint0.Classes.Level;
using Microsoft.Xna.Framework;
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
        public int numBombs { get; set; }
        public int numYrups { get; set; }
        public int numLives { get; set; }

        public int numXP { get; set; }
        public int XPPerLevel { get; set; } = 10;
        public int linkXPlevel { get; set; } 

        //map for HUD:
        public bool hasMap { get; set; }
        public bool hasCompass { get; set; }
        public bool linkInd { get; set; }
        //item select state code:
        public int selectSpeed { get; set; }
        public Vector2 midPos;
        public Vector2 topPos;
        private int x, y;
        public bool inSelect { get; set; }

        public int roomNumber { get; set; }

        public bool keyPressedTempVariable { get; set; } = false;


        public bool paused { get; set; } = false;
        public bool inventory { get; set; } = false;
        public bool itemScreen { get; set; } = false;

        public GameUtility()
        {
            //Initialize counter variables for HUD:
            numKeys = 0;
            numBombs = 3;
            numYrups = 0;
            numLives = 3;
            numXP = 0;
            linkXPlevel = 1;
            //map
            hasMap = false;
            linkInd = true;
            //compass
            hasCompass = false;
            //Initialize room number counter
            roomNumber = 2;

            //item select state code:
            // not selecting
            selectSpeed = -6;
            x = 128;
            y = -186;
            midPos = new Vector2(x, y - 82);
            topPos = new Vector2(x, y - 87 * 3 - 120);
            inSelect = false;
        }
    }
}
