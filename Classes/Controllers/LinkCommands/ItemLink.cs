using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class ItemLink : ICommand
    {
        private StateMachine linkState;
        private StateMachine.Item itemSelected;
        private StateMachine.Direction direction;

        public ItemLink(StateMachine linkState, StateMachine.Item item, StateMachine.Direction direction)
        {
            this.linkState = linkState;
            this.itemSelected = item;
            this.direction = direction;
        }

        public void Execute()
        { 
            linkState.moving = false;
            // need to update link's state so that corresponding animation is drawn.
            switch (itemSelected)
            {
                case StateMachine.Item.sword:
                    linkState.itemSelected = StateMachine.Item.sword;
                    linkState.useSword = true;
                    break;

                case StateMachine.Item.bomb:
                    linkState.itemSelected = StateMachine.Item.bomb;
                    linkState.useBomb = true;
                    break;

                case StateMachine.Item.arrow:
                    linkState.itemSelected = StateMachine.Item.arrow;
                    linkState.useArrow = true;
                    break;

                case StateMachine.Item.boomerang:
                    linkState.itemSelected = StateMachine.Item.boomerang;
                    linkState.useBoomerang = true;
                    break;
            }
            
        }
    }
}
