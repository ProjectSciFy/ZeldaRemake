using CSE3902_Game_Sprint0.Classes.GameState;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class LinkOnItem : ICommand
    {
        private Link link;
        private IItem item;
        private Collision.Collision.Direction direction;

        public LinkOnItem(Link link, IItem item, Collision.Collision.Direction direction)
        {
            this.link = link;
            this.item = item;
            this.direction = direction;
        }
        
        public void Execute()
        {
            link.game.collisionManager.collisionEntities.Remove((ICollisionEntity)item);
            //TODO - DELETE THE ITEM FROM WHEREVER IT IS BEING STORED!!!
            link.game.currentRoom.removeItem(item);

            if(item is Triforce)
            {
                link.game.currentGameState = new WinState(link.game);
            }
        }
    }
}
