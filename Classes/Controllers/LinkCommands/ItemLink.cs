using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class ItemLink : ICommand
    {
        private LinkStateMachine linkState;
        private LinkStateMachine.Item itemSelected;
        private LinkStateMachine.Direction direction;

        public ItemLink(LinkStateMachine linkState, LinkStateMachine.Item item, LinkStateMachine.Direction direction)
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
                case LinkStateMachine.Item.sword:
                    linkState.itemSelected = LinkStateMachine.Item.sword;
                    linkState.Sword();
                    break;

                case LinkStateMachine.Item.bomb:
                    linkState.itemSelected = LinkStateMachine.Item.bomb;
                    linkState.Bomb();
                    break;

                case LinkStateMachine.Item.arrow:
                    linkState.itemSelected = LinkStateMachine.Item.arrow;
                    linkState.Arrow();
                    break;

                case LinkStateMachine.Item.boomerang:
                    linkState.itemSelected = LinkStateMachine.Item.boomerang;
                    linkState.Boomerang();
                    break;
            }
        }
    }
}
