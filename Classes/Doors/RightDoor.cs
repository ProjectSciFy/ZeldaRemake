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
        private ZeldaGame game;
        private ISprite topDoorSprite;
        public Vector2 position;
        private RoomTextureStorage topDoorTexture;
        private int windowWidth;
        private int windowHeight;

        public RightDoor(ZeldaGame game, RoomTextureStorage textures, int doorValue)
        {
            this.game = game;
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = (windowHeight / 3 - 176 / 3) / 2;
            int windowWidthFloor = (windowWidth / 3 - 256 / 3) / 2;
            windowWidthFloor = windowWidthFloor + 224 * 3;
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
    }
}