using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CSE3902_Game_Sprint0.Classes.Tiles;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class Room
    {
        private Background background;
        private List<BlockTile> tiles;
        private int roomNumber;
        private int windowWidth;
        private int windowHeight;
        public Room(ZeldaGame game, int RoomNumber)
        {
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = (windowHeight / 3 - 176 / 3) / 2;
            int windowWidthFloor = (windowWidth / 3 - 256 / 3) / 2;

            roomNumber = RoomNumber;
            tiles = new List<BlockTile>();
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

            // string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Andrew\source\repos\ProjectSciFy\ZeldaRemake\Classes\Level\RoomCSV\01.csv");
             string[] lines = System.IO.File.ReadAllLines(cwdPath);

                foreach (string line in lines)
                {
                    string[] segments = line.Split(new string[] { "," },
                                        StringSplitOptions.None);
                    Vector2 position = new Vector2(windowWidthFloor + 3*float.Parse(segments[2])*16+48+6,windowHeightFloor + 3 * float.Parse(segments[1])*16 +48+6);
                Debug.Write(position);
                    tiles.Add(new BlockTile(game, new TileSpriteFactory(game),position));

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
            foreach (BlockTile tile in tiles)
            {
                tile.Draw();
            }
            
        }
    }
}

