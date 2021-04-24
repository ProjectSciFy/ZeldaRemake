using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkMoving : ICommand
    {
        private Link link { get; set; }
        private LinkSpriteFactory spriteFactory { get; set; }
        private LinkStateMachine linkStateMachine { get; set; }

        public LinkMoving(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
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
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.movingRight)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.movingRight;
                        link.velocity.X = 3; link.velocity.Y = 0;
                        link.linkSprite = spriteFactory.MovingRight();
                    }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.movingUp)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.movingUp;
                        link.velocity.X = 0; link.velocity.Y = -3;
                        link.linkSprite = spriteFactory.MovingUp();
                    }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.movingLeft)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.movingLeft;
                        link.velocity.X = -3; link.velocity.Y = 0;
                        link.linkSprite = spriteFactory.MovingLeft();
                    }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.movingDown)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.movingDown;
                        link.velocity.X = 0; link.velocity.Y = 3;
                        link.linkSprite = spriteFactory.MovingDown();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
