using CSE3902_Game_Sprint0.Classes.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterSpriteFactory
    {
        private ZeldaGame game;
        private Texture2D enemySpriteSheet;
        private float enemyLayerDepth = 0.2f;

        public WallmasterSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
        }

        //Wallmaster methods
        public UniversalSprite WallmasterIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, enemyLayerDepth);
        }
        public UniversalSprite WallmasterMovingUp()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, enemyLayerDepth);
        }

        public UniversalSprite WallmasterMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, enemyLayerDepth);
        }

        public UniversalSprite WallmasterMovingDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, enemyLayerDepth);
        }

        public UniversalSprite WallmasterMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, enemyLayerDepth);
        }
    }
}
