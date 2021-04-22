using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.Doors;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class RightDoor : IDoor
    {
        private ZeldaGame game { get; set; }
        private ISprite rightDoorSprite { get; set; }
        public Vector2 position;
        private RoomTextureStorage rightDoorTexture;
        private int windowWidth { get; set; }
        private int windowHeight { get; set; }
        private int doorValue { get; set; }
        public RightDoor(ZeldaGame game, RoomTextureStorage textures, int doorValue)
        {
            this.game = game;
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;
            this.doorValue = doorValue;

            int windowHeightFloor = ((windowHeight / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            windowWidthFloor = windowWidthFloor + 224 * ParserUtility.SCALE_FACTOR;
            windowHeightFloor = windowHeightFloor + 72 * ParserUtility.SCALE_FACTOR;


            this.position = new Vector2(windowWidthFloor, windowHeightFloor);
            this.rightDoorTexture = textures;
            this.rightDoorSprite = this.rightDoorTexture.getDoor(doorValue);
        }
        public void Update()
        {
        }

        public void Draw()
        {
            rightDoorSprite.Draw(position);
        }
        public int getDoorValue()
        {
            return doorValue;
        }
    }
}