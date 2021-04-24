using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D enemySpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;
        private WallmasterHelper wallmaster { get; set; }
        public WallmasterSpriteFactory(ZeldaGame game)
        {
            this.wallmaster = new WallmasterHelper();
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite WallmasterIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, wallmaster.moving, Color.White, SpriteEffects.None, wallmaster.movingFrame, wallmaster.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite KillWallmaster()
        {
            return new UniversalSprite(game, linkSpriteSheet, wallmaster.kill, Color.White, SpriteEffects.None, wallmaster.killFrame, wallmaster.killLimiter, enemyLayerDepth);
        }
        public UniversalSprite WallmasterMovingUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, wallmaster.moving, Color.White, SpriteEffects.None, wallmaster.movingFrame, wallmaster.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite WallmasterMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, wallmaster.moving, Color.White, SpriteEffects.None, wallmaster.movingFrame, wallmaster.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite WallmasterMovingDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, wallmaster.moving, Color.White, SpriteEffects.None, wallmaster.movingFrame, wallmaster.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite WallmasterMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, wallmaster.moving, Color.White, SpriteEffects.None, wallmaster.movingFrame, wallmaster.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite WallmasterHiding()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None, new Vector2(1, 1), wallmaster.hidingLimiter, enemyLayerDepth);
        }
    }
}
