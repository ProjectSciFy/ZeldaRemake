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
        private static int roomNumber;
        private static int windowWidth;
        private static int windowHeight;
        public static Room ParseRoomCSV(ZeldaGame game, int RoomNumber)
        {
            ParserUtility utility = new ParserUtility(game);

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
                        position = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        BlockTile block;
                        tiles.Add(block = new BlockTile(game, new TileSpriteFactory(game), position));
                        block.drawLocation = position;
                        break;
                    case "Compass":
                        position = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Compass compass;
                        items.Add(compass = new Compass(game, new ItemSpriteFactory(game), position));
                        compass.drawLocation = position;
                        break;
                    case "Heart":
                        position = utility.GetHeartPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Heart heart;
                        items.Add(heart = new Heart(game, new ItemSpriteFactory(game), position));
                        heart.position = position;
                        break;
                    case "Key":
                        position = utility.GetCommonItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Key key;
                        items.Add(key = new Key(game, new ItemSpriteFactory(game), position));
                        key.position = position;
                        break;
                    case "BlueRupee":
                        position = utility.GetCommonItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        BlueRupee blueRupee;
                        items.Add(blueRupee = new BlueRupee(game, new ItemSpriteFactory(game), position));
                        blueRupee.position = position;
                        break;
                    case "Bomb":
                        position = utility.GetBombPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Bomb bomb;
                        items.Add(bomb = new Bomb(game, new ItemSpriteFactory(game), position));
                        bomb.position = position;
                        break;
                    case "Boomerang":
                        position = utility.GetCommonItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Boomerang boomerang;
                        items.Add(boomerang = new Boomerang(game, new ItemSpriteFactory(game), position));
                        boomerang.position = position;
                        break;
                    case "Bow":
                        position = utility.GetCommonItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Bow bow;
                        items.Add(bow = new Bow(game, new ItemSpriteFactory(game), position));
                        bow.position = position;
                        break;
                    case "HeartContainer":
                        position = utility.GetHeartContainerPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        HeartContainer heartContainer;
                        items.Add(heartContainer = new HeartContainer(game, new ItemSpriteFactory(game), position));
                        heartContainer.position = position;
                        break;
                    case "Map":
                        position = utility.GetCommonItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Map map;
                        items.Add(map = new Map(game, new ItemSpriteFactory(game), position));
                        map.position = position;
                        break;
                    case "Triforce":
                        position = utility.GetTriforceOldPosition(windowWidth, windowHeightFloor);
                        Triforce triforce;
                        items.Add(triforce = new Triforce(game, new ItemSpriteFactory(game), position));
                        triforce.position = position;
                        break;
                    case "YellowRupee":
                        position = utility.GetCommonItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        YellowRupee yellowRupee;
                        items.Add(yellowRupee = new YellowRupee(game, new ItemSpriteFactory(game), position));
                        yellowRupee.position = position;
                        break;
                    case "Goriya":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyGoriya(game, position));
                        break;
                    case "Aquamentus":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyAquamentus(game, position));
                        break;
                    case "BladeTrap":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new BladeTrap(game, position, new Vector2(265, 130), game.link));
                        break;
                    case "Gel":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemySlime(game, position));
                        break;
                    case "Keese":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyKeese(game, position));
                        break;
                    case "OldMan":
                        position = utility.GetTriforceOldPosition(windowWidth, windowHeightFloor);
                        enemies.Add(new EnemyOldMan(game, position));
                        break;
                    case "Stalfos":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyStalfos(game, position));
                        break;
                    case "WallMaster":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
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

            Vector2 stairPos = new Vector2(0, 0);
            GatekeeperTile gatekeeper;
            StairsTile stair;
            bool locked;
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                if (int.Parse(segments[0]) == RoomNumber)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        doorvalue = i * 10 + int.Parse(segments[i + 1]);
                        locked = true;
                        if (int.Parse(segments[i + 1]) == 1)
                        {
                            locked = false;
                        }
                        switch (i)
                        {
                            case 0:
                                doors.Add(new TopDoor(game, new RoomTextureStorage(game), doorvalue));

                                wallPos = new Vector2(windowWidthFloor + 3 * 6 * 16 + 48 + 6, windowHeightFloor + 3 * 0 * 16 + 48 + 6);

                                tiles.Add(gatekeeper = new GatekeeperTile(game, new TileSpriteFactory(game), wallPos, locked));
                                gatekeeper.drawLocation = wallPos;

                                wallPos = new Vector2(windowWidthFloor + 3 * 7 * 16 + 48 + 6, windowHeightFloor + 3 * 0 * 16 + 48 + 6);
                                tiles.Add(gatekeeper = new GatekeeperTile(game, new TileSpriteFactory(game), wallPos, locked));
                                gatekeeper.drawLocation = wallPos;

                                stairPos = new Vector2(windowWidthFloor + 3 * 6 * 16 + 48 + 6 + 24, windowHeightFloor + 3 * 0 * 16 + 48 + 6 - 48);
                                tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                                stair.drawLocation = stairPos;
                                break;
                            case 1: //4,0 4,13
                                doors.Add(new LeftDoor(game, new RoomTextureStorage(game), doorvalue));

                                wallPos = new Vector2(windowWidthFloor + 3 * 7 * 0 + 48 + 6, windowHeightFloor + 3 * 4 * 16 + 48 + 6);

                                tiles.Add(gatekeeper = new GatekeeperTile(game, new TileSpriteFactory(game), wallPos, locked));
                                gatekeeper.drawLocation = wallPos;

                                stairPos = new Vector2(windowWidthFloor + 3 * 7 * 0 + 48 + 6 - 48, windowHeightFloor + 3 * 4 * 16 + 48 + 6);
                                tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                                stair.drawLocation = stairPos;
                                break;
                            case 2:
                                doors.Add(new RightDoor(game, new RoomTextureStorage(game), doorvalue));

                                wallPos = new Vector2(windowWidthFloor + 3 * 13 * 16 + 48 + 6, windowHeightFloor + 3 * 4 * 16 + 48 + 6);

                                tiles.Add(gatekeeper = new GatekeeperTile(game, new TileSpriteFactory(game), wallPos, locked));
                                gatekeeper.drawLocation = wallPos;

                                stairPos = new Vector2(windowWidthFloor + 3 * 13 * 16 + 48 + 6 + 48, windowHeightFloor + 3 * 4 * 16 + 48 + 6);
                                tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                                stair.drawLocation = stairPos;
                                break;
                            case 3:
                                doors.Add(new BottomDoor(game, new RoomTextureStorage(game), doorvalue));

                                wallPos = new Vector2(windowWidthFloor + 3 * 6 * 16 + 48 + 6, windowHeightFloor + 3 * 8 * 16 + 48 + 6);

                                tiles.Add(gatekeeper = new GatekeeperTile(game, new TileSpriteFactory(game), wallPos, locked));
                                gatekeeper.drawLocation = wallPos;
                                wallPos = new Vector2(windowWidthFloor + 3 * 7 * 16 + 48 + 6, windowHeightFloor + 3 * 8 * 16 + 48 + 6);

                                tiles.Add(gatekeeper = new GatekeeperTile(game, new TileSpriteFactory(game), wallPos, locked));
                                gatekeeper.drawLocation = wallPos;

                                stairPos = new Vector2(windowWidthFloor + 3 * 6 * 16 + 48 + 6 + 24, windowHeightFloor + 3 * 8 * 16 + 48 + 6 + 48);
                                tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                                stair.drawLocation = stairPos;
                                break;
                            default:
                                break;
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
            int roomCounter = 1;
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                neighbors.Add(roomCounter, new int[4] { Int32.Parse(segments[1]), Int32.Parse(segments[2]), Int32.Parse(segments[3]), Int32.Parse(segments[4]) });
                roomCounter = roomCounter + 1;
            }
            return neighbors;
        }
    }
}

