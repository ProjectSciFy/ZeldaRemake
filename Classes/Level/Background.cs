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
    class Background
    {
        public EeveeSim game;
        public Vector2 drawLocation;
        public Vector2 drawLocation2;
        public ISprite roominterior;
        public ISprite roomexterior;

        private Texture2D itemSpriteSheet;
        public Background(EeveeSim game, int roomNumber)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonTileset", out itemSpriteSheet);
            drawLocation = new Vector2(32, 32);
            drawLocation2 = new Vector2(0, 0);

            int xloc = 1 + ((roomNumber - 1) % 6) * 195;
            int yloc = 192 + ((roomNumber - 1)/ 6) * 115;
            roominterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(xloc, yloc, 192, 112), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);


            roomexterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(521, 11, 256, 176), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);

            
        }
        public void Draw()
        {
            
            roomexterior.Draw(drawLocation2);
            roominterior.Draw(drawLocation);
        }
    }
}
