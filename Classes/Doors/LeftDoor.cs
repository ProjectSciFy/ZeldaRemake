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
    public class LeftDoor : IDoor
    {
        private ZeldaGame game;
        private ISprite topDoorSprite;
        public Vector2 position;
        private RoomTextureStorage topDoorTexture;
        private int windowWidth;
        private int windowHeight;
        private int doorValue;
        public LeftDoor(ZeldaGame game, RoomTextureStorage textures, int doorValue)
        {
            ParserUtility utility = new ParserUtility(game);

            this.game = game;
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;
            this.doorValue = doorValue;

            int windowHeightFloor = ((windowHeight / utility.SCALE_FACTOR - utility.WINDOW_X_ADJUST / utility.SCALE_FACTOR) / utility.GEN_ADJUST) + utility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / utility.SCALE_FACTOR - utility.WINDOW_Y_ADJUST / utility.SCALE_FACTOR) / utility.GEN_ADJUST;
            windowHeightFloor = windowHeightFloor + 72 * 3;


            this.position = new Vector2(windowWidthFloor, windowHeightFloor);
            this.topDoorTexture = textures;
            this.topDoorSprite = this.topDoorTexture.getDoor(doorValue);
        }
        public void Update()
        {
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