using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead
{
    public class RedeadSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D linkSpriteSheet;
        private readonly Texture2D enemySpriteSheet;
        private float linkLayerDepth { get; set; } = 0.2f;
        private RedeadHelper redead { get; set; }
        public RedeadSpriteFactory(ZeldaGame game)
        {
            this.redead = new RedeadHelper();
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnRedead()
        {

            return new UniversalSprite(game, linkSpriteSheet, redead.spawn, Color.White, SpriteEffects.None, redead.spawnFrame, redead.spawnLimiter, linkLayerDepth);
        }
        public UniversalSprite RedeadMoving()
        {
            return new UniversalSprite(game, enemySpriteSheet, redead.moving, Color.White, SpriteEffects.None, redead.movingFrame, redead.movementlimiter, linkLayerDepth);
        }
        public UniversalSprite RedeadIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, redead.idle, Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
    }
}
