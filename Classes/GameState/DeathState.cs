using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    class DeathState : IGameState
    {
        private ICommand resetGame;
        private ZeldaGame game;

        private int timer = 12;

        public DeathState(ZeldaGame game)
        {
            this.game = game;
            resetGame = new Reset(game);
        }

        void IGameState.Draw()
        {
            this.game.link.Draw();
        }

        void IGameState.Update()
        {
            if (timer == 0)
            {
                resetGame.Execute();
            } else
            {
                switch (timer % 40)
                {
                    case 0:
                        timer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.right);
                        break;
                    case 1:
                        timer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.up);
                        break;
                    case 2:
                        timer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.left);
                        break;
                    case 3:
                        timer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.down);
                        break;
                    default:
                        break;
                }
            }
        }

        void IGameState.UpdateCollisions()
        {

        }
    }
}
