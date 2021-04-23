using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{
    public class AquamentusSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D bossSpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;

        public AquamentusSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Bosses", out bossSpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Aquamentus methods
        public UniversalSprite SpawnAquamentus()
        {
            return new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, enemyLayerDepth);
        }

        public UniversalSprite AquamentusMovingRight()
        {
            return new UniversalSprite(game, bossSpriteSheet, new Rectangle(49, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }

        public UniversalSprite AquamentusMovingLeft()
        {
            return new UniversalSprite(game, bossSpriteSheet, new Rectangle(49, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }

        public UniversalSprite AquamentusRoaringRight()
        {
            return new UniversalSprite(game, bossSpriteSheet, new Rectangle(1, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }

        public UniversalSprite AquamentusRoaringLeft()
        {
            return new UniversalSprite(game, bossSpriteSheet, new Rectangle(1, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }
    }
}
