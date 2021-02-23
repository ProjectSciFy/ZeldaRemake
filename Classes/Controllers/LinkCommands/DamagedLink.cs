using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    class DamagedLink : ICommand
    {
        private LinkStateMachine linkState;
        private LinkStateMachine.Direction direction;

        public DamagedLink(LinkStateMachine linkState, LinkStateMachine.Direction direction)
        {
            this.linkState = linkState;
            this.direction = direction;
        }
        public void Execute()
        {
            linkState.moving = false;

            linkState.isDamaged = true;
        }
    }
}
