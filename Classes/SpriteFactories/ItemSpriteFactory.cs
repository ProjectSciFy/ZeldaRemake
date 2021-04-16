using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Items;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.Projectiles;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class ItemSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private Texture2D itemSpriteSheet;
        private float itemDepth { get; set; } = .4f;
        private int itemLimiter { get; set; } = 10;
        
        public ItemSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("ItemsAndWeapons", out itemSpriteSheet);
        }

        public UniversalSprite Boomerang()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(127, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite Bomb()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(136, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite Bow()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(145, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite Key()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(240, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite Compass()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(258, 1, 11, 12), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }
        public UniversalSprite Triforce()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(275, 3, 10, 10), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite Heart()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(0, 0, 7, 8), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite HeartContainer()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(25, 1, 13, 13), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        //public UniversalSprite Clock()
        //{
        //    return new UniversalSprite(game, itemSpriteSheet, new Rectangle(58, 0, 11, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        //}
        public UniversalSprite YellowRupee()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(72, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite Map()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(88, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }
        public UniversalSprite BlueRupee()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(72, 16, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), itemLimiter, itemDepth);
        }

        public UniversalSprite Fairy()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(40, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), itemLimiter, itemDepth);
        }
    }
}
