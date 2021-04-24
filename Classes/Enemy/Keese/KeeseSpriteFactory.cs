using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese
{
    public class KeeseSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D enemySpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private float linkLayerDepth { get; set; } = 0.2f;
        private KeeseHelper keese { get; set; }
        public KeeseSpriteFactory(ZeldaGame game)
        {
            this.keese = new KeeseHelper();
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnKeese()
        {
            return new UniversalSprite(game, linkSpriteSheet, keese.spawn, Color.White, SpriteEffects.None, keese.spawnFrame, keese.spawnLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, new Vector2(1, 1), keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorth()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorthEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouthEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouth()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingSouthWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseFlyingNorthWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.flyingLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorth()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorthEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouthEast()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouth()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingSouthWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }

        public UniversalSprite KeeseLandingNorthWest()
        {
            return new UniversalSprite(game, enemySpriteSheet, keese.moving, Color.White, SpriteEffects.None, keese.movingFrame, keese.landigLimiter, linkLayerDepth);
        }
    }



}