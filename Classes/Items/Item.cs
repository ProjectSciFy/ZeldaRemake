using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Items
{
    public class Item : IItem
    {
        public EeveeSim game;
        private ItemStateMachine itemState;
        public ISprite itemSprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(16, 16);

        public Item(EeveeSim game)
        {
            this.game = game;
            //Arbitrary location
            drawLocation = new Vector2(500, 100);
        }

        public void SetState(ItemStateMachine empty)
        {
            itemState = empty;
        }

        public void Update()
        {
            itemSprite.Update();
            itemState.Update();
        }

        public void Draw()
        {
            itemSprite.Draw(drawLocation);
        }
    }
}
