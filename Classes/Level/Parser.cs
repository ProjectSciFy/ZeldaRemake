using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
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
using CSE3902_Game_Sprint0.Classes.Enemy.Redead;
using CSE3902_Game_Sprint0.Classes.Enemy.Roshi;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class Parser
    {
        private static int roomNumber { get; set; }
        private static int windowWidth { get; set; }
        private static int windowHeight { get; set; }

        private static int windowHeightFloor { get; set; }
        private static int windowWidthFloor { get; set; }

        private static List<ITile> tiles = new List<ITile>();
        private static List<IItem> items = new List<IItem>();
        private static List<IEnemy> enemies = new List<IEnemy>();
        private static List<IDoor> doors = new List<IDoor>();

        private static ZeldaGame game { get; set; }
        private static ParserUtility utility { get; set; }

        public static Room ParseRoomCSV(ZeldaGame game2, int RoomNumber)
        {
            game = game2;
            utility = new ParserUtility(game);

            roomNumber = RoomNumber;
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            windowHeightFloor = ((windowHeight / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST;
            windowWidthFloor = (windowWidth / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            

            tiles = new List<ITile>();
            items = new List<IItem>();
            enemies = new List<IEnemy>();
            doors = new List<IDoor>();
            
            ParseRoomCSVFile();
            ParseWallsCSVFile();
            ParseDoorsCSVFile();
            return new Room(game, RoomNumber, tiles, items, enemies, doors);
        }
        public static void ParseRoomCSVFile()
        {
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
                    case "Event":
                        position = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        EventTile eventTile;
                        tiles.Add(eventTile = new EventTile(game, new TileSpriteFactory(game), position));
                        eventTile.drawLocation = position;
                        break;
                    case "Pushable":
                        position = utility.GetPushablePosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        PushableTile pushable;
                        tiles.Add(pushable = new PushableTile(game, new TileSpriteFactory(game), position));
                        pushable.drawLocation = position;
                        break;
                    case "Stair":
                        position = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        TPTile stair;
                        tiles.Add(stair = new TPTile(game, new TileSpriteFactory(game), position));
                        stair.drawLocation = position;
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
                    case "Fairy":
                        position = utility.GetCommonItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        Fairy fairy;
                        items.Add(fairy = new Fairy(game, new ItemSpriteFactory(game), position));
                        fairy.position = position;
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
                    case "Roshi":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyRoshi(game, position));
                        break;
                    case "BladeTrap":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyBladeTrap(game, position, new Vector2(265, 130), game.link));
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
                    case "Wallmaster":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyWallmaster(game, position));
                        break;
                    case "Redead":
                        position = utility.GetEnemyPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                        enemies.Add(new EnemyRedead(game, position));
                        break;

                    default:
                        break;
                }

            }
        }
        public static void ParseWallsCSVFile()
        {
            string cwdPath = Directory.GetCurrentDirectory();
            cwdPath = Directory.GetCurrentDirectory();
            cwdPath = cwdPath.Replace(@"\bin\Debug\netcoreapp3.1", @"\Classes\Level\RoomCSV");
            if(roomNumber == 16)
            {
                cwdPath = Path.Combine(cwdPath, "walls16.csv");
            }
            else
            {
                cwdPath = Path.Combine(cwdPath, "walls.csv");
            }
            string[] lines = System.IO.File.ReadAllLines(cwdPath);
            lines = System.IO.File.ReadAllLines(cwdPath);
            Vector2 wallPos = new Vector2(0, 0);
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, float.Parse(segments[2]), float.Parse(segments[1]));
                WallTile wall;
                tiles.Add(wall = new WallTile(game, new TileSpriteFactory(game), wallPos));
                wall.drawLocation = wallPos;
            }
        }
        public static void ParseDoorsCSVFile()
        {
            string cwdPath = Directory.GetCurrentDirectory();
            cwdPath = Directory.GetCurrentDirectory();
            string[] lines;
            int doorvalue = 0;
            cwdPath = cwdPath.Replace(@"\bin\Debug\netcoreapp3.1", @"\Classes\Level\RoomCSV");
            cwdPath = Path.Combine(cwdPath, "doors.csv");
            lines = System.IO.File.ReadAllLines(cwdPath);
            Vector2 wallPos = new Vector2(0, 0);
            Vector2 stairPos = new Vector2(0, 0);
            Vector2 tpPos = new Vector2(0, 0);
            GateKeeperTile gatekeeper;
            StairsTile stair;
            TPTile tptile;
            bool locked;
            bool isLockedDoor;
            foreach (string line in lines)
            {
                string[] segments = line.Split(new string[] { "," },
                                    StringSplitOptions.None);
                if (int.Parse(segments[0]) == roomNumber)
                {
                    for (int i = 0; i< 4; i++)
                    {
                        doorvalue = i* 10 + int.Parse(segments[i + 1]);
                        locked = true;
                        isLockedDoor = false;
                        if (int.Parse(segments[i + 1]) == 1)
                        {
                            locked = false;
                        }
                        if (int.Parse(segments[i + 1]) == 2 || int.Parse(segments[i + 1]) == 6)
                        {
                            isLockedDoor = true;
                        }

            switch (i)
            {
                case 0:
                    doors.Add(new TopDoor(game, new RoomTextureStorage(game), doorvalue));
                    wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, 6, 0);

                    tiles.Add(gatekeeper = new GateKeeperTile(game, new TileSpriteFactory(game), wallPos, locked, isLockedDoor));
                    gatekeeper.drawLocation = wallPos;

                    wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, 7, 0);
                    tiles.Add(gatekeeper = new GateKeeperTile(game, new TileSpriteFactory(game), wallPos, locked, isLockedDoor));
                    gatekeeper.drawLocation = wallPos;

                    if(roomNumber == 16)
                    {
                        tpPos = utility.GetTopStairPosition(windowWidthFloor, windowHeightFloor, 1, -1);
                        tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), tpPos));
                        stair.drawLocation = tpPos;
                        wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, 2, -1);
                        tiles.Add(gatekeeper = new GateKeeperTile(game, new TileSpriteFactory(game), wallPos, false, false));
                        gatekeeper.drawLocation = wallPos;

                    }
                    else if (roomNumber == 17){
                        tpPos = utility.GetTopStairPosition(windowWidthFloor, windowHeightFloor, 7, 4);
                        tiles.Add(tptile = new TPTile(game, new TileSpriteFactory(game), tpPos));
                        tptile.drawLocation = tpPos;

                    }
                    else
                    {
                        stairPos = utility.GetTopStairPosition(windowWidthFloor, windowHeightFloor, 6, 0);
                        tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                        stair.drawLocation = stairPos;
                    }

                    break;
                case 1: //4,0 4,13
                    doors.Add(new LeftDoor(game, new RoomTextureStorage(game), doorvalue));
                    wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, 0, 4);

                    tiles.Add(gatekeeper = new GateKeeperTile(game, new TileSpriteFactory(game), wallPos, locked, isLockedDoor));
                    gatekeeper.drawLocation = wallPos;

                    stairPos = utility.GetLeftStairPosition(windowWidthFloor, windowHeightFloor, 0, 4);
                    tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                    stair.drawLocation = stairPos;
                    break;
                case 2:
                    doors.Add(new RightDoor(game, new RoomTextureStorage(game), doorvalue));

                    wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, 13, 4);

                    tiles.Add(gatekeeper = new GateKeeperTile(game, new TileSpriteFactory(game), wallPos, locked, isLockedDoor));
                    gatekeeper.drawLocation = wallPos;

                    stairPos = utility.GetRightStairPosition(windowWidthFloor, windowHeightFloor, 13, 4);
                    tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                    stair.drawLocation = stairPos;
                    break;
                case 3:
                    doors.Add(new BottomDoor(game, new RoomTextureStorage(game), doorvalue));

                    wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, 6, 8);

                    tiles.Add(gatekeeper = new GateKeeperTile(game, new TileSpriteFactory(game), wallPos, locked, isLockedDoor));
                    gatekeeper.drawLocation = wallPos;
                    wallPos = utility.GetBlockSecondaryItemPosition(windowWidthFloor, windowHeightFloor, 7, 8);

                    tiles.Add(gatekeeper = new GateKeeperTile(game, new TileSpriteFactory(game), wallPos, locked, isLockedDoor));
                    gatekeeper.drawLocation = wallPos;

                    stairPos = utility.GetBotStairPosition(windowWidthFloor, windowHeightFloor, 6, 8);
                    tiles.Add(stair = new StairsTile(game, new TileSpriteFactory(game), stairPos));
                    stair.drawLocation = stairPos;
                    break;
                default:
                    break;
            }
         }
    }
}
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

