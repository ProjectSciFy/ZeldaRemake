using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Items
{
    public class Map : IItem
    {
        private ZeldaGame game;
        private ISprite itemSprite;
        private ItemSpriteFactory itemFactory;
        public Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        public Vector2 position;
        public Map(ZeldaGame game, ItemSpriteFactory itemFactory, Vector2 location)
        {
            this.game = game;
            this.position = location;
            this.itemFactory = itemFactory;
            this.itemSprite = itemFactory.Map();
        }
        public void Update()
        {
        }

        public void Draw()
        {
            itemSprite.Draw(position);
        }
    }
}
