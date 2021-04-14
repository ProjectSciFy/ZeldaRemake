using CSE3902_Game_Sprint0.Classes.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class LittleHelperOnItem : ICommand
    {
        private LittleHelper.LittleHelper littleHelper;
        private IItem item;
        private Collision.Collision.Direction direction;
        public LittleHelperOnItem(LittleHelper.LittleHelper littleHelper, IItem item, Collision.Collision.Direction direction)
        {
            this.littleHelper = littleHelper;
            this.item = item;
            this.direction = direction;
        }

        public void Execute()
        {
            if (item is BlueRupee)
            {
                littleHelper.myState.interacting = true;
                ((BlueRupee)item).position = new Vector2(littleHelper.drawLocation.X, littleHelper.drawLocation.Y);
            }
            else if (item is Bomb)
            {
                littleHelper.myState.interacting = true;
                ((Bomb)item).position = new Vector2(littleHelper.drawLocation.X, littleHelper.drawLocation.Y);
            }
            else if (item is Fairy)
            {
                littleHelper.myState.interacting = true;
                ((Fairy)item).position = new Vector2(littleHelper.drawLocation.X, littleHelper.drawLocation.Y);
            }
            else if (item is Heart)
            {
                littleHelper.myState.interacting = true;
                ((Heart)item).position = new Vector2(littleHelper.drawLocation.X, littleHelper.drawLocation.Y);
            }
            else if (item is YellowRupee)
            {
                littleHelper.myState.interacting = true;
                ((YellowRupee)item).position = new Vector2(littleHelper.drawLocation.X, littleHelper.drawLocation.Y);
            }
        }
    }
}
