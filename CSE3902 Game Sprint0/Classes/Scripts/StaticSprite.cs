using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class StaticSprite : ISprite
    {
        private EeveeSim game;
        private Texture2D myTexture;
        private SpriteBatch mySpriteBatch;
        private Vector2 drawLocation;
        private Vector2 velocity;
        private Rectangle spriteIndex;
        private Color color;
        public StaticSprite(EeveeSim game, Texture2D texture, Vector2 drawLocation, Vector2 velocity, Rectangle spriteIndex, Color color)
        {
            this.game = game;
            myTexture = texture;
            mySpriteBatch = new SpriteBatch(this.game.GraphicsDevice);
            this.drawLocation = drawLocation;
            this.velocity = velocity;
            this.spriteIndex = spriteIndex;
            this.color = color;
        }

        public void Update()
        {
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;

            if (drawLocation.X >= game.GraphicsDevice.Viewport.Bounds.Width && velocity.X > 0)
            {
                drawLocation.X = 0 - spriteIndex.Width;
            }
            else if (drawLocation.X + spriteIndex.Width <= 0 && velocity.X < 0)
            {
                drawLocation.X = game.GraphicsDevice.Viewport.Bounds.Width;
            }

            if (drawLocation.Y >= game.GraphicsDevice.Viewport.Bounds.Height && velocity.Y > 0)
            {
                drawLocation.Y = 0 - spriteIndex.Height;
            }
            else if (drawLocation.Y + spriteIndex.Height <= 0 && velocity.Y < 0)
            {
                drawLocation.Y = game.GraphicsDevice.Viewport.Bounds.Height;
            }
        }

        public void Draw()
        {
            mySpriteBatch.Begin();
            mySpriteBatch.Draw(myTexture, drawLocation, spriteIndex, color);
            mySpriteBatch.End();
        }
    }
}
