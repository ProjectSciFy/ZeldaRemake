using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    class DeathState : IGameState
    {
        private ZeldaGame game;

        //private int deathAnimationTimer = 12;

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
            if (game.util.numLives <= 0)
            {
                new Reset(game).Execute();
            }
            /*
            if (deathAnimationTimer == 0)
            {
                new Reset(game).Execute();
            } else
            {
                switch (deathAnimationTimer % 40)
                {
                    case 0:
                        deathAnimationTimer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.right);
                        break;
                    case 1:
                        deathAnimationTimer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.up);
                        break;
                    case 2:
                        deathAnimationTimer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.left);
                        break;
                    case 3:
                        deathAnimationTimer--;
                        this.game.link.linkState.ChangeDirection(LinkStateMachine.Direction.down);
                        break;
                    default:
                        break;
                }
            }
            */
        }

        void IGameState.UpdateCollisions()
        {

        }
    }
}
