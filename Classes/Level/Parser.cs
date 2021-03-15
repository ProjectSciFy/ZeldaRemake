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
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.OldMan;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class Parser
    {
        private Background background;

        private static int roomNumber;
        private static int windowWidth;
        private static int windowHeight;
        public static Room ParseRoomCSV(ZeldaGame game, int RoomNumber)
        {
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = (windowHeight / 3 - 176 / 3) / 2;
            int windowWidthFloor = (windowWidth / 3 - 256 / 3) / 2;

            int doorvalue = 0;
            roomNumber = RoomNumber;
            List<ITile> tiles = new List<ITile>();
            List<IItem> items = new List<IItem>();
            List<IEnemy> enemies = new List<IEnemy>();
            List<IDoor> doors = new List<IDoor>();

            string cwdPath = Directory.GetCurrentDirectory();

            string roomPath = "";
            if (roomNumber < 10)
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

            string[] lines = System.IO.File.ReadAllLines(cwdPath);

            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                Vector2 position = new Vector2(0, 0);
                switch (segments[0])
                {
                    case "Block":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 6, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 6);
                        tiles.Add(new BlockTile(game, new TileSpriteFactory(game), position));
                        break;
                    case "Heart":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 12);
                        items.Add(new Heart(game, new ItemSpriteFactory(game), position));
                        break;
                    case "Key":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 12);
                        items.Add(new Key(game, new ItemSpriteFactory(game), position));
                        break;
                    case "Goriya":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        enemies.Add(new EnemyGoriya(game, position));
                        break;
                    case "Aquamentus":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        enemies.Add(new EnemyAquamentus(game, position));
                        break;
                    case "BladeTrap":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        //enemies.Add(new BladeTrap(game, position));
                        break;
                    case "Gel":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        //enemies.Add(new EnemyGel(game, position));
                        break;
                    case "Kreese":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        enemies.Add(new EnemyKeese(game, position));
                        break;
                    case "OldMan":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        enemies.Add(new EnemyOldMan(game, position));
                        break;
                    case "Stalfos":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        enemies.Add(new EnemyStalfos(game, position));
                        break;
                    case "WallMaster":
                        position = new Vector2(windowWidthFloor + 3 * 1 * 16 + 48, windowHeightFloor + 3 * 2 * 16 + 48);
                        enemies.Add(new EnemyWallmaster(game, position));
                        break;

                    default:
                        break;
                }



            }


            cwdPath = Directory.GetCurrentDirectory();
            cwdPath = cwdPath.Replace(@"\bin\Debug\netcoreapp3.1", @"\Classes\Level\RoomCSV");
            cwdPath = Path.Combine(cwdPath, "doors.csv");
            lines = System.IO.File.ReadAllLines(cwdPath);
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                if (int.Parse(segments[0]) == RoomNumber)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (int.Parse(segments[i + 1]) != 0)
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
            return new Room(game, RoomNumber, tiles, items, enemies, doors);

        }
    }
}

