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
                link.linkState.grabItem = true;
                link.linkState.isTriforce = true;
                ((Triforce)item).position.X = link.drawLocation.X;
                ((Triforce)item).position.Y = link.drawLocation.Y - (16 * link.spriteScalar);

                link.game.currentGameState = new WinState(link.game);
            }
            else if (item is Bow)
            {
                link.linkState.grabItem = true;
            }
        }
    }
}
