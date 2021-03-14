using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkBoomerang : ICommand
    {
        private Link link;
        private LinkSpriteFactory spriteFactory;
        private LinkStateMachine linkStateMachine;

        public LinkBoomerang(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
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
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.boomerangRight)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.boomerangRight;
                        link.linkSprite = spriteFactory.BoomerangRight();
                    }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.boomerangUp)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.boomerangUp;
                        link.linkSprite = spriteFactory.BoomerangUp();
                    }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.boomerangLeft)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.boomerangLeft;
                        link.linkSprite = spriteFactory.BoomerangLeft();
                    }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.boomerangDown)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.boomerangDown;
                        link.linkSprite = spriteFactory.BoomerangDown();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
