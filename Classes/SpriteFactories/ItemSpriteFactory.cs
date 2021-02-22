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
        private EeveeSim game;
        private Item item;
        private Texture2D itemSpriteSheet;

        public ItemSpriteFactory(Item item)
        {
            this.game = item.game;
            game.spriteSheets.TryGetValue("ItemsAndWeapons", out itemSpriteSheet);
            this.item = item;
        }

        public void Boomerang()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(128, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Bomb()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(136, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Bow()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(144, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Arrow()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(152, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Key()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(240, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Compass()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(258, 1, 11, 12), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Shard()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(275, 3, 10, 10), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Heart()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(0, 0, 7, 8), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void HeartContainer()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(25, 1, 13, 13), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Clock()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(58, 0, 11, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Food()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(96, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void YellowRupee()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(72, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void RedPotion()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(80, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Map()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(88, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void BlueRupee()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(72, 16, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void SecondPotion()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(80, 16, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Letter()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(88, 16, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Sword()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(104, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Shield()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(120, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void RedCandle()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(160, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void BlueCandle()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(160, 16, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void RedRing()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(168, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void BlueRing()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(168, 16, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Bracelet()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(176, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Flute()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(184, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Raft()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(192, 0, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Stepladder()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(208, 0, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Rod()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(224, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Book()
        {
            item.itemSprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(232, 0, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        //public void BoomerangDown(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = 0;
        //    boomerang.velocity.Y = 1;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
        //public void BoomerangUp(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = 0;
        //    boomerang.velocity.Y = -1;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
        //public void BoomerangRight(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = 1;
        //    boomerang.velocity.Y = 0;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
        //public void BoomerangLeft(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = -1;
        //    boomerang.velocity.Y = 0;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
        //public void BoomerangNE(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = 1;
        //    boomerang.velocity.Y = -1;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
        //public void BoomerangSE(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = 1;
        //    boomerang.velocity.Y = 1;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
        //public void BoomerangSW(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = -1;
        //    boomerang.velocity.Y = 1;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
        //public void BoomerangNW(Boomerang boomerang)
        //{
        //    boomerang.spriteSize.X = 16;
        //    boomerang.spriteSize.Y = 16;
        //    boomerang.velocity.X = -1;
        //    boomerang.velocity.Y = -1;
        //    boomerang.mySprite = new UniversalSprite(game, itemSpriteSheet, new Rectangle(179, 17, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        //}
    }
}
