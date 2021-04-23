using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands.ResetUtility;
using CSE3902_Game_Sprint0.Classes.GameState;
using CSE3902_Game_Sprint0.Classes.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class Reset : ICommand
    {
        
        private ZeldaGame game { get; set; }

        private Vector2 linkLocation;

        public Reset(ZeldaGame game)
        {
            this.game = game;
            linkLocation = game.link.drawLocation;
        }

        public void Execute()
        {
            //RESET MUSIC
            new ResetMusic(game).Execute();

            //RESET LINK
            new ResetLink(game).Execute();

            //RESET HUD
            new ResetHud(game).Execute();

            //RE-PARSE ROOMS HERE
            new ResetRooms(game).Execute();
        }
    }
}
