using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Items;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.Level;
using System.Diagnostics;
using System.IO;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class TempDoor
    {
        public ZeldaGame game;
        public Vector2 drawLocation;
        public Vector2 drawLocation2;
        public ISprite door;
        private SpriteBatch mySpriteBatch;
        private int windowWidth;
        private int windowHeight;
        private Texture2D itemSpriteSheet;
        public TempDoor(ZeldaGame game, int doorValue)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonTileset", out itemSpriteSheet);
            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = (windowHeight / 3 - 176 / 3) / 2;
            int windowWidthFloor = (windowWidth / 3 - 256 / 3) / 2;
            //drawLocation = new Vector2(32, 32);
            Random rnd = new Random();
            int location = doorValue / 10;
            int x = 0;
            int y = 0;

            switch (location)
            {
                case 0:
                    x = windowWidthFloor + 112*3;
                    y = windowHeightFloor + 0;
                    break;
                case 1:
                    x = windowWidthFloor + 0;
                    y = windowHeightFloor + 72*3;
                    break;
                case 2:
                    x = windowWidthFloor + 112*3;
                    y = windowHeightFloor + 144*3;
                    break;
                case 3:
                    x = windowWidthFloor + 224*3;
                    y = windowHeightFloor + 72*3;
                    break;
                default:
                    break;
            }
                


            drawLocation = new Vector2(x,y);
            Debug.Write(x.ToString() + " " + y.ToString());
            Debug.Write("\n");
            RoomTextureStorage roomTextures = new RoomTextureStorage(this.game);
            door = roomTextures.getDoor(doorValue);
            //tile = new UniversalSprite(game, itemSpriteSheet, new Rectangle(1001, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, 0.2f);

        }
        public void Draw()
        {

            door.Draw(drawLocation);
        }
    }
}
