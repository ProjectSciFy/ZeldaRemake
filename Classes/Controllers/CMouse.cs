using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
namespace CSE3902_Game_Sprint0.Classes.Controllers
{
    class CMouse : IController
    {
        Dictionary<int, ICommand> keyBinds = new Dictionary<int, ICommand>();
        private ZeldaGame game;

        public CMouse(ZeldaGame game)
        {
            this.game = game;
            keyBinds.Add(0, new ShutDownGame(game));
        }

        public void Update()
        {

            MouseState mouseState = Mouse.GetState();
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                keyBinds[0].Execute();
            }
            if (mouseState.LeftButton == ButtonState.Pressed && !game.util.keyPressedTempVariable)
            {
                float ValueX = mouseState.X;
                float ValueY = mouseState.Y;
                if (ValueX > 450 && ValueX < 560 && ValueY > 285 && ValueY < 345)
                {
                    if(game.neighbors[game.util.roomNumber][0] != 0)
                    {
                        game.changeRoom(game.neighbors[game.util.roomNumber][0], Collision.Collision.Direction.up);
                    }
                        
                }
                if (ValueX > 145 && ValueX < 225 && ValueY > 460 && ValueY < 555)
                {
                    if (game.neighbors[game.util.roomNumber][1] != 0)
                    {
                        game.changeRoom(game.neighbors[game.util.roomNumber][1], Collision.Collision.Direction.left);
                    }
                        
                }
                if (ValueX > 790 && ValueX < 860 && ValueY > 460 && ValueY < 555)
                {
                    if (game.neighbors[game.util.roomNumber][2] != 0)
                    {
                        game.changeRoom(game.neighbors[game.util.roomNumber][2], Collision.Collision.Direction.right);
                    }
                        
                }
                if (ValueX > 450 && ValueX < 560 && ValueY > 675 && ValueY < 730)
                {
                    if (game.neighbors[game.util.roomNumber][3] != 0)
                    {
                        game.changeRoom(game.neighbors[game.util.roomNumber][3], Collision.Collision.Direction.down);
                    }
                        
                }

                



            }
        }
    }
}
