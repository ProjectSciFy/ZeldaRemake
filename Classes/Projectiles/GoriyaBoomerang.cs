using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class GoriyaBoomerang : IProjectile, ICollisionEntity
    {
        private ZeldaGame game;
        public EnemyGoriya goriya;
        public GoriyaStateMachine goriyaState;
        public EnemySpriteFactory spriteFactory;
        public ISprite mySprite;
        public GoriyaBoomerangStatemachine myState;
        public Vector2 drawLocation;
        public Vector2 SpawnLocation;
        public Vector2 velocity = new Vector2 (0,0);
        public Vector2 spriteSize = new Vector2(16, 16);
        public bool newItem;
        public Vector2 trajectory = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar;
        private static int HITBOX_OFFSET = 6;
        public bool collided = false;

        public GoriyaBoomerang(ZeldaGame game, EnemyGoriya goriya, GoriyaStateMachine goriyaState)
        {
            this.game = game;
            this.goriya = goriya;
            this.goriyaState = goriyaState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = goriya.drawLocation;
            this.SpawnLocation = goriya.drawLocation;
            this.spriteScalar = game.util.spriteScalar;
            this.myState = new GoriyaBoomerangStatemachine(this);
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }
        public void Update()
        {
            myState.Update();
            mySprite.Update();
            goriyaState.Update();

            //Update position of boomerang
            drawLocation = drawLocation + velocity;

            collisionRectangle.X = (int)drawLocation.X + 2 * HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - 3 * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - 2 * HITBOX_OFFSET;

            game.collisionManager.collisionEntities[this] = collisionRectangle;

            if (collided)
            {
                game.projectileHandler.Remove(this);
                game.collisionManager.collisionEntities.Remove(this);
            }
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
