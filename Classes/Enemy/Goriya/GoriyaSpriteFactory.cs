using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Goriya
{
    public class GoriyaSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D enemySpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;
        private GoriyaHelper goriya { get; set; }
        public GoriyaSpriteFactory(ZeldaGame game)
        {
            this.goriya = new GoriyaHelper();
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnGoriya()
        {
            return new UniversalSprite(game, linkSpriteSheet, goriya.spawn, Color.White, SpriteEffects.None, goriya.spawnFrame, goriya.spawnLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.up, Color.White, SpriteEffects.None, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.down, Color.White, SpriteEffects.None, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.leftOrRight, Color.White, SpriteEffects.None, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.leftOrRight, Color.White, SpriteEffects.FlipHorizontally, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.down, Color.White, SpriteEffects.None, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.up, Color.White, SpriteEffects.None, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.leftOrRight, Color.White, SpriteEffects.None, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GoriyaIdleLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, goriya.leftOrRight, Color.White, SpriteEffects.FlipHorizontally, goriya.movingFrame, goriya.movementLimiter, enemyLayerDepth);
        }
    }
}
