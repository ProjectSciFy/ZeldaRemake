using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class GiveKeys : ICommand
    {
        private ZeldaGame game;
        public GiveKeys(ZeldaGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.util.numKeys = game.util.numKeys + 5;
        }
    }
}
