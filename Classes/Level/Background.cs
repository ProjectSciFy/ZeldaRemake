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
        public ZeldaGame game { get; set; }
        public Vector2 drawLocationInterior { get; set; }
        public Vector2 drawLocationExterior { get; set; }
        public ISprite roominterior { get; set; }
        public ISprite roomexterior { get; set; }
        private int windowWidth { get; set; }
        private int windowHeight { get; set; }
        private Texture2D itemSpriteSheet;
        private int roomLimiter { get; set; }
        private int drawOffset { get; set; }
        public Background(ZeldaGame game, int roomNumber)
        {
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
            roomexterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(521, 11, 256, 176), Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter,0.0f);

            
        }
        public void Draw()
        {
            roomexterior.Draw(drawLocationExterior);
            roominterior.Draw(drawLocationInterior);
        }
    }
}
