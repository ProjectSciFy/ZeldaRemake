using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    class DeathState : IGameState
    {
        private ZeldaGame game;

        private int deathAnimationTimer = 12;

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
            //EXECUTE DEATH ANIMATION HERE
            new Reset(game).Execute();
        }

        void IGameState.UpdateCollisions()
        {

        }
    }
}
