using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class Link : IPlayer
    {
        public EeveeSim game;
        private LinkStateMachine linkState;
        public ISprite linkSprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        

        //Initialize Link's default state(s) in a new stateMachine
        public Link(EeveeSim game)
        {
            this.game = game;
            drawLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2));
        }

        public void SetState(LinkStateMachine empty)
        {
            linkState = empty;
        }

        //Set Link to be using an item
        public void UseItem()
        {
            //Call statemachine & have it use its currently selected item
        }

        //Set Link to be using his sword
        public void UseSword()
        {
            //Call statemachine & have it use Link's sword
        }

        //TODO more state altering 

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
        }

        public void Draw()
        {
            linkSprite.Draw(drawLocation);
        }
    }
}
