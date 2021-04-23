using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Roshi;
using CSE3902_Game_Sprint0.Classes.Projectiles.KiBlastUtility;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class SpiritBomb : IProjectile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        private EnemyRoshi roshi { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiSpriteFactory spriteFactory { get; set; }
        public SpiritBombStateMachine myState { get; set; }
        public ISprite mySprite { get; set; }
        private Vector2 drawLocation;
        public Vector2 velocity { get; set; } = Vector2.Zero;
        public Vector2 spriteSize { get; set; } = Vector2.Zero;
        public Vector2 trajectory { get; set; }
        private bool newItem { get; set; } = true;
        public Rectangle collisionRectangle = Rectangle.Empty;
        private float spriteScalar { get; set; }
        public bool collided { get; set; } = false;
        private int timer = 30;

        public SpiritBomb(ZeldaGame game, EnemyRoshi roshi, RoshiStateMachine roshiState, Vector2 trajectory)
        {
            this.game = game;
            this.roshi = roshi;
            this.roshiState = roshiState;
            this.spriteFactory = roshi.spriteFactory;
            this.drawLocation = Vector2.Add(roshi.drawLocation,  new Vector2(-40, -250));
            this.myState = new SpiritBombStateMachine(this);
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

                collisionRectangle.X = (int)drawLocation.X + KiBlastStorage.DOUBLE_OFFSET;
                collisionRectangle.Y = (int)drawLocation.Y + KiBlastStorage.HITBOX_OFFSET;
                collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - KiBlastStorage.TRIPLE_OFFSET;
                collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - KiBlastStorage.DOUBLE_OFFSET;

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
