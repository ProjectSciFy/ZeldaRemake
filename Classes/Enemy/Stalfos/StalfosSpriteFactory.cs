using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Stalfos
{
    public class StalfosSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D linkSpriteSheet;
        private readonly Texture2D enemySpriteSheet;
        private float linkLayerDepth { get; set; } = 0.2f;
        private StalfosHelper stalfos { get; set; }
        public StalfosSpriteFactory(ZeldaGame game)
        {
            this.stalfos = new StalfosHelper();
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnStalfos()
        {

            return new UniversalSprite(game, linkSpriteSheet, stalfos.spawn, Color.White, SpriteEffects.None, stalfos.spawnFrame, stalfos.spawnLimiter, linkLayerDepth);
        }

        public UniversalSprite StalfosMovingUp()
        {

            return new UniversalSprite(game, enemySpriteSheet, stalfos.moving, Color.White, SpriteEffects.None, stalfos.movingFrame, stalfos.movementLimiter, linkLayerDepth);
        }

        public UniversalSprite StalfosMovingDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, stalfos.moving, Color.White, SpriteEffects.None, stalfos.movingFrame, stalfos.movementLimiter, linkLayerDepth);
        }

        public UniversalSprite StalfosMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, stalfos.moving, Color.White, SpriteEffects.None, stalfos.movingFrame, stalfos.movementLimiter, linkLayerDepth);
        }

        public UniversalSprite StalfosMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, stalfos.moving, Color.White, SpriteEffects.None, stalfos.movingFrame, stalfos.movementLimiter, linkLayerDepth);
        }
        public UniversalSprite StalfosIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, stalfos.moving, Color.White, SpriteEffects.None, stalfos.movingFrame, stalfos.movementLimiter, linkLayerDepth);
        }
    }
}
