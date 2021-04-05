using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    class DeathState : IGameState
    {
        private ZeldaGame game;
        private int timer = -1;

        public DeathState(ZeldaGame game)
        {
            this.game = game;
        }

        void IGameState.Draw()
        {
            this.game.link.Draw();
        }

        void IGameState.Update()
        {
            if (timer == -1)
            {
                this.game.link.linkState.dying = true;
                //Time it takes for both animations to play out
                timer = 80 + 180;
            }
            game.link.Update();
            game.link.Draw();

            if (timer > 0)
            {
                timer--;
            }

            if (timer <= 0)
            {
                new Reset(game).Execute();
            }
        }

        void IGameState.UpdateCollisions()
        {

        }
    }
}
