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
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Interfaces;

using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Doors;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class Room
    {
        private Background background;
        private List<ITile> tiles;
        private List<IItem> items;
        private List<IEnemy> enemies;
        private List<IDoor> doors;

        private int roomNumber;
        private int windowWidth;
        private int windowHeight;
        public Room(ZeldaGame game, int RoomNumber)
        {
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = (windowHeight / 3 - 176 / 3) / 2;
            int windowWidthFloor = (windowWidth / 3 - 256 / 3) / 2;

            int doorvalue = 0;
            roomNumber = RoomNumber;
            tiles = new List<ITile>();
            items = new List<IItem>();
            enemies = new List<IEnemy>();
            doors = new List<IDoor>();
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
                if (segments[0].Equals("Block"))
                {
                    Vector2 position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 6, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 6);
                    tiles.Add(new BlockTile(game, new TileSpriteFactory(game), position));
                }
                if (segments[0].Equals("Heart"))
                {
                    Vector2 position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 12);
                    items.Add(new Heart(game, new ItemSpriteFactory(game), position));
                }
                if (segments[0].Equals("Goriya"))
                {
                    Vector2 position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                    enemies.Add(new EnemyStalfos(game, position));
                }


            }

            //  Vector2 pos = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48 + 12, windowHeightFloor + 3 * 1 * 16 + 48 + 12);
            //items.Add(new Heart(game, new ItemSpriteFactory(game), pos));


            

            cwdPath = Directory.GetCurrentDirectory();
            cwdPath = cwdPath.Replace(@"\bin\Debug\netcoreapp3.1", @"\Classes\Level\RoomCSV");
            cwdPath = Path.Combine(cwdPath, "doors.csv");
            lines = System.IO.File.ReadAllLines(cwdPath);
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                if(int.Parse(segments[0]) == RoomNumber)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        if(int.Parse(segments[i+1]) != 0)
                        {
                            doorvalue = i * 10 + int.Parse(segments[i + 1]);
                            switch (i)
                            {
                                case 0:
                                    doors.Add(new TopDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                case 1:
                                    doors.Add(new LeftDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                case 2:
                                    doors.Add(new RightDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                case 3:
                                    doors.Add(new BottomDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                        else
                        {
                            doorvalue = i * 10 + int.Parse(segments[i + 1]);
                            switch (i)
                            {
                                case 0:
                                    doors.Add(new TopDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                case 1:
                                    doors.Add(new LeftDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                case 2:
                                    doors.Add(new RightDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                case 3:
                                    doors.Add(new BottomDoor(game, new RoomTextureStorage(game), doorvalue));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

            }

            // doors.Add(new TopDoor(game, new RoomTextureStorage(game), 2));


        }
        public void Update()
        {
            foreach (IEnemy enemy in enemies)
            {
                enemy.Update();
            }
        }
        public int getRoomNumber()
        {
            return roomNumber;
        }
        public void Draw()
        {
            background.Draw();
            foreach (ITile tile in tiles)
            {
                tile.Draw();
            }
            foreach (IItem item in items)
            {
                item.Draw();
            }
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw();
            }
            foreach (IDoor door in doors)
            {
                door.Draw();
            }

        }
    }
}

