using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Items
{
    public class ItemStateMachine
    {
        private EeveeSim game;
        private Item item;
        private ItemSpriteFactory spriteFactory;

        private int timer = 0;
        public enum ItemType { Boomerang, Bomb, Bow, Arrow, Key, Compass, Shard, Heart, HeartContainer, Clock, Food, YellowRupee, RedPotion, Map, BlueRupee, SecondPotion, Letter, Sword, Shield, RedCandle, BlueCandle, RedRing, BlueRing, Bracelet, Flute, Raft, Stepladder, Rod, Book };
        public ItemType currentState = ItemType.Heart;

        public ItemStateMachine(Item item)
        {
            this.game = item.game;
            this.item = item;
            spriteFactory = new ItemSpriteFactory(item);
            spriteFactory.Heart();
        }

        public void Update()
        {
            switch (currentState)
            {
                case ItemType.Boomerang:
                    spriteFactory.Boomerang();
                    break;
                case ItemType.Bomb:
                    spriteFactory.Bomb();
                    break;
                case ItemType.Bow:
                    spriteFactory.Bow();
                    break;
                case ItemType.Arrow:
                    spriteFactory.Arrow();
                    break;
                case ItemType.Key:
                    spriteFactory.Key();
                    break;
                case ItemType.Compass:
                    spriteFactory.Compass();
                    break;
                case ItemType.Shard:
                    spriteFactory.Shard();
                    break;
                case ItemType.Heart:
                    spriteFactory.Heart();
                    break;
                case ItemType.HeartContainer:
                    spriteFactory.HeartContainer();
                    break;
                case ItemType.Clock:
                    spriteFactory.Clock();
                    break;
                case ItemType.Food:
                    spriteFactory.Food();
                    break;
                case ItemType.YellowRupee:
                    spriteFactory.YellowRupee();
                    break;
                case ItemType.RedPotion:
                    spriteFactory.RedPotion();
                    break;
                case ItemType.Map:
                    spriteFactory.Map();
                    break;
                case ItemType.BlueRupee:
                    spriteFactory.BlueRupee();
                    break;
                case ItemType.SecondPotion:
                    spriteFactory.SecondPotion();
                    break;
                case ItemType.Letter:
                    spriteFactory.Letter();
                    break;
                case ItemType.Sword:
                    spriteFactory.Sword();
                    break;
                case ItemType.Shield:
                    spriteFactory.Shield();
                    break;
                case ItemType.RedCandle:
                    spriteFactory.RedCandle();
                    break;
                case ItemType.BlueCandle:
                    spriteFactory.BlueCandle();
                    break;
                case ItemType.RedRing:
                    spriteFactory.RedRing();
                    break;
                case ItemType.BlueRing:
                    spriteFactory.BlueRing();
                    break;
                case ItemType.Bracelet:
                    spriteFactory.Bracelet();
                    break;
                case ItemType.Flute:
                    spriteFactory.Flute();
                    break;
                case ItemType.Raft:
                    spriteFactory.Raft();
                    break;
                case ItemType.Stepladder:
                    spriteFactory.Stepladder();
                    break;
                case ItemType.Rod:
                    spriteFactory.Rod();
                    break;
                case ItemType.Book:
                    spriteFactory.Book();
                    break;
                default:
                    break;
            }
        }
    }
}
