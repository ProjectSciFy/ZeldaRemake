using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi
{
    public class EnemyRoshi : IEnemy, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        private RoshiStateMachine myState { get; set; }
        public RoshiSpriteFactory spriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public int timer { get; set; } = 0;
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        public int health { get; set; } = 5;
        private int hurtTimer { get; set; } = 0;

        public EnemyRoshi(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.spriteFactory = new RoshiSpriteFactory(game);
            this.mySprite = this.spriteFactory.SpawnRoshi();
            drawLocation = spawnLocation;
            myState = new RoshiStateMachine(this);
            this.spriteScalar = game.util.spriteScalar;
            game.collisionManager.collisionEntities.Add(this, CollisionRectangle());
        }
        public void TakeDamage(int damage)
        {
            if (hurtTimer <= 0 && myState.attackTimer < 870 && myState.attackTimer != 0)
            {
                hurtTimer = 30;
                this.health = this.health - damage;
                game.sounds["enemyHit"].CreateInstance().Play();
                myState.damaged = true;
            }
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }
            if (hurtTimer > 0)
            {
                hurtTimer--;
            }
            myState.Update();
            mySprite.Update();

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
            collisionRectangle.X = (int)drawLocation.X + 2 * HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - 3 * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - 2 * HITBOX_OFFSET;

            if (myState.currentState != RoshiStateMachine.CurrentState.dying)
            {
                game.collisionManager.collisionEntities[this] = collisionRectangle;
            }
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
