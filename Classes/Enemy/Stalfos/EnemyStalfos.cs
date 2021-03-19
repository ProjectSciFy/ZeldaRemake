using CSE3902_Game_Sprint0.Classes.Enemy.Stalfos;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemyStalfos : IEnemy, ICollisionEntity
    {
        //When defeated, can drop a heart, rupee, 5rupee or a clock
        //Pathing is random, no sense of direction
        //Method of attack is melee, bumping into the player

        public ZeldaGame game;
        private StalfosStateMachine myState;
        public StalfosSpriteFactory enemySpriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(16, 16);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar;
        private static int HITBOX_OFFSET = 6;
        public int health = 2;

        public EnemyStalfos(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.spriteScalar = game.spriteScalar;
            this.enemySpriteFactory = new StalfosSpriteFactory(game);
            drawLocation = spawnLocation;
            myState = new StalfosStateMachine(this);
            //game.collisionManager.enemies.Add(this, collisionRectangle);
            game.collisionManager.collisionEntities.Add(this, this.CollisionRectangle());
        }
        public void TakeDamage(int damage)
        {
            this.health = this.health - damage;
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();

            //Update the position of Link here
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;

            if (drawLocation.X >= game.GraphicsDevice.Viewport.Bounds.Width && velocity.X > 0)
            {
                drawLocation.X = 0 - spriteSize.X;
            }
            else if (drawLocation.X + spriteSize.X <= 0 && velocity.X < 0)
            {
                drawLocation.X = game.GraphicsDevice.Viewport.Bounds.Width;
            }

            if (drawLocation.Y >= game.GraphicsDevice.Viewport.Bounds.Height && velocity.Y > 0)
            {
                drawLocation.Y = 0 - spriteSize.Y;
            }
            else if (drawLocation.Y + spriteSize.Y <= 0 && velocity.Y < 0)
            {
                drawLocation.Y = game.GraphicsDevice.Viewport.Bounds.Height;
            }

            collisionRectangle.X = (int)drawLocation.X + HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - 2 * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - 2 * HITBOX_OFFSET;

            //game.collisionManager.enemies[this] = collisionRectangle;

            game.collisionManager.collisionEntities[this] = this.CollisionRectangle();
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
