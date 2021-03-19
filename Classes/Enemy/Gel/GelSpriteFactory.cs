using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Gel;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.OldMan;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*This file is a sprite-factory which will contain otherwise frowned upon "magic numbers".*/
namespace CSE3902_Game_Sprint0.Classes.Enemy.Gel
{
    public class GelSpriteFactory
    {

        private ZeldaGame game;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private float enemyLayerDepth = 0.2f;
        public GelSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        //Gel methods
        public UniversalSprite SpawnGel()
        {
           return new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, enemyLayerDepth);
        }

        public UniversalSprite GelMovingUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }

        public UniversalSprite GelMovingDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }

        public UniversalSprite GelIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }

        public UniversalSprite GelMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }

        public UniversalSprite GelMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }
    }
}
