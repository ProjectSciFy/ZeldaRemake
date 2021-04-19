using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Items;
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
        private int roomNumber;
        public Background(ZeldaGame game, int roomNumber)
        {
            this.roomNumber = roomNumber;
            this.game = game;
            RoomTextureStorage roomTextures = new RoomTextureStorage(this.game);
            game.spriteSheets.TryGetValue("DungeonTileset", out itemSpriteSheet);

            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = ((windowHeight / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;

            roomLimiter = 10;
            drawOffset = 96;

            drawLocationInterior = new Vector2(windowWidthFloor + drawOffset, windowHeightFloor + drawOffset);
            drawLocationExterior = new Vector2(windowWidthFloor, windowHeightFloor);

            roominterior = roomTextures.getRoom(roomNumber);
            if(roomNumber == 16)
            {
                roomexterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(421, 1011, 256, 176), Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
                roominterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(421, 1011, 256, 176), Color.Transparent, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }
            else
            {
                roomexterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(521, 11, 256, 176), Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }
            

            
        }
        public void Draw()
        {
            roomexterior.Draw(drawLocationExterior);
            if(roomNumber != 16)
            {
                roominterior.Draw(drawLocationInterior);
            }
           
        }
    }
}
