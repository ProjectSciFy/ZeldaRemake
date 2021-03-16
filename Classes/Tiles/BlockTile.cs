using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Tiles
{
    public class BlockTile : ITile, ICollisionEntity
    {
        private ZeldaGame game;
        private ISprite tileSprite;
        private TileSpriteFactory tileFactory;
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public Vector2 position;
        public float spriteScalar;
        public BlockTile(ZeldaGame game, TileSpriteFactory tileFactory, Vector2 location)
        {
            this.game = game;
            this.position = location;
            this.tileFactory = tileFactory;
            this.tileSprite = tileFactory.BlockTile();
            game.collisionManager.collisionEntities.Add(this, CollisionRectangle());
            this.spriteScalar = game.spriteScalar;
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }
        public void Update()
        {
            game.collisionManager.collisionEntities[this] = collisionRectangle;
        }

        public void Draw()
        {
            tileSprite.Draw(position);
        }
    }
}
