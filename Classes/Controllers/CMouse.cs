using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers
{
    class CMouse : IController
    {
        Dictionary<int, ICommand> keyBinds = new Dictionary<int, ICommand>();
        private int currentQuad;
        private ZeldaGame game;

        public CMouse(ZeldaGame game)
        {
            this.game = game;
            keyBinds.Add(0, new ShutDownGame(game));
            currentQuad = 1;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X > game.GraphicsDevice.Viewport.Width / 2)
            {
                currentQuad++;
            }
            if (mouseState.Y > game.GraphicsDevice.Viewport.Height / 2)
            {
                currentQuad += 2;
            }

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                keyBinds[0].Execute();
            }
            else if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if(game.util.roomNumber == 18)
                {
                    game.changeRoom(0, 0);
                }
                else
                {
                    game.changeRoom(game.util.roomNumber + 1, 0);
                }
            }
            currentQuad = 1;
        }
    }
}
