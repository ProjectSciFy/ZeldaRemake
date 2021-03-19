using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

/*This file is a sprite-factory which will contain otherwise frowned upon "magic numbers".*/
namespace CSE3902_Game_Sprint0.Classes.Enemy.Goriya
{
    public class GoriyaSpriteFactory
    {
        private ZeldaGame game;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private float enemyLayerDepth = 0.2f;
        public GoriyaSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Goriya methods
        public UniversalSprite SpawnGoriya()
        {
           return new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(322, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingDown()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 2), 10, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleDown()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(322, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 2), 10, enemyLayerDepth);
        }
    }
}
