using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese
{
    public class KeeseSpriteFactory
    {
        private ZeldaGame game;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private float linkLayerDepth = 0.2f;
        public KeeseSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnKeese()
        {
                  return new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, linkLayerDepth);
        }

        public UniversalSprite KeeseIdle()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorth()
        {
            //keese.velocity.X = 0;
            //keese.velocity.Y = -2;
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorthEast()
        {
            //keese.velocity.X = 2;
            //keese.velocity.Y = -2;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingEast()
        {
            
            //keese.velocity.X = 2;
            //keese.velocity.Y = 0;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouthEast()
        {
            //keese.velocity.X = 2;
            //keese.velocity.Y = 2;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouth()
        {
            //keese.velocity.X = 0;
            //keese.velocity.Y = 2;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouthWest()
        {
            //keese.velocity.X = -2;
            //keese.velocity.Y = 2;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingWest()
        {
            //keese.velocity.X = -2;
            //keese.velocity.Y = 0;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorthWest()
        {
           
            //keese.velocity.X = -2;
            //keese.velocity.Y = -2;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorth()
        {
            //keese.velocity.X = 0;
            //keese.velocity.Y = -1;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorthEast()
        {
            //keese.velocity.X = 1;
            //keese.velocity.Y = -1;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingEast()
        {
            //keese.velocity.X = 1;
            //keese.velocity.Y = 0;
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouthEast()
        {
          
            //keese.velocity.X = 1;
            //keese.velocity.Y = 1;
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouth()
        {
            //keese.velocity.X = 0;
            //keese.velocity.Y = 1;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouthWest()
        {
            //keese.velocity.X = -1;
            //keese.velocity.Y = 1;
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingWest()
        {
           
            //keese.velocity.X = -1;
            //keese.velocity.Y = 0;
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorthWest()
        {
            //keese.velocity.X = -1;
            //keese.velocity.Y = -1;
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }
    }



}