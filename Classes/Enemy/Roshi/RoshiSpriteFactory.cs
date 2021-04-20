using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Scripts;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi
{
    public class RoshiSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private Texture2D spriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;

        public RoshiSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Roshi", out spriteSheet);
        }

        //Aquamentus methods
        public UniversalSprite SpawnRoshi()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(88, 350, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 4), 30, enemyLayerDepth);
        }

        public UniversalSprite RoshiMoving()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(264, 350, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 1), 15, enemyLayerDepth);
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
            return new UniversalSprite(game, spriteSheet, new Rectangle(385, 319, 315, 80), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, enemyLayerDepth);
        }
        public UniversalSprite RoshiDamaged()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(78, 522, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 3), 10, enemyLayerDepth);
        }
        public UniversalSprite RoshiDying()
        {
            return new UniversalSprite(game, spriteSheet, new Rectangle(254, 522, 44, 42), Color.White, SpriteEffects.None, new Vector2(1, 11), 30, enemyLayerDepth);
        }
    }
}
