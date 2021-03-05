using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.CollisionCommands
{
    public class LinkHurt : ICommand
    {
        public Link link;
        private Collision.Collision.Direction direction;

        public LinkHurt(Link link, Collision.Collision.Direction direction)
        {
            this.link = link;
            this.direction = direction;
        }

        public void Execute()
        {

            switch (direction)
            {
                case Collision.Collision.Direction.up:
                    link.velocity.X = 0;
                    link.velocity.Y = 2;
                    break;
                default:
                    break;
            }

            link.linkState.timer = 0;
            link.linkState.Damaged();
        }
    }
}
