using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Scripts
{
    public class UniversalSprite : ISprite
    {
        private int fpsBrakes;
        private int frame;
        private int frameCount;
        private Vector2 frameGrid;
        private Rectangle frameIndex;
        private Rectangle spriteIndex;
        private ZeldaGame game;
        private SpriteBatch mySpriteBatch;
        private Texture2D myTexture;
        private Color color;
        private SpriteEffects spriteEffects;
        private int fpsLimiter;

        public UniversalSprite(ZeldaGame game, Texture2D texture, Rectangle spriteIndex, Color color, SpriteEffects spriteEffects, Vector2 frameGrid, int fpsLimiter)
        {
            this.game = game;
            mySpriteBatch = new SpriteBatch(this.game.GraphicsDevice);
            myTexture = texture;
            this.spriteIndex = spriteIndex;
            frameIndex = new Rectangle(spriteIndex.X, spriteIndex.Y, spriteIndex.Width, spriteIndex.Height);
            this.color = color;
            this.spriteEffects = spriteEffects;
            this.frameGrid = frameGrid;
            this.fpsLimiter = fpsLimiter;
            frameCount = (int)(frameGrid.X * frameGrid.Y);
            frame = 0;
            fpsBrakes = 0;

        }

        public void Update()
        {
            int row;
            int column;

            fpsBrakes++;

            if (fpsBrakes >= fpsLimiter)
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
        }

        public void Draw(Vector2 drawLocation)
        {
            mySpriteBatch.Begin();
            mySpriteBatch.Draw(myTexture, drawLocation, frameIndex, color, 0, new Vector2(0, 0), 1, spriteEffects, 1);
            mySpriteBatch.End();
        }
    }
}
