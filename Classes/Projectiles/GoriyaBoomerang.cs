using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles.GoriyaBoomerangUtility;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class GoriyaBoomerang : IProjectile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        public EnemyGoriya goriya { get; set; }
        public GoriyaStateMachine goriyaState { get; set; }
        public EnemySpriteFactory spriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        public GoriyaBoomerangStatemachine myState { get; set; }
        public Vector2 drawLocation;
        public Vector2 SpawnLocation;
        public Vector2 velocity { get; set; } = Vector2.Zero;
        public Vector2 spriteSize { get; set; } = GoriyaBoomerangStorage.SPRITE_SIZE_VECTOR;
        public bool newItem { get; set; }
        public Vector2 trajectory { get; set; } = Vector2.Zero;
        public Rectangle collisionRectangle = Rectangle.Empty;
        private float spriteScalar { get; set; }
        public bool collided { get; set; } = false;

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

            collisionRectangle.X = (int)drawLocation.X + GoriyaBoomerangStorage.DOUBLE_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + GoriyaBoomerangStorage.HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - GoriyaBoomerangStorage.TRIPLE_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - GoriyaBoomerangStorage.DOUBLE_OFFSET;

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
