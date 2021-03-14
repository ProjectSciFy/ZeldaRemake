using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class BladeTrap : IEnemy
    {
        //When link walks parallel to one it attacks
        //waits on link
        //Method of attack is collision.

        public ZeldaGame game;
        private BladeTrapStateMachine myState;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 range;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);

        public BladeTrap(ZeldaGame game, Vector2 spawnLocation, Vector2 range, Link link)
        {
            this.game = game;
            this.spawnLocation = spawnLocation;
            this.range = range;
            drawLocation = spawnLocation;
            myState = new BladeTrapStateMachine(this, link);
            game.collisionManager.enemies.Add(this, collisionRectangle);
        }

        public void Spawn()
        {

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

            collisionRectangle.X = (int)drawLocation.X;
            collisionRectangle.Y = (int)drawLocation.Y;
            collisionRectangle.Width = (int)spriteSize.X;
            collisionRectangle.Height = (int)spriteSize.Y;

            game.collisionManager.enemies[this] = collisionRectangle;
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
