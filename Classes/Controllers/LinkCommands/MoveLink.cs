using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Scripts
{
    class MoveLink : ICommand
    {
        private EeveeSim game;
        private StateMachine linkState;
        private StateMachine.Direction direction;

        public MoveLink(EeveeSim game, StateMachine.Direction direction)
        {
            this.game = game;
            this.linkState = game.linkStateMachine;
            this.direction = direction;
        }

        public void Execute()
        {
            switch (direction)
            {
                case StateMachine.Direction.up:
                    linkState.direction = StateMachine.Direction.up;
                    break;

                case StateMachine.Direction.down:
                    linkState.direction = StateMachine.Direction.down;
                    break;

                case StateMachine.Direction.left:
                    linkState.direction = StateMachine.Direction.left;
                    break;

                case StateMachine.Direction.right:
                    linkState.direction = StateMachine.Direction.right;
                    break;

                default:
                    break;
            }

            linkState.Moving();
        }
    }
}
