using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Rooms.MapControl
{
    public class Map
    {
        private int[][] map = new int[8][];
        private Vector2 mapSize;
        public Map()
        {
            this.mapSize = new Vector2(8, 8);
            //0 if no room, othersize room number (starts from bottom, left to right)
            // 0  0  0  0  0  0  0  0
            // 0  16 17 18 0  0  0  0
            // 0  0  0  13 0  14 15 0
            // 0  8  9  10 11 12 0  0
            // 0  0  5  6  7  0  0  0
            // 0  0  0  4  0  0  0  0
            // 0  0  1  2  3  0  0  0
            // 0  0  0  0  0  0  0  0
            this.map[0][0] = 0; this.map[0][1] = 0; this.map[0][2] = 0; this.map[0][3] = 0; this.map[0][4] = 0; this.map[0][5] = 0; this.map[0][6] = 0; this.map[0][7] = 0;
            this.map[1][0] = 0; this.map[1][1] = 16; this.map[1][2] = 17; this.map[1][3] = 18; this.map[1][4] = 0; this.map[1][5] = 0; this.map[1][6] = 0; this.map[1][7] = 0;
            this.map[2][0] = 0; this.map[2][1] = 0; this.map[2][2] = 0; this.map[2][3] = 13; this.map[2][4] = 0; this.map[2][5] = 14; this.map[2][6] = 15; this.map[2][7] = 0;
            this.map[3][0] = 0; this.map[3][1] = 8; this.map[3][2] = 9; this.map[3][3] = 10; this.map[3][4] = 11; this.map[3][5] = 12; this.map[3][6] = 0; this.map[3][7] = 0;
            this.map[4][0] = 0; this.map[4][1] = 0; this.map[4][2] = 5; this.map[4][3] = 6; this.map[4][4] = 7; this.map[4][5] = 0; this.map[4][6] = 0; this.map[4][7] = 0;
            this.map[5][0] = 0; this.map[5][1] = 0; this.map[5][2] = 0; this.map[5][3] = 4; this.map[5][4] = 0; this.map[5][5] = 0; this.map[5][6] = 0; this.map[5][7] = 0;
            this.map[6][0] = 0; this.map[6][1] = 0; this.map[6][2] = 1; this.map[6][3] = 2; this.map[6][4] = 3; this.map[6][5] = 0; this.map[6][6] = 0; this.map[6][7] = 0;
            this.map[7][0] = 0; this.map[7][1] = 0; this.map[7][2] = 0; this.map[7][3] = 0; this.map[7][4] = 0; this.map[7][5] = 0; this.map[7][6] = 0; this.map[7][7] = 0;
        }


        /*
         * MAP AND ROOM GET METHODS
         */
        public int[][] getMap()
        {
            return this.map;
        }

        public Vector2 getMapSize()
        {
            return this.mapSize;
        }

    }
}
