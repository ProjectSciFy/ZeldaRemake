using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Interfaces;

namespace CSE3902_Game_Sprint0.Classes.Tiles
{
    public class StairsTile : ITile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        private ISprite tileSprite { get; set; }
        private TileSpriteFactory tileFactory { get; set; }
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public Vector2 position { get; set; }
        public float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; } = 6;
        public Vector2 drawLocation { get; set; }
        public Vector2 spriteSize { get; set; } = new Vector2(16, 16);

        public StairsTile(ZeldaGame game, TileSpriteFactory tileFactory, Vector2 location)
        {
            this.game = game;
            this.position = location;
            this.tileFactory = tileFactory;
            this.tileSprite = tileFactory.StairsTile();
            this.spriteScalar = game.util.spriteScalar;
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }
        public void AddToCollision()
        {
            game.collisionManager.collisionEntities.Add(this, CollisionRectangle());
        }
        public void Update()
        {
            collisionRectangle.X = (int)drawLocation.X;
            collisionRectangle.Y = (int)drawLocation.Y;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - HITBOX_OFFSET;

            game.collisionManager.collisionEntities[this] = collisionRectangle;
        }

        public void Draw()
        {
            tileSprite.Draw(position);
        }
    }
}
