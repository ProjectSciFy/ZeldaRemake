using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class ItemLink : ICommand
    {
        private StateMachine linkState;

        public ItemLink(StateMachine linkState)
        {
            this.linkState = linkState;
        }

        public void Execute()
        { 
            linkState.moving = false;
            // need to update link's state so that he is now drawn with a sword.

            
        }
    }
}
