using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class SwordLink : ICommand
    {
        private StateMachine linkState;

        public SwordLink(StateMachine linkState)
        {
            this.linkState = linkState;
        }

        public void Execute()
        { 
            linkState.moving = false;
            // TO DO:
            // need to update link's state so that he is now drawn with a sword.

            
        }
    }
}
