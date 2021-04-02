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
        private Background background;
        private List<ITile> tiles;
        private List<IItem> items;
        private List<IEnemy> enemies;
        private List<IDoor> doors;
        private ZeldaGame game;

        //player hud related variables:
        private playerHUD pHUD;
        private HudSpriteFactory hudFactory;
        private int maxLives = 5;
        private int keyCounter;
        private int bluerupeeCounter;
        private int yellowrupeeCounter;


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
            this.keyCounter = game.numKeys;
            this.bluerupeeCounter = game.numBrups;
            this.yellowrupeeCounter = game.numYrups;
            this.hudFactory = game.hudSpriteFactory;
            pHUD = new playerHUD(game, hudFactory);
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
        }
        public int getRoomNumber()
        {
            return roomNumber;
        }
        public List<IDoor> getDoors()
        {
            return doors;
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
                game.numKeys += 1;
            }
            else if (entity is BlueRupee)
            {
                game.numBrups += 1;
            }
            else if (entity is YellowRupee)
            {
                game.numYrups += 1;
            }
            else if (entity is Heart)
            {
                game.numLives += 1;
            }
            else if (entity is HeartContainer)
            {
                game.numLives = maxLives;
            }
            else if (entity is Fairy)
            {
                game.numLives += 5;
            }
        }

        public void Draw()
        {
            background.Draw();
            pHUD.Draw();
            
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

