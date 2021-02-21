﻿using System;
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
            switch (itemSelected)
            {
                case StateMachine.Item.sword:
                    linkState.itemSelected = StateMachine.Item.sword;
                    break;

                case StateMachine.Item.bomb:
                    linkState.itemSelected = StateMachine.Item.bomb;
                    break;

                case StateMachine.Item.arrow:
                    linkState.itemSelected = StateMachine.Item.arrow;
                    break;

                case StateMachine.Item.boomerang:
                    linkState.itemSelected = StateMachine.Item.boomerang;
                    break;
            }
            
        }
    }
}