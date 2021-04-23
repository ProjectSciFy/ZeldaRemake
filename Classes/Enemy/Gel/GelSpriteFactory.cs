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
        public GelSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }
        public UniversalSprite SpawnGel()
        {
            return new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, enemyLayerDepth);
        }

        public UniversalSprite GelMovingUp()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }

        public UniversalSprite GelMovingDown()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }

        public UniversalSprite GelIdle()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }

        public UniversalSprite GelMovingLeft()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }
        public UniversalSprite GelMovingRight()
        {
            return new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2, enemyLayerDepth);
        }
    }
}
