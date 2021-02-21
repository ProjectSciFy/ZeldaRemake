using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemySpriteFactory
    {
        private EeveeSim game;
        private EnemyStalfos stalfos;
        private IEnemy enemy;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;

        //Constructors for each enemy
        public EnemySpriteFactory(EeveeSim game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Stalfos constructor
        public EnemySpriteFactory(EnemyStalfos enemy)
        {
            this.game = enemy.game;
            this.stalfos = enemy;
            enemy.game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            enemy.game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Blade trap methods

        //Gel methods

        //Goriya methods

        //Keese methods

        //Stalfos methods
        public void spawnStalfos(EnemyStalfos enemy)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = 0;
            stalfos.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3));
        }

        //Wallmaster methods

    }
}
