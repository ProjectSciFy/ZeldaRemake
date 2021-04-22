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
using CSE3902_Game_Sprint0.Classes.Header;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class Room
    {
        private Background background { get; set; }
        private List<ITile> tiles;
        public List<IItem> items { get; set; }
        private List<IEnemy> enemies;
        private List<IDoor> doors;
        private ZeldaGame game { get; set; }

        //player hud related variables:
        public playerHUD pHUD { get; set; }
        private HudSpriteFactory hudFactory { get; set; }

        private ISprite bowSprite { get; set; }
        private int maxLives { get; set; } = 16;
        private int keyCounter { get; set; }
        private int bombCounter { get; set; }
        private int yellowrupeeCounter { get; set; }

        private int linkLevelCount { get; set; }

        private int xpCounter { get; set; }


        public int roomNumber;
        public Room(ZeldaGame game, int RoomNumber, List<ITile> tilesLoaded, List<IItem> itemsLoaded, List<IEnemy> enemiesLoaded, List<IDoor> doorsLoaded)
        {
            roomNumber = RoomNumber;
            tiles = tilesLoaded;
            items = itemsLoaded;
            enemies = enemiesLoaded;
            doors = doorsLoaded;
            this.game = game;
            background = new Background(game, roomNumber);

            //player HUD:
            this.keyCounter = game.util.numKeys;
            this.bombCounter = game.util.numBombs;
            this.yellowrupeeCounter = game.util.numYrups;
            this.hudFactory = game.hudSpriteFactory;
            pHUD = new playerHUD(game, hudFactory);

            //bow pick-up workaround:
            bowSprite = hudFactory.staticBow();
        }
        public void Initialize()
        {
            foreach (ITile tile in tiles)
            {
                if (tile is BlockTile)
                {
                    ((BlockTile)tile).AddToCollision();
                }
                else if (tile is WallTile)
                {
                    ((WallTile)tile).AddToCollision();
                }
            }
        }
        public void Update()
        {
            pHUD.Update();
            foreach (IEnemy enemy in enemies.ToArray())
            {
                enemy.Update();
            }
            foreach (ITile tile in tiles.ToArray())
            {
                tile.Update();
            }
            foreach (IItem item in items.ToArray())
            {
                item.Update();
            }
            foreach (IDoor door in doors.ToArray())
            {
                door.Update();
            }

        }
        public int getRoomNumber()
        {
            return roomNumber;
        }
        public List<IDoor> getDoors()
        {
            return doors;
        }
        public List<ITile> getTiles()
        {
            return tiles;
        }
        public void addDoor(IDoor door)
        {
            doors.Add(door);
        }
        public void removeDoor(IDoor door)
        {
            doors.Remove(door);
        }
        public void removeEnemy(IEnemy entity)
        {
            enemies.Remove(entity);
        }
        public void removeItem(IItem entity)
        {
            items.Remove(entity);
            //check which type of item it is, specifically key, blue or yellow rupee, will need to update counters accordingly.
            if (entity is Key)
            {
                game.util.numKeys += 1;
            }
            else if (entity is BlueRupee)
            {
                game.util.numYrups += 5;
            }
            else if (entity is YellowRupee)
            {
                game.util.numYrups += 1;
            }
            else if (entity is Heart)
            {
                game.util.numLives += 1;
            }
            else if (entity is HeartContainer)
            {
                game.util.numLives = maxLives;
            }
            else if (entity is Fairy)
            {
                game.util.numLives += 10;
            }
            else if (entity is Map)
            {
                game.util.hasMap = true;
            }
            else if (entity is Compass)
            {
                game.util.hasCompass = true;
            }
            else if (entity is Bomb)
            {
                game.util.numBombs += 1;
            }
            else if (entity is Bow)
            {
                game.util.hasBow = true;
            }
        }
        public void closeDoorways()
        {
            foreach (ITile tile in tiles)
            {
                if (tile is GateKeeperTile && ((GateKeeperTile)tile).locked == false)
                {
                    ((GateKeeperTile)tile).locked = true;
                    ((GateKeeperTile)tile).isLockedDoor = true;
                }
            }
        }
        public void lockDoor(int doorDirection)
        {
            switch (doorDirection)
            {
                case 0: //TOP DOOR
                    doors[0] = new TopDoor(game, new RoomTextureStorage(game), 2);
                    break;
                case 1: //LEFT DOOR
                    doors[1] = new LeftDoor(game, new RoomTextureStorage(game), 12);
                    break;
                case 2: //RIGHT DOOR
                    doors[2] = new RightDoor(game, new RoomTextureStorage(game), 22);
                    break;
                case 3: //BOTTOM DOOR
                    doors[3] = new BottomDoor(game, new RoomTextureStorage(game), 32);
                    break;
                default:
                    break;
            }
        }
        public void Draw()
        {
            background.Draw();
            pHUD.Draw();
            
            if (game.linkStateMachine.bowTimer > 0)
            {
                bowSprite.Draw(new Vector2(game.link.drawLocation.X - 20, game.link.drawLocation.Y - 30));
            }
            
            
            foreach (IDoor door in doors)
            {
                door.Draw();
            }
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
        }
    }
}

