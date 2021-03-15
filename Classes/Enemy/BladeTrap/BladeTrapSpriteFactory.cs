using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.BladeTrap
{
    public class BladeTrapSpriteFactory
    {
        private ZeldaGame game;
        private Texture2D enemySpriteSheet;
        private float enemyLayerDepth = 0.2f;
        public BladeTrapSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
        }

        //Blade trap methods
        public UniversalSprite BladeTrapIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapUp()
        {

            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, enemyLayerDepth);
        }

        public UniversalSprite BladeTrapDown()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, enemyLayerDepth);
        }


    }
}
