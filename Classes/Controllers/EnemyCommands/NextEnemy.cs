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
using CSE3902_Game_Sprint0.Classes.Enemy.OldMan;

namespace CSE3902_Game_Sprint0.Classes.Controllers.EnemyCommands
{
    public class NextEnemy : ICommand
    {
        private ZeldaGame game;
        public NextEnemy(ZeldaGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            switch (this.game.currentEnemy)
            {
                case ZeldaGame.Enemies.Stalfos:
                    this.game.drawnEnemy = new EnemySlime(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = ZeldaGame.Enemies.Gel;
                    break;
                case ZeldaGame.Enemies.Gel:
                    this.game.drawnEnemy = new EnemyKeese(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = ZeldaGame.Enemies.Keese;
                    break;
                case ZeldaGame.Enemies.Keese:
                    this.game.drawnEnemy = new BladeTrap(this.game, new Vector2(400, 100), new Vector2(100, 100), this.game.link);
                    this.game.currentEnemy = ZeldaGame.Enemies.BladeTrap;
                    break;
                case ZeldaGame.Enemies.BladeTrap:
                    this.game.drawnEnemy = new EnemyGoriya(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = ZeldaGame.Enemies.Goriya;
                    break;
                case ZeldaGame.Enemies.Goriya:
                    this.game.drawnEnemy = new EnemyAquamentus(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = ZeldaGame.Enemies.Aquamentus;
                    break;
                case ZeldaGame.Enemies.Aquamentus:
                    this.game.drawnEnemy = new EnemyWallmaster(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = ZeldaGame.Enemies.Wallmaster;
                    break;
                case ZeldaGame.Enemies.Wallmaster:
                    this.game.drawnEnemy = new EnemyOldMan(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = ZeldaGame.Enemies.OldMan;
                    break;
                case ZeldaGame.Enemies.OldMan:
                    this.game.drawnEnemy = new EnemyStalfos(this.game, new Vector2(400, 100));
                    this.game.currentEnemy = ZeldaGame.Enemies.Stalfos;
                    break;
                default:
                    break;
            }
        }
    }
}