using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi
{
    public class RoshiSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D spriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;

        public RoshiSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Roshi", out spriteSheet);
        }

        //Aquamentus methods
        public UniversalSprite SpawnRoshi()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(88, 350, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 6), 30, enemyLayerDepth);
        }

        public UniversalSprite RoshiMoving()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(596, 347, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 1), 15, enemyLayerDepth);
        }

        public UniversalSprite RoshiKiBlast()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(87, 398, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 6), 10, enemyLayerDepth);
        }

        public UniversalSprite RoshiKamehameha()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(78, 467, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 13), 10, enemyLayerDepth);
        }
        public UniversalSprite KamehamehaProjectile()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(264, 570, 315, 80), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, enemyLayerDepth);
        }
        public UniversalSprite RoshiDamaged()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(78, 522, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 3), 10, enemyLayerDepth);
        }
        public UniversalSprite RoshiDying()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(254, 522, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 11), 30, enemyLayerDepth);
        }
        public UniversalSprite RoshiLift()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(689, 464, 44, 45), Color.White, SpriteEffects.None, new Vector2(1, 1), 30, enemyLayerDepth);
        }
        public UniversalSprite RoshiCharge()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(733, 464, 44, 45), Color.White, SpriteEffects.None, new Vector2(1, 1), 30, enemyLayerDepth);
        }
        public UniversalSprite RoshiThrow()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(777, 464, 44, 45), Color.White, SpriteEffects.None, new Vector2(1, 1), 30, enemyLayerDepth);
        }
        public UniversalSprite RoshiRest()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(821, 464, 44, 45), Color.White, SpriteEffects.None, new Vector2(1, 1), 30, enemyLayerDepth);
        }
        public UniversalSprite SpiritBombCharge()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(526, 224, 91, 91), Color.White, SpriteEffects.None, new Vector2(1, 5), 136, enemyLayerDepth);
        }
        public UniversalSprite SpiritBombProjectile()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(890, 224, 91, 91), Color.White, SpriteEffects.None, new Vector2(1, 1), 30, enemyLayerDepth);
        }
        public UniversalSprite Explosion()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(1011, 240, 76, 62), Color.White, SpriteEffects.None, new Vector2(1, 1), 30, enemyLayerDepth);
        }
    }
}
