using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.BladeTrap
{
    public class BladeTrapSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D enemySpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;
        public BladeTrapHelper bladetrap { get; set; }
        public BladeTrapSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            this.bladetrap = new BladeTrapHelper();
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnBladeTrap()
        {
            return new UniversalSprite(game, enemySpriteSheet, bladetrap.trap, Color.White, SpriteEffects.None, new Vector2(1, 1), bladetrap.spawnLimiter, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, bladetrap.trap, Color.White, SpriteEffects.None, new Vector2(1, 1), bladetrap.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapUp()
        {

            return new UniversalSprite(game, enemySpriteSheet, bladetrap.trap, Color.White, SpriteEffects.None, new Vector2(1, 1), bladetrap.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, bladetrap.trap, Color.White, SpriteEffects.None, new Vector2(1, 1), bladetrap.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, bladetrap.trap, Color.White, SpriteEffects.None, new Vector2(1, 1), bladetrap.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite BladeTrapLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, bladetrap.trap, Color.White, SpriteEffects.None, new Vector2(1, 1), bladetrap.movementLimiter, enemyLayerDepth);
        }
    }
}
