using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Roshi;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class KiBlast : IProjectile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        private EnemyRoshi roshi { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public EnemySpriteFactory spriteFactory { get; set; }
        private KiBlastStateMachine myState { get; set; }
        public ISprite mySprite { get; set; }
        private Vector2 drawLocation;
        public Vector2 velocity { get; set; } = new Vector2(0, 0);
        public Vector2 spriteSize { get; set; } = new Vector2(0, 0);
        public Vector2 trajectory { get; set; }
        private bool newItem { get; set; } = true;
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        public bool collided { get; set; } = false;
        private int timer = 60;

        public KiBlast(ZeldaGame game, EnemyRoshi roshi, RoshiStateMachine roshiState, Vector2 trajectory)
        {
            this.game = game;
            this.roshi = roshi;
            this.roshiState = roshiState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = Vector2.Add(roshi.drawLocation, new Vector2(40 * 3,16 * 3));
            this.myState = new KiBlastStateMachine(this);
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
            if (timer <= 0)
            {
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
            else
            {
                timer--;
            }
        }
        public void Draw()
        {
            if (timer <= 0)
            {
                mySprite.Draw(drawLocation);
            }
        }
    }
}
