﻿using System;
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
        private ZeldaGame game;
        private ISprite tileSprite;
        private TileSpriteFactory tileFactory;
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public Vector2 position;
        public float spriteScalar;
        private static int HITBOX_OFFSET = 6;
        public Vector2 drawLocation;
        public Vector2 spriteSize = new Vector2(16, 16);

        public StairsTile(ZeldaGame game, TileSpriteFactory tileFactory, Vector2 location)
        {
            this.game = game;
            this.position = location;
            this.tileFactory = tileFactory;
            this.tileSprite = tileFactory.StairsTile();
            this.spriteScalar = game.spriteScalar;
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
            collisionRectangle.X = (int)drawLocation.X + HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - 4 * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - 4 * HITBOX_OFFSET;

            game.collisionManager.collisionEntities[this] = collisionRectangle;
        }

        public void Draw()
        {
            tileSprite.Draw(position);
        }
    }
}