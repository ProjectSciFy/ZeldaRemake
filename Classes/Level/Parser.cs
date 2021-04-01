﻿using System;
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
        private static int roomNumber;
        private static int windowWidth;
        private static int windowHeight;
        public static Room ParseRoomCSV(ZeldaGame game, int RoomNumber)
        {
            roomNumber = RoomNumber;
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = (windowHeight / 3 - 176 / 3) / 2;
            int windowWidthFloor = (windowWidth / 3 - 256 / 3) / 2;
            int doorvalue = 0;
            
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
                        BlockTile block;
                        tiles.Add(block = new BlockTile(game, new TileSpriteFactory(game), position));
                        block.drawLocation = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 6, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 6);
                        break;
                    case "Heart":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 12);
                        Heart heart;
                        items.Add(heart = new Heart(game, new ItemSpriteFactory(game), position));
                        heart.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 12);
                        break;
                    case "Key":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        Key key;
                        items.Add(key = new Key(game, new ItemSpriteFactory(game), position));
                        key.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        break;
                    case "BlueRupee":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        BlueRupee blueRupee;
                        items.Add(blueRupee =new BlueRupee(game, new ItemSpriteFactory(game), position));
                        blueRupee.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        break;
                    case "Bomb":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 2);
                        Bomb bomb;
                        items.Add(bomb = new Bomb(game, new ItemSpriteFactory(game), position));
                        bomb.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 2);
                        break;
                    case "Boomerang":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        Boomerang boomerang;
                        items.Add(boomerang = new Boomerang(game, new ItemSpriteFactory(game), position));
                        boomerang.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        break;
                    case "Bow":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        Bow bow;
                        items.Add(bow = new Bow(game, new ItemSpriteFactory(game), position));
                        bow.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        break;
                    case "HeartContainer":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 4, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 6);
                        HeartContainer heartContainer;
                        items.Add(heartContainer = new HeartContainer(game, new ItemSpriteFactory(game), position));
                        heartContainer.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 4, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 6);
                        break;
                    case "Map":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        Map map;
                        items.Add(map = new Map(game, new ItemSpriteFactory(game), position));
                        map.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        break;
                    case "Triforce":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 8);
                        Triforce triforce;
                        items.Add(triforce = new Triforce(game, new ItemSpriteFactory(game), position));
                        triforce.position = position;
                        break;
                    case "YellowRupee":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        YellowRupee yellowRupee;
                        items.Add(yellowRupee = new YellowRupee(game, new ItemSpriteFactory(game), position));
                        yellowRupee.position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 12, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        break;
                    case "Goriya":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new EnemyGoriya(game, position));
                        break;
                    case "Aquamentus":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new EnemyAquamentus(game, position));
                        break;
                    case "BladeTrap":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new BladeTrap(game, position, new Vector2(100, 100), game.link));
                        break;
                    case "Gel":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new EnemySlime(game, position));
                        break;
                    case "Keese":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new EnemyKeese(game, position));
                        break;
                    case "OldMan":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new EnemyOldMan(game, position));
                        break;
                    case "Stalfos":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new EnemyStalfos(game, position));
                        break;
                    case "WallMaster":
                        position = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48);
                        enemies.Add(new EnemyWallmaster(game, position));
                        break;

                    default:
                        break;
                }

            }
            cwdPath = Directory.GetCurrentDirectory();
            cwdPath = cwdPath.Replace(@"\bin\Debug\netcoreapp3.1", @"\Classes\Level\RoomCSV");
            cwdPath = Path.Combine(cwdPath, "walls.csv");
            lines = System.IO.File.ReadAllLines(cwdPath);
            Vector2 wallPos = new Vector2(0, 0);
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                wallPos = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 6, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 6);
                WallTile wall;
                tiles.Add(wall = new WallTile(game, new TileSpriteFactory(game), wallPos));
                wall.drawLocation = new Vector2(windowWidthFloor + 3 * float.Parse(segments[2]) * 16 + 48 + 6, windowHeightFloor + 3 * float.Parse(segments[1]) * 16 + 48 + 6);
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
                                    wallPos = new Vector2(windowWidthFloor + 3 * 6 * 16 + 48 + 6, windowHeightFloor + 3 * 0 * 16 + 48 + 6);
                                    tiles.Add(new WallTile(game, new TileSpriteFactory(game), wallPos));
                                    wallPos = new Vector2(windowWidthFloor + 3 * 7 * 16 + 48 + 6, windowHeightFloor + 3 * 0 * 16 + 48 + 6);
                                    tiles.Add(new WallTile(game, new TileSpriteFactory(game), wallPos));
                                    break;
                                case 1: //4,0 4,13
                                    doors.Add(new LeftDoor(game, new RoomTextureStorage(game), doorvalue));
                                    wallPos = new Vector2(windowWidthFloor + 3 * 7 * 0 + 48 + 6, windowHeightFloor + 3 * 4 * 16 + 48 + 6);
                                    tiles.Add(new WallTile(game, new TileSpriteFactory(game), wallPos));
                                    break;
                                case 2:
                                    doors.Add(new RightDoor(game, new RoomTextureStorage(game), doorvalue));
                                    wallPos = new Vector2(windowWidthFloor + 3 * 13 * 16 + 48 + 6, windowHeightFloor + 3 * 4 * 16 + 48 + 6);
                                    tiles.Add(new WallTile(game, new TileSpriteFactory(game), wallPos));
                                    break;
                                case 3:
                                    doors.Add(new BottomDoor(game, new RoomTextureStorage(game), doorvalue));
                                    wallPos = new Vector2(windowWidthFloor + 3 * 6 * 16 + 48 + 6, windowHeightFloor + 3 * 8 * 16 + 48 + 6);
                                    tiles.Add(new WallTile(game, new TileSpriteFactory(game), wallPos));
                                    wallPos = new Vector2(windowWidthFloor + 3 * 7 * 16 + 48 + 6, windowHeightFloor + 3 * 8 * 16 + 48 + 6);
                                    tiles.Add(new WallTile(game, new TileSpriteFactory(game), wallPos));
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
        public static Dictionary<int, int[]> ParseNeighborCSV()
        {
            Dictionary<int, int[]> neighbors = new Dictionary<int, int[]>();
            String cwdPath = Directory.GetCurrentDirectory();
            cwdPath = cwdPath.Replace(@"\bin\Debug\netcoreapp3.1", @"\Classes\Level\RoomCSV");
            cwdPath = Path.Combine(cwdPath, "neighbors.csv");
            string[] lines = System.IO.File.ReadAllLines(cwdPath);
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                neighbors.Add(Int32.Parse(segments[0]), new int[4] { Int32.Parse(segments[1]), Int32.Parse(segments[2]), Int32.Parse(segments[3]), Int32.Parse(segments[4]) });
            }
            return neighbors;
        }
    }
}
