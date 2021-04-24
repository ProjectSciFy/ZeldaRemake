using CSE3902_Game_Sprint0.Classes.Level.BackgroundUtility;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    class Background
    {
        public ZeldaGame game;
        public Vector2 drawLocationInterior;
        public Vector2 drawLocationExterior;
        public ISprite roominterior;
        public ISprite roomexterior;
        private readonly int windowWidth;
        private readonly int windowHeight;
        private readonly Texture2D itemSpriteSheet;
        private readonly int roomNumber;
        private BackgroundStorage storage = new BackgroundStorage();
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

            drawLocationInterior = new Vector2(windowWidthFloor + storage.drawOffset, windowHeightFloor + storage.drawOffset);
            drawLocationExterior = new Vector2(windowWidthFloor, windowHeightFloor);

            roominterior = roomTextures.getRoom(roomNumber);
            if (roomNumber == storage.specialRoomNumber)
            {
                roomexterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(421, 1011, 256, 176), Color.White, SpriteEffects.None, new Vector2(1, 1), storage.roomLimiter, 0.0f);
                roominterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(421, 1011, 256, 176), Color.Transparent, SpriteEffects.None, new Vector2(1, 1), storage.roomLimiter, 0.0f);
            }
            else
            {
                roomexterior = new UniversalSprite(game, itemSpriteSheet, new Rectangle(521, 11, 256, 176), Color.White, SpriteEffects.None, new Vector2(1, 1), storage.roomLimiter, 0.0f);
            }
        }
        public void Draw()
        {
            roomexterior.Draw(drawLocationExterior);
            if (roomNumber != storage.specialRoomNumber)
            {
                roominterior.Draw(drawLocationInterior);
            }

        }
    }
}
