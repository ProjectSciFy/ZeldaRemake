using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles.BombUtility;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Bomb : IProjectile, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        public ProjectileSpriteFactory projectileSpriteFactory { get; set; }
        public ProjectileHandler projectileHandler { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 spriteSize;
        private BombStateMachine myState { get; set; }
        public bool exploding { get; set; } = false;
        private int explosionTimer { get; set; } = BombStorage.EXPLOSION_TIMER;
        private bool explosionMirror { get; set; } = false;
        public Rectangle collisionRectangle = Rectangle.Empty;
        public float spriteScalar { get; set; }

        public Bomb(ZeldaGame game, Vector2 drawLocation, ProjectileHandler projectileHandler)
        {
            this.game = game;
            this.spriteScalar = game.util.spriteScalar;
            this.projectileSpriteFactory = game.projectileSpriteFactory;
            this.drawLocation = drawLocation;
            this.projectileHandler = projectileHandler;
            myState = new BombStateMachine(this);
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();
        }

        public void Draw()
        {
            if (!exploding)
            {
                mySprite.Draw(drawLocation);
            }
            else
            {
                if (explosionMirror)
                {
                    mySprite.Draw(new Vector2(drawLocation.X - BombStorage.POSITION_OFFSET_ONE * spriteScalar, drawLocation.Y - BombStorage.POSITION_OFFSET_TWO * spriteScalar));
                    mySprite.Draw(new Vector2(drawLocation.X + BombStorage.POSITION_OFFSET_TWO * spriteScalar, drawLocation.Y));
                    mySprite.Draw(drawLocation);
                    mySprite.Draw(new Vector2(drawLocation.X + BombStorage.POSITION_OFFSET_ONE * spriteScalar, drawLocation.Y + BombStorage.POSITION_OFFSET_TWO * spriteScalar));
                }
                else
                {
                    mySprite.Draw(new Vector2(drawLocation.X + BombStorage.POSITION_OFFSET_ONE * spriteScalar, drawLocation.Y - BombStorage.POSITION_OFFSET_TWO * spriteScalar));
                    mySprite.Draw(new Vector2(drawLocation.X - BombStorage.POSITION_OFFSET_TWO * spriteScalar, drawLocation.Y));
                    mySprite.Draw(drawLocation);
                    mySprite.Draw(new Vector2(drawLocation.X - BombStorage.POSITION_OFFSET_ONE * spriteScalar, drawLocation.Y + BombStorage.POSITION_OFFSET_TWO * spriteScalar));
                }

                if (explosionTimer <= BombStorage.ZERO)
                {
                    explosionMirror = !explosionMirror;
                    explosionTimer = BombStorage.EXPLOSION_TIMER;
                }
                else
                {
                    explosionTimer--;
                }
            }
        }
    }
}
