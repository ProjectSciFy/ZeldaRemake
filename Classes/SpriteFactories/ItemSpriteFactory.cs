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
        private ZeldaGame game;
        private Texture2D itemSpriteSheet;
        private Texture2D linkSpriteSheet;

        public ItemSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("ItemsAndWeapons", out itemSpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        public UniversalSprite Boomerang()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(128, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite Bomb()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(136, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite Bow()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(144, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite Key()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(240, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        //public UniversalSprite Compass()
        //{
        //    return new UniversalSprite(game, itemSpriteSheet, new Rectangle(258, 1, 11, 12), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        //}
        public UniversalSprite Triforce()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(275, 3, 10, 10), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite Heart()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(0, 0, 7, 8), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite HeartContainer()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(25, 1, 13, 13), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        //public UniversalSprite Clock()
        //{
        //    return new UniversalSprite(game, itemSpriteSheet, new Rectangle(58, 0, 11, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        //}
        public UniversalSprite YellowRupee()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(72, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite Map()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(88, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite BlueRupee()
        {
            return new UniversalSprite(game, itemSpriteSheet, new Rectangle(72, 16, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
    }
}
