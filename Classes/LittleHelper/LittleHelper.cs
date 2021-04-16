using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LittleHelper
{
    public class LittleHelper : IPlayer, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        public LittleHelperStateMachine myState { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public float spriteScalar { get; set; }

        public LittleHelper(ZeldaGame game)
        {
            this.game = game;
            this.spriteScalar = game.util.spriteScalar;
            drawLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            this.myState = new LittleHelperStateMachine(this);
            game.collisionManager.collisionEntities.Add(this, this.CollisionRectangle());
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();

            //Update the position of Link here
            drawLocation.X = Mouse.GetState().X - (spriteSize.X * spriteScalar / 2);
            drawLocation.Y = Mouse.GetState().Y - (spriteSize.Y * spriteScalar / 2);

            if (drawLocation.X + (spriteSize.X * spriteScalar) >= game.GraphicsDevice.Viewport.Bounds.Width)
            {
                drawLocation.X = game.GraphicsDevice.Viewport.Bounds.Width - (spriteSize.X * spriteScalar);
            }
            else if (drawLocation.X <= 0)
            {
                drawLocation.X = 0;
            }

            if (drawLocation.Y + (spriteSize.Y * spriteScalar) >= game.GraphicsDevice.Viewport.Bounds.Height)
            {
                drawLocation.Y = game.GraphicsDevice.Viewport.Bounds.Height - (spriteSize.Y * spriteScalar);
            }
            else if (drawLocation.Y <= 0)
            {
                drawLocation.Y = 0;
            }

            collisionRectangle.X = (int)drawLocation.X;
            collisionRectangle.Y = (int)drawLocation.Y;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar);
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar);

            game.collisionManager.collisionEntities[this] = this.CollisionRectangle();
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
