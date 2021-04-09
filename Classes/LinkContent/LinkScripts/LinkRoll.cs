using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkRoll : ICommand
    {
        private Link link;
        private LinkSpriteFactory spriteFactory;
        private LinkStateMachine linkStateMachine;
        public LinkRoll(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
        {
            this.link = link;
            this.spriteFactory = spriteFactory;
            this.linkStateMachine = linkStateMachine;
        }

        public void Execute()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;

            switch (linkStateMachine.direction)
            {
                case LinkStateMachine.Direction.right:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.rollingRight)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.rollingRight;
                        link.velocity.X = 6;
                        link.velocity.Y = 0;
                        link.linkSprite = spriteFactory.RollRight();
                    }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.rollingUp)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.rollingUp;
                        link.velocity.X = 0;
                        link.velocity.Y = -6;
                        link.linkSprite = spriteFactory.RollUp();
                    }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.rollingLeft)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.rollingLeft;
                        link.velocity.X = -6;
                        link.velocity.Y = 0;
                        link.linkSprite = spriteFactory.RollLeft();
                    }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.rollingDown)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.rollingDown;
                        link.velocity.X = 0;
                        link.velocity.Y = 6;
                        link.linkSprite = spriteFactory.RollDown();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
