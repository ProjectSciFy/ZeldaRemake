using CSE3902_Game_Sprint0.Classes.Items;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;

namespace CSE3902_Game_Sprint0.Classes.Controllers.EnemyCommands
{
    class PreviousEnemy : ICommand
    {
        private EeveeSim game;
        public PreviousEnemy(EeveeSim game)
        {
            this.game = game;
        }

        public void Execute()
        {
            switch (this.game.currentEnemy)
            {
                case EeveeSim.Enemies.Stalfos:
                    this.game.drawnEnemy = new EnemyWallmaster(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = EeveeSim.Enemies.Wallmaster;
                    break;
                case EeveeSim.Enemies.Gel:
                    this.game.drawnEnemy = new EnemyStalfos(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = EeveeSim.Enemies.Stalfos;
                    break;
                case EeveeSim.Enemies.Keese:
                    this.game.drawnEnemy = new EnemyGel(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = EeveeSim.Enemies.Gel;
                    break;
                case EeveeSim.Enemies.BladeTrap:
                    this.game.drawnEnemy = new EnemyKeese(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = EeveeSim.Enemies.Keese;

                    break;
                case EeveeSim.Enemies.Goriya:
                    this.game.drawnEnemy = new BladeTrap(this.game, new Vector2(400, 100), new Vector2(100, 100), this.game.link);
                    this.game.currentEnemy = EeveeSim.Enemies.BladeTrap;
                    break;
                case EeveeSim.Enemies.Aquamentus:
                    this.game.drawnEnemy = new EnemyGoriya(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = EeveeSim.Enemies.Goriya;
                    break;
                case EeveeSim.Enemies.Wallmaster:
                    this.game.drawnEnemy = new EnemyAquamentus(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = EeveeSim.Enemies.Aquamentus;
                    break;
                default:
                    break;
            }
        }
    }
}
