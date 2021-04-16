using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class RollLink : ICommand
    {
        private LinkStateMachine linkState { get; set; }

        public RollLink(LinkStateMachine linkState)
        {
            this.linkState = linkState;
        }

        public void Execute()
        {
            linkState.isRolling = true;
        }
    }
}
