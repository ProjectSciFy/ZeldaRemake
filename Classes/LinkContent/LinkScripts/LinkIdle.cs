using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkIdle : ICommand
    {
        private Link link { get; set; }
        private LinkSpriteFactory spriteFactory { get; set; }
        private LinkStateMachine linkStateMachine { get; set; }

        public LinkIdle(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
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
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.idleRight) { linkStateMachine.currentState = LinkStateMachine.CurrentState.idleRight; link.linkSprite = spriteFactory.IdleRight(); }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.idleUp) { linkStateMachine.currentState = LinkStateMachine.CurrentState.idleUp; link.linkSprite = spriteFactory.IdleUp(); }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.idleLeft) { linkStateMachine.currentState = LinkStateMachine.CurrentState.idleLeft; link.linkSprite = spriteFactory.IdleLeft(); }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.idleDown) { linkStateMachine.currentState = LinkStateMachine.CurrentState.idleDown; link.linkSprite = spriteFactory.IdleDown(); }
                    break;
                default:
                    break;
            }
        }
    }
}
