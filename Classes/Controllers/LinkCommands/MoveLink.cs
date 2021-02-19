using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Scripts
{
    public class MoveLink : ICommand
    {
        private StateMachine linkState;
        private StateMachine.Direction direction;

        public MoveLink(StateMachine linkState, StateMachine.Direction direction)
        {
            this.linkState = linkState;
            this.direction = direction;
        }

        public void Execute()
        {
            linkState.moving = true;

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
            //GET RID OF THIS ONCE WE SETUP STATEMACHINE UPDATE()
            //linkState.Moving();
        }
    }
}
