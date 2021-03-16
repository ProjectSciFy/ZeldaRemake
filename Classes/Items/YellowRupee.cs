using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Items
{
    public class YellowRupee : IItem , ICollisionEntity
    {
        private ZeldaGame game;
        private ISprite itemSprite;
        private ItemSpriteFactory itemFactory;
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        public Vector2 position;
        public Vector2 drawLocation;
        public YellowRupee(ZeldaGame game, ItemSpriteFactory itemFactory, Vector2 location)
        {
            this.game = game;
            this.position = location;
            this.itemFactory = itemFactory;
            this.itemSprite = itemFactory.YellowRupee();
            game.collisionManager.collisionEntities.Add(this, hitbox);
        }
        public void Update()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
            hitbox.Width = (int)spriteSize.X;
            hitbox.Height = (int)spriteSize.Y;

            game.collisionManager.collisionEntities[this] = hitbox;
        }

        public void Draw()
        {
            itemSprite.Draw(position);
        }

        public Rectangle CollisionRectangle()
        {
            return hitbox;
        }
    }
}
