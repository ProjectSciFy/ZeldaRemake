using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class StaticSprite : ISprite
    {
        private ZeldaGame game;
        private Texture2D myTexture;
        private SpriteBatch mySpriteBatch;
        private Vector2 drawLocation;
        private Vector2 velocity;
        private Rectangle spriteIndex;
        private Color color;
        private SpriteEffects spriteEffects;
        public StaticSprite(ZeldaGame game, Texture2D texture, Vector2 drawLocation, Vector2 velocity, Rectangle spriteIndex, Color color, SpriteEffects spriteEffects)
        {
            this.game = game;
            myTexture = texture;
            mySpriteBatch = new SpriteBatch(this.game.GraphicsDevice);
            this.drawLocation = drawLocation;
            this.velocity = velocity;
            this.spriteIndex = spriteIndex;
            this.color = color;
            this.spriteEffects = spriteEffects;
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

        public void Draw(Vector2 drawLocationD)
        {
            mySpriteBatch.Begin();
            //Refactored to public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth) to allow sprite flipping & layer control
            //mySpriteBatch.Draw(myTexture, drawLocation, spriteIndex, color);
            mySpriteBatch.Draw(myTexture, drawLocation, spriteIndex, color, 0, new Vector2(0, 0), 1, spriteEffects, 1);
            mySpriteBatch.End();
        }
    }
}
