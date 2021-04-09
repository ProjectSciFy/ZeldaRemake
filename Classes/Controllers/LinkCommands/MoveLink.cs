using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Scripts
{
    public class MoveLink : ICommand
    {
        private LinkStateMachine linkState;
        private LinkStateMachine.Direction direction;

        public MoveLink(LinkStateMachine linkState, LinkStateMachine.Direction direction)
        {
            this.linkState = linkState;
            this.direction = direction;
        }

        public void Execute()
        {
            linkState.moving = true;
            

            switch (direction)
            {
                case LinkStateMachine.Direction.up:
                    linkState.direction = LinkStateMachine.Direction.up;
                    break;

                case LinkStateMachine.Direction.down:
                    linkState.direction = LinkStateMachine.Direction.down;
                    break;

                case LinkStateMachine.Direction.left:
                    linkState.direction = LinkStateMachine.Direction.left;
                    break;

                case LinkStateMachine.Direction.right:
                    linkState.direction = LinkStateMachine.Direction.right;
                    break;

                default:
                    break;
            }
        }
    }
}
