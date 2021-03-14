using CSE3902_Game_Sprint0.Classes.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemyGoriya : IEnemy
    {
        //When defeated, can drop a heart, rupee, 5rupee or a clock
        //Pathing is random, no sense of direction
        //Method of attack is melee, bumping into the player

        private ZeldaGame game;
        private GoriyaStateMachine myState;
        private EnemySpriteFactory spriteFactory;
        private Vector2 drawLocation;
        private Vector2 velocity = new Vector2(0, 0);
        private Vector2 spriteSize = new Vector2(0, 0);
        private Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private GoriyaBoomerang boomerang;
        public EnemySpriteFactory SpriteFactory { get { return spriteFactory; } }
        public Rectangle CollisionRectangle { get { return collisionRectangle; } }
        public Vector2 SpriteSize { get { return spriteSize; } set { spriteSize = value; } }
        public Vector2 DrawLocation { get { return drawLocation; } set { drawLocation = value; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public ISprite mySprite { get; set; }

        public EnemyGoriya(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.spriteFactory = game.enemySpriteFactory;
            drawLocation = spawnLocation;
            myState = new GoriyaStateMachine(this);
            game.collisionManager.enemies.Add(this, collisionRectangle);
            boomerang = new GoriyaBoomerang(game, this, myState);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update(); 
            if (!myState.moving)
            {
                boomerang.Update();
            }

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

            collisionRectangle.X = (int)drawLocation.X;
            collisionRectangle.Y = (int)drawLocation.Y;
            collisionRectangle.Width = (int)spriteSize.X;
            collisionRectangle.Height = (int)spriteSize.Y;

            game.collisionManager.enemies[this] = collisionRectangle;
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
            if (!myState.moving)
            {
                boomerang.Draw();
            }
        }
    }
}
