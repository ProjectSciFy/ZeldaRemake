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
        public RedeadSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnRedead()
        {

            return new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, linkLayerDepth);
        }
        public UniversalSprite RedeadMoving()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(383, 164, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }
        public UniversalSprite RedeadIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(416, 164, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
    }
}
