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
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;

        public EnemySpriteFactory(EeveeSim game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Blade trap methods

        //Gel methods

        //Goriya methods

        //Keese methods

        //Stalfos methods

        public void spawnStalfos(EnemyStalfos enemy)
        {
            enemy.mySprite = new AnimatedSprite(game, linkSpriteSheet, enemy.drawLocation, enemy.velocity, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3));
        }

        //Wallmaster methods
    }
}
