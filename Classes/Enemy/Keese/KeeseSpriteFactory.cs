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
        private ZeldaGame game { get; set; }
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private float linkLayerDepth { get; set; } = 0.2f;
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
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorthEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouthEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouth()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouthWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorthWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorth()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorthEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingEast()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouthEast()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouth()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouthWest()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingWest()
        {
           return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorthWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20, linkLayerDepth);
        }
    }



}