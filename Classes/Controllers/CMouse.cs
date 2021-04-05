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
        }
    }
}
