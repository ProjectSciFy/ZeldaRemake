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
        public ZeldaGame game;
        public Vector2 drawLocationInterior;
        public Vector2 drawLocationExterior;
        public ISprite roominterior;
        public ISprite roomexterior;
        private int windowWidth;
        private int windowHeight;
        private Texture2D itemSpriteSheet;
        private int roomLimiter;
        private int drawOffset;
        public Background(ZeldaGame game, int roomNumber)
        {
            ParserUtility utility = new ParserUtility(game);

            this.game = game;
            RoomTextureStorage roomTextures = new RoomTextureStorage(this.game);
            game.spriteSheets.TryGetValue("DungeonTileset", out itemSpriteSheet);

            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = ((windowHeight / utility.SCALE_FACTOR - utility.WINDOW_X_ADJUST / utility.SCALE_FACTOR) / utility.GEN_ADJUST) + utility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / utility.SCALE_FACTOR - utility.WINDOW_Y_ADJUST / utility.SCALE_FACTOR) / utility.GEN_ADJUST;

            roomLimiter = 10;
            drawOffset = 96;

            drawLocationInterior = new Vector2(windowWidthFloor + drawOffset, windowHeightFloor + drawOffset);
            drawLocationExterior = new Vector2(windowWidthFloor, windowHeightFloor);

            roominterior = roomTextures.getRoom(roomNumber);
            roomexterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(521, 11, 256, 176), Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter,0.0f);

            
        }
        public void Draw()
        {
            roomexterior.Draw(drawLocationExterior);
            roominterior.Draw(drawLocationInterior);
        }
    }
}
