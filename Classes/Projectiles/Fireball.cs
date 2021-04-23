using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Projectiles.FireballUtility;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Fireball : IProjectile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        private EnemyAquamentus aquamentus { get; set; }
        private AquamentusStateMachine aquamentusState { get; set; }
        public EnemySpriteFactory spriteFactory { get; set; }
        private FireballStateMachine myState { get; set; }
        public ISprite mySprite { get; set; }
        private Vector2 drawLocation;
        public Vector2 velocity { get; set; } = Vector2.Zero;
        public Vector2 spriteSize { get; set; } = Vector2.Zero;
        public Vector2 trajectory { get; set; }
        private bool newItem { get; set; } = true;
        public Rectangle collisionRectangle = Rectangle.Empty;
        private float spriteScalar { get; set; }
        public bool collided { get; set; } = false;

        public Fireball(ZeldaGame game, EnemyAquamentus aquamentus, AquamentusStateMachine aquamentusState, Vector2 trajectory)
        {
            this.game = game;
            this.aquamentus = aquamentus;
            this.aquamentusState = aquamentusState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = aquamentus.drawLocation;
            this.myState = new FireballStateMachine(this);
            this.spriteScalar = game.util.spriteScalar;
            this.trajectory = trajectory;
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }
        public void Update()
        {
            myState.Update();
            mySprite.Update();

            drawLocation = drawLocation + velocity;

            collisionRectangle.X = (int)drawLocation.X + FireballStorage.DOUBLE_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + FireballStorage.HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - FireballStorage.TRIPLE_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - FireballStorage.DOUBLE_OFFSET;

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
