﻿using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.GameState;
using CSE3902_Game_Sprint0.Classes.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class Select : ICommand
    {
        private ZeldaGame game;
        public Select(ZeldaGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.util.selecting = !game.util.selecting;
        }
    }
}