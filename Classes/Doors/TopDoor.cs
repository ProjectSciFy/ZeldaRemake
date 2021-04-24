using CSE3902_Game_Sprint0.Classes.Doors;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class TopDoor : IDoor
    {
        private ZeldaGame game { get; set; }
        private ISprite topDoorSprite { get; set; }
        public Vector2 position;
        private readonly RoomTextureStorage topDoorTexture;
        private int windowWidth { get; set; }
        private int windowHeight { get; set; }
        private int doorValue { get; set; }
        public TopDoor(ZeldaGame game, RoomTextureStorage textures, int doorValue)
        {

            this.game = game;
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;
            this.doorValue = doorValue;

            int windowHeightFloor = ((windowHeight / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            windowWidthFloor = windowWidthFloor + DoorUtility.topDoorAdjust * ParserUtility.SCALE_FACTOR;

            this.position = new Vector2(windowWidthFloor, windowHeightFloor);
            this.topDoorTexture = textures;
            this.topDoorSprite = this.topDoorTexture.getDoor(doorValue);
        }
        public void Update()
        {
            this.topDoorSprite.Update();
        }
        public void Draw()
        {
            topDoorSprite.Draw(position);
        }
        public int getDoorValue()
        {
            return doorValue;
        }
    }
}