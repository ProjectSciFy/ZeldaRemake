using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class Room
    {
        private Background background;
        private List<TempTile> tiles;
        private int roomNumber;
        public Room(EeveeSim game, int RoomNumber)
        {
            roomNumber = RoomNumber;
            tiles = new List<TempTile>();
            background = new Background(game, roomNumber);
            //for(int i = 0; i < 5; i++)
            //{
            //    tiles.Add(new TempTile(game));
            //}
            //        private static string rootCSV = "LevelCSV";

            // private static string cwdPath = Directory.GetCurrentDirectory();
            //System.IO.BinaryReader
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Andrew\source\repos\ProjectSciFy\ZeldaRemake\Classes\Level\RoomCSV\01.csv");

            foreach(string line in lines)
            {
                string[] pieces = line.Split(new string[] { "," },
                                  StringSplitOptions.None);
                Vector2 position = new Vector2(float.Parse(pieces[1]), float.Parse(pieces[2]));
                tiles.Add(new TempTile(game,position));

            }



        }
        public void Update()
        {
        }
        public int getRoomNumber()
        {
            return roomNumber;
        }
        public void Draw()
        {
            background.Draw();
            foreach(TempTile tile in tiles)
            {
                tile.Draw();
            }
              
        }
    }
}

