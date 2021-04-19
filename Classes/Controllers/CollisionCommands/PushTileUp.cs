﻿using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.CollisionCommands
{
    class PushTileUp :ICommand
    {
        private ZeldaGame game { get; set; }
        private PushableTile tile { get; set; }
        private int timer { get; set; }
        public PushTileUp(ZeldaGame game, ITile tile)
        {
            this.game = game;
            this.tile = (PushableTile)tile;
            this.timer = 48;
        }

        public void Execute()
        {
            while (timer > 0)
            {
                tile.drawLocation.Y = tile.drawLocation.Y + 1;
                tile.Draw();
                timer--;
            }
            tile.pushed = true;
        }
    }
}