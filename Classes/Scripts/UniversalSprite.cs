    using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Scripts
{
    public class UniversalSprite : ISprite
    {
        private int fpsBrakes { get; set; }
        private int frame { get; set; }
        private int frameCount { get; set; }
        private Vector2 frameGrid { get; set; }
        private Rectangle frameIndex;
        private Rectangle spriteIndex { get; set; }
        private SpriteBatch mySpriteBatch { get; set; }
        private Texture2D myTexture { get; set; }
        private Color color { get; set; }
        private SpriteEffects spriteEffects { get; set; }
        private int fpsLimiter { get; set; }
        private float layerDepth { get; set; }

        public UniversalSprite(ZeldaGame game, Texture2D texture, Rectangle spriteIndex, Color color, SpriteEffects spriteEffects, Vector2 frameGrid, int fpsLimiter, float layerDepth)
        {
            mySpriteBatch = new SpriteBatch(game.GraphicsDevice);
            myTexture = texture;
            this.spriteIndex = spriteIndex;
            frameIndex = new Rectangle(spriteIndex.X, spriteIndex.Y, spriteIndex.Width, spriteIndex.Height);
            this.color = color;
            this.spriteEffects = spriteEffects;
            this.frameGrid = frameGrid;
            this.fpsLimiter = fpsLimiter;
            this.layerDepth = layerDepth;
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
            //mySpriteBatch.Begin();
            mySpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            mySpriteBatch.Draw(myTexture, drawLocation, frameIndex, color, 0, new Vector2(0, 0), 3f, spriteEffects, layerDepth);
            mySpriteBatch.End();
        }
    }
}
