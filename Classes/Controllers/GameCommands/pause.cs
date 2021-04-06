using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands{
    public class Pause : ICommand
    {
        private ZeldaGame game;
        public Pause(ZeldaGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.paused = !game.paused;
        }
    }
}