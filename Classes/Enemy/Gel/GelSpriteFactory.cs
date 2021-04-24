using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Gel
{
    public class GelSpriteFactory
    {

        private ZeldaGame game { get; set; }
        private readonly Texture2D enemySpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;
        private GelHelper gel { get; set; }
        public GelSpriteFactory(ZeldaGame game)
        {
            this.gel = new GelHelper();
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnGel()
        {
            return new UniversalSprite(game, linkSpriteSheet, gel.spawn, Color.White, SpriteEffects.None, gel.spawnFrame, gel.spawnLimiter, enemyLayerDepth);
        }

        public UniversalSprite GelMovingUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, gel.movement, Color.White, SpriteEffects.None, gel.movementFrame, gel.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite GelMovingDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, gel.movement, Color.White, SpriteEffects.None, gel.movementFrame, gel.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite GelIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, gel.movement, Color.White, SpriteEffects.None, gel.movementFrame, gel.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite GelMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, gel.movement, Color.White, SpriteEffects.None, gel.movementFrame, gel.movementLimiter, enemyLayerDepth);
        }
        public UniversalSprite GelMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, gel.movement, Color.White, SpriteEffects.None, gel.movementFrame, gel.movementLimiter, enemyLayerDepth);
        }
    }
}
