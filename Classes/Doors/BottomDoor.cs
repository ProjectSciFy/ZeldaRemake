using CSE3902_Game_Sprint0.Classes.Doors;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class BottomDoor : IDoor
    {
        private ZeldaGame game { get; set; }
        private ISprite bottomDoorSprite { get; set; }
        public Vector2 position;
        private readonly RoomTextureStorage bottomDoorTexture;
        private int windowWidth { get; set; }
        private int windowHeight { get; set; }
        private int doorValue { get; set; }
        public BottomDoor(ZeldaGame game, RoomTextureStorage textures, int doorValue)
        {
            this.game = game;
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;
            this.doorValue = doorValue;

            int windowHeightFloor = ((windowHeight / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            windowWidthFloor = windowWidthFloor + 112 * ParserUtility.SCALE_FACTOR;
            windowHeightFloor = windowHeightFloor + 144 * ParserUtility.SCALE_FACTOR;


            this.position = new Vector2(windowWidthFloor, windowHeightFloor);
            this.bottomDoorTexture = textures;
            this.bottomDoorSprite = this.bottomDoorTexture.getDoor(doorValue);
        }
        public void Update()
        {
            this.bottomDoorSprite.Update();
        }
        public void Draw()
        {
            bottomDoorSprite.Draw(position);
        }
        public int getDoorValue()
        {
            return doorValue;
        }
    }
}