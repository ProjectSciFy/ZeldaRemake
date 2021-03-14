using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Items;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.Projectiles;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    class TempTile
    {
        public ZeldaGame game;
        public Vector2 drawLocation;
        public Vector2 drawLocation2;
        public ISprite tile;
        private SpriteBatch mySpriteBatch;

        private Texture2D itemSpriteSheet;
        public TempTile(ZeldaGame game, Vector2 position)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonTileset", out itemSpriteSheet);

            //drawLocation = new Vector2(32, 32);
            Random rnd = new Random();
            int x = 32 + 16 * rnd.Next(1,12);
            int y = 32 + 16 * rnd.Next(1,7);
            drawLocation = new Vector2((float) 3*(position.X*16 + 16), (float) 3*(position.Y*16 + 16));

    
            tile = new UniversalSprite(game, itemSpriteSheet, new Rectangle(1001, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10,0.2f);
           // roominterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(1, 192, 192, 112), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
           
            // mySpriteBatch = new SpriteBatch(this.game.GraphicsDevice);
           // mySpriteBatch.Begin();
            // mySpriteBatch.Draw(itemSpriteSheet, drawLocation, new Rectangle(1001, 11, 16, 16), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 1);
          //  mySpriteBatch.End();

        }
        public void Draw()
        {
           // mySpriteBatch.Begin();
           // mySpriteBatch.Draw(itemSpriteSheet, drawLocation, new Rectangle(1001, 11, 16, 16), Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 1);
           // mySpriteBatch.End();
            tile.Draw(drawLocation);
            //roominterior.Draw(drawLocation);
        }
    }
}
