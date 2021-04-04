using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class WinState : IGameState
    {
        private ZeldaGame game;
        public WinState(ZeldaGame game)
        {
            this.game = game;
        }

        void IGameState.Draw()
        {
            this.game.link.Draw();
        }

        void IGameState.Update()
        {
            this.game.link.Update();
        }

        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
