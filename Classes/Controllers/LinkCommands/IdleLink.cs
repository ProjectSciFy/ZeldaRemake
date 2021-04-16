using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class IdleLink : ICommand
    {
        private LinkStateMachine linkState { get; set; }

        public IdleLink(LinkStateMachine linkState)
        {
            this.linkState = linkState;
        }

        public void Execute()
        {
            linkState.moving = false;
           
        }
    }
}
