using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands.ResetUtility
{
    public class ResetHud : ICommand
    {
        private readonly ZeldaGame game;
        public ResetHud(ZeldaGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.util.numLives = 3;
            game.util.linkXPlevel = 1;
            game.util.numXP = 0;
            game.util.numKeys = 0;
            game.util.numBombs = 3;
            game.util.numYrups = 5;
            game.util.hasMap = false;
            game.util.hasCompass = false;
            game.util.hasBow = false;
            game.util.linkInd = true;
        }
    }
}
