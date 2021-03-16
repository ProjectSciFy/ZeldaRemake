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
    public class Room
    {
        private Background background;
        private List<ITile> tiles;
        private List<IItem> items;
        private List<IEnemy> enemies;
        private List<IDoor> doors;

        private int roomNumber;
        public Room(ZeldaGame game, int RoomNumber, List<ITile> tilesLoaded, List<IItem> itemsLoaded, List<IEnemy> enemiesLoaded, List<IDoor> doorsLoaded)
        {
            roomNumber = RoomNumber;
            tiles = tilesLoaded;
            items = itemsLoaded;
            enemies = enemiesLoaded;
            doors = doorsLoaded;
            background = new Background(game, roomNumber);

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

