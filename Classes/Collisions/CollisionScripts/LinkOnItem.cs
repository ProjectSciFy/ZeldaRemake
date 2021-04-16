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
        private Link link { get; set; }
        private IItem item { get; set; }
        private Collision.Collision.Direction direction { get; set; }

        public LinkOnItem(Link link, IItem item, Collision.Collision.Direction direction)
        {
            this.link = link;
            this.item = item;
            this.direction = direction;
        }
        
        public void Execute()
        {
            link.game.collisionManager.collisionEntities.Remove((ICollisionEntity)item);
            link.game.currentRoom.removeItem(item);

            if(item is Triforce)
            {
                link.game.sounds["fanfare"].CreateInstance().Play();
                link.game.sounds["getItem"].CreateInstance().Play();

                link.linkState.grabItem = true;
                link.linkState.isTriforce = true;
                ((Triforce)item).position.X = link.drawLocation.X;
                ((Triforce)item).position.Y = link.drawLocation.Y - (16 * link.spriteScalar);

                link.game.currentGameState = new WinState(link.game);
            }
            else if (item is Bow)
            {
                link.linkState.grabItem = true;
                link.game.sounds["fanfare"].CreateInstance().Play();
                link.game.sounds["getItem"].CreateInstance().Play();
            }
            else if (item is Key)
            {
                link.game.sounds["getHeart"].CreateInstance().Play();
            }
            else if (item is Boomerang || item is Compass || item is Fairy || item is HeartContainer || item is Map || item is Triforce)
            {
                link.game.sounds["getItem"].CreateInstance().Play();
            }
            else if (item is BlueRupee || item is YellowRupee)
            {
                link.game.sounds["getRupee"].CreateInstance().Play();
            }
        }
    }
}
