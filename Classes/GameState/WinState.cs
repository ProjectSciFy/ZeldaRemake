using Microsoft.Xna.Framework.Media;
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
            game.link.Update();
            game.link.Draw();
            MediaPlayer.Stop();
        }

        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
