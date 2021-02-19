using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class ItemLink : ICommand
    {
        private StateMachine linkState;
        private StateMachine.Item itemSelected;

        public ItemLink(StateMachine linkState, StateMachine.Item item)
        {
            this.linkState = linkState;
            this.itemSelected = item;
        }

        public void Execute()
        { 
            linkState.moving = false;
            // need to update link's state so that he is now drawn with the item.
            // equpping item animation code below?
            
        }
    }
}
