using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkArrow : ICommand
    {
        private Link link;
        private LinkSpriteFactory spriteFactory;
        private LinkStateMachine linkStateMachine;

        public LinkArrow(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
        {
            this.link = link;
            this.spriteFactory = spriteFactory;
            this.linkStateMachine = linkStateMachine;
        }

        public void Execute()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;

            switch (linkStateMachine.direction)
            {
                case LinkStateMachine.Direction.right:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.arrowRight)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.arrowRight;
                        spriteFactory.ArrowRight();
                        linkStateMachine.projectileHandler.Add(new Arrow(link.game, new Vector2(link.drawLocation.X + 16, link.drawLocation.Y), linkStateMachine.projectileHandler, Projectiles.Arrow.Direction.right));
                    }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.arrowUp)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.arrowUp;
                        spriteFactory.ArrowUp();
                        linkStateMachine.projectileHandler.Add(new Arrow(link.game, new Vector2(link.drawLocation.X + 4, link.drawLocation.Y - 16), linkStateMachine.projectileHandler, Projectiles.Arrow.Direction.up));
                    }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.arrowLeft)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.arrowLeft;
                        spriteFactory.ArrowLeft();
                        linkStateMachine.projectileHandler.Add(new Arrow(link.game, new Vector2(link.drawLocation.X - 16, link.drawLocation.Y), linkStateMachine.projectileHandler, Projectiles.Arrow.Direction.left));
                    }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.arrowDown)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.arrowDown;
                        spriteFactory.ArrowDown();
                        linkStateMachine.projectileHandler.Add(new Arrow(link.game, new Vector2(link.drawLocation.X + 4, link.drawLocation.Y + 16), linkStateMachine.projectileHandler, Projectiles.Arrow.Direction.down));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
