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
        public Room(ZeldaGame game, int RoomNumber)
        {
            roomNumber = RoomNumber;
            tiles = new List<TempTile>();
            background = new Background(game, roomNumber);

            string cwdPath = Directory.GetCurrentDirectory();

            string roomPath = "";
            if(roomNumber < 10)
            {
                roomPath = @"0" + (roomNumber.ToString()) + ".csv";
            }
            else
            {
                roomPath = @"" + (roomNumber.ToString()) + ".csv";
            }
            
     
            cwdPath = cwdPath.Replace(@"\bin\Debug\netcoreapp3.1", @"\Classes\Level\RoomCSV");
            cwdPath = Path.Combine(cwdPath, roomPath);

            
            Debug.Write("Path:\n");
            Debug.Write(cwdPath);
            Debug.Write("\n");

            //TileSpriteFactory TSF = new TileSpriteFactory();
            // string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Andrew\source\repos\ProjectSciFy\ZeldaRemake\Classes\Level\RoomCSV\01.csv");
             string[] lines = System.IO.File.ReadAllLines(cwdPath);

                foreach (string line in lines)
                {
                    string[] segments = line.Split(new string[] { "," },
                                        StringSplitOptions.None);
                    Vector2 position = new Vector2(float.Parse(segments[2]), float.Parse(segments[1]));
                   // tiles.Add(new Collision(game, TSF,position));

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
            foreach (TempTile tile in tiles)
            {
                tile.Draw();
            }
            
        }
    }
}

