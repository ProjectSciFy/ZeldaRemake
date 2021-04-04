using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class PauseState : IGameState
    {
        private ZeldaGame game;
        public PauseState(ZeldaGame game)
        {
            this.game = game;
        }

        void IGameState.Draw()
        {
            
        }

        void IGameState.Update()
        {
            
        }

        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
