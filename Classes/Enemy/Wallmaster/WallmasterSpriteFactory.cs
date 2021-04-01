﻿using CSE3902_Game_Sprint0.Classes.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*This file is a sprite-factory which will contain otherwise frowned upon "magic numbers".*/
namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterSpriteFactory
    {
        private ZeldaGame game;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private float enemyLayerDepth = 0.2f;

        public WallmasterSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Wallmaster methods
        public UniversalSprite WallmasterIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, enemyLayerDepth);
        }
        public UniversalSprite KillWallmaster()
        {
            return new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, enemyLayerDepth);
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