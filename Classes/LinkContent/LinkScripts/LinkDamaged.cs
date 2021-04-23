using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkDamaged : ICommand
    {
        private Link link { get; set; }
        private LinkSpriteFactory spriteFactory { get; set; }
        private LinkStateMachine linkStateMachine { get; set; }

        public LinkDamaged(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
        {
            this.link = link;
            this.spriteFactory = spriteFactory;
            this.linkStateMachine = linkStateMachine;
        }

        public void Execute()
        {
            link.spriteSize.X = 16; link.spriteSize.Y = 16;
            switch (linkStateMachine.direction) {
                case LinkStateMachine.Direction.right:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.damagedRight) {
                        link.velocity.X = -4; link.velocity.Y = 0;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.damagedRight;
                        link.linkSprite = spriteFactory.DamageRight(); }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.damagedUp) {
                        link.velocity.X = 0; link.velocity.Y = 4;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.damagedUp;
                        link.linkSprite = spriteFactory.DamageUp(); }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.damagedLeft) {
                        link.velocity.X = 4; link.velocity.Y = 0;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.damagedLeft;
                        link.linkSprite = spriteFactory.DamageLeft(); }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.damagedDown) {
                        link.velocity.X = 0; link.velocity.Y = -4;
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.damagedDown;
                        link.linkSprite = spriteFactory.DamageDown(); }
                    break;
                default:
                    break; }
        }
    }
}
