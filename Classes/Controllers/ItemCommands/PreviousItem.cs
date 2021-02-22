using CSE3902_Game_Sprint0.Classes.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.ItemCommands
{
    public class PreviousItem : ICommand
    {
        private ItemStateMachine itemStateMachine;
        private ItemStateMachine.ItemType currentItem;

        public PreviousItem(ItemStateMachine itemStateMachine)
        {
            this.itemStateMachine = itemStateMachine;
            this.currentItem = itemStateMachine.currentState;
        }

        public void Execute()
        {
            this.currentItem = itemStateMachine.currentState;
            switch (this.currentItem)
            {
                case ItemStateMachine.ItemType.Boomerang:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Book;
                    this.currentItem = ItemStateMachine.ItemType.Book;
                    break;
                case ItemStateMachine.ItemType.Bomb:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Boomerang;
                    this.currentItem = ItemStateMachine.ItemType.Boomerang;
                    break;
                case ItemStateMachine.ItemType.Bow:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Bomb;
                    this.currentItem = ItemStateMachine.ItemType.Bomb;
                    break;
                case ItemStateMachine.ItemType.Arrow:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Bow;
                    this.currentItem = ItemStateMachine.ItemType.Bow;
                    break;
                case ItemStateMachine.ItemType.Key:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Arrow;
                    this.currentItem = ItemStateMachine.ItemType.Arrow;
                    break;
                case ItemStateMachine.ItemType.Compass:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Key;
                    this.currentItem = ItemStateMachine.ItemType.Key;
                    break;
                case ItemStateMachine.ItemType.Shard:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Compass;
                    this.currentItem = ItemStateMachine.ItemType.Compass;
                    break;
                case ItemStateMachine.ItemType.Heart:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Shard;
                    this.currentItem = ItemStateMachine.ItemType.Shard;
                    break;
                case ItemStateMachine.ItemType.HeartContainer:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Heart;
                    this.currentItem = ItemStateMachine.ItemType.Heart;
                    break;
                case ItemStateMachine.ItemType.Clock:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.HeartContainer;
                    this.currentItem = ItemStateMachine.ItemType.HeartContainer;
                    break;
                case ItemStateMachine.ItemType.Food:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Clock;
                    this.currentItem = ItemStateMachine.ItemType.Clock;
                    break;
                case ItemStateMachine.ItemType.YellowRupee:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Food;
                    this.currentItem = ItemStateMachine.ItemType.Food;
                    break;
                case ItemStateMachine.ItemType.RedPotion:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.YellowRupee;
                    this.currentItem = ItemStateMachine.ItemType.YellowRupee;
                    break;
                case ItemStateMachine.ItemType.Map:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.RedPotion;
                    this.currentItem = ItemStateMachine.ItemType.RedPotion;
                    break;
                case ItemStateMachine.ItemType.BlueRupee:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Map;
                    this.currentItem = ItemStateMachine.ItemType.Map;
                    break;
                case ItemStateMachine.ItemType.SecondPotion:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.BlueRupee;
                    this.currentItem = ItemStateMachine.ItemType.BlueRupee;
                    break;
                case ItemStateMachine.ItemType.Letter:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.SecondPotion;
                    this.currentItem = ItemStateMachine.ItemType.SecondPotion;
                    break;
                case ItemStateMachine.ItemType.Sword:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Letter;
                    this.currentItem = ItemStateMachine.ItemType.Letter;
                    break;
                case ItemStateMachine.ItemType.Shield:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Sword;
                    this.currentItem = ItemStateMachine.ItemType.Sword;
                    break;
                case ItemStateMachine.ItemType.RedCandle:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Shield;
                    this.currentItem = ItemStateMachine.ItemType.Shield;
                    break;
                case ItemStateMachine.ItemType.BlueCandle:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.RedCandle;
                    this.currentItem = ItemStateMachine.ItemType.RedCandle;
                    break;
                case ItemStateMachine.ItemType.RedRing:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.BlueCandle;
                    this.currentItem = ItemStateMachine.ItemType.BlueCandle;
                    break;
                case ItemStateMachine.ItemType.BlueRing:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.RedRing;
                    this.currentItem = ItemStateMachine.ItemType.RedRing;
                    break;
                case ItemStateMachine.ItemType.Bracelet:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.BlueRing;
                    this.currentItem = ItemStateMachine.ItemType.BlueRing;
                    break;
                case ItemStateMachine.ItemType.Flute:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Bracelet;
                    this.currentItem = ItemStateMachine.ItemType.Bracelet;
                    break;
                case ItemStateMachine.ItemType.Raft:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Flute;
                    this.currentItem = ItemStateMachine.ItemType.Flute;
                    break;
                case ItemStateMachine.ItemType.Stepladder:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Raft;
                    this.currentItem = ItemStateMachine.ItemType.Raft;
                    break;
                case ItemStateMachine.ItemType.Rod:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Stepladder;
                    this.currentItem = ItemStateMachine.ItemType.Stepladder;
                    break;
                case ItemStateMachine.ItemType.Book:
                    itemStateMachine.currentState = ItemStateMachine.ItemType.Rod;
                    this.currentItem = ItemStateMachine.ItemType.Rod;
                    break;
                default:
                    break;
            }
        }
        
    }
}
