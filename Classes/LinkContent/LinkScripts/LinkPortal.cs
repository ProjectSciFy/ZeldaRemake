using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkPortal : ICommand
    {
        private Link link { get; set; }
        private LinkSpriteFactory spriteFactory { get; set; }
        private LinkStateMachine linkStateMachine { get; set; }

        public LinkPortal(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
        {
            this.link = link;
            this.spriteFactory = spriteFactory;
            this.linkStateMachine = linkStateMachine;
        }

        public void Execute()
        {
            link.velocity.X = 0;
            link.velocity.Y = 0;

            switch (linkStateMachine.direction)
            {
                case LinkStateMachine.Direction.right:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.portalRight)
                    {
                        link.spriteSize.X = 27;
                        link.spriteSize.Y = 16;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.portalRight;
                        link.linkSprite = spriteFactory.PortalRight();
                    }
                    break;
                case LinkStateMachine.Direction.up:
                    link.drawOffset.X = 0 * link.spriteScalar;
                    link.drawOffset.Y = -12 * link.spriteScalar;
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.portalUp)
                    {
                        link.spriteSize.X = 16;
                        link.spriteSize.Y = 28;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.portalUp;
                        link.linkSprite = spriteFactory.PortalUp();
                    }
                    break;
                case LinkStateMachine.Direction.left:
                    link.drawOffset.X = -11 * link.spriteScalar;
                    link.drawOffset.Y = 0 * link.spriteScalar;
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.portalLeft)
                    {
                        link.spriteSize.X = 27;
                        link.spriteSize.Y = 16;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.portalLeft;
                        link.linkSprite = spriteFactory.PortalLeft();
                    }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.portalDown)
                    {
                        link.spriteSize.X = 16;
                        link.spriteSize.Y = 27;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.portalDown;
                        link.linkSprite = spriteFactory.PortalDown();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
