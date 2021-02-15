using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class AnimatedSprite : ISprite
    {
        private EeveeSim game;
        private Texture2D myTexture;
        private SpriteBatch mySpriteBatch;
        private Vector2 drawLocation;
        private Vector2 velocity;
        private Rectangle spriteIndex;
        private Color color;
        private SpriteEffects spriteEffects;
        private int frameCount;
        private int frame;
        private int fpsBrakes;
        private Vector2 frameGrid;
        private Rectangle frameIndex;

        public AnimatedSprite(EeveeSim game, Texture2D texture, Vector2 drawLocation, Vector2 velocity, Rectangle spriteIndex, Color color, SpriteEffects spriteEffects, Vector2 frameGrid)
        {
            this.game = game;
            myTexture = texture;
            mySpriteBatch = new SpriteBatch(this.game.GraphicsDevice);
            this.drawLocation = drawLocation;
            this.velocity = velocity;
            this.spriteIndex = spriteIndex;
            this.frameIndex = new Rectangle(spriteIndex.X, spriteIndex.Y, spriteIndex.Width, spriteIndex.Height);
            this.color = color;
            this.spriteEffects = spriteEffects;
            this.frameGrid = frameGrid;
            frameCount = (int) (frameGrid.X * frameGrid.Y);
            frame = 0;
            fpsBrakes = 0;
        }

        public void Update()
        {
            int row;
            int column;

            fpsBrakes++;

            if (fpsBrakes >= 10)
            {
                frame++;
                fpsBrakes = 0;
            }

            if (frame >= frameCount)
            {
                frame = 0;
            }

            row = (int)(frame / frameGrid.Y);
            column = frame % (int)frameGrid.Y;

            frameIndex.X = spriteIndex.X + (spriteIndex.Width * column);
            frameIndex.Y = spriteIndex.Y + (spriteIndex.Height * row);

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
            //mySpriteBatch.Draw(myTexture, drawLocation, frameIndex, color);
            mySpriteBatch.Draw(myTexture, drawLocation, frameIndex, color, 0, new Vector2(0, 0), 1, spriteEffects, 1);
            mySpriteBatch.End();
        }
    }
}
