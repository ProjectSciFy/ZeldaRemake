using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class Link : IPlayer, ICollisionEntity
    {
        private static int CENTER { get; set; } = 24;
        private int Y_ADJUST { get; set; } = 0;

        public ZeldaGame game { get; set; }
        public LinkStateMachine linkState { get; set; }
        public ISprite linkSprite;
        public Vector2 drawLocation;
        public Vector2 drawOffset = new Vector2(0, 0);
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public float spriteScalar { get; set; }

        public Link(ZeldaGame game)
        {
            this.Y_ADJUST = (game.GraphicsDevice.Viewport.Bounds.Height / 4) - 2 * CENTER;
            this.game = game;
            this.spriteScalar = game.util.spriteScalar;
            drawLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - CENTER, (game.GraphicsDevice.Viewport.Bounds.Height / 2) + Y_ADJUST);
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void SetState(LinkStateMachine empty)
        {
            linkState = empty;
            game.collisionManager.collisionEntities.Add(this, this.CollisionRectangle());
        }
        public void SetLocation(Vector2 newLocation)
        {
            drawLocation = newLocation;
        }

        public void Update()
        {
            linkState.Update();
            linkSprite.Update();

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
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar);
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar);

            game.collisionManager.collisionEntities[this] = this.CollisionRectangle();
        }

        public void Draw()
        {
            linkSprite.Draw(drawLocation);
        }
    }
}
