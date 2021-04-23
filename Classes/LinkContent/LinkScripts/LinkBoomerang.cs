using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkBoomerang : ICommand
    {
        private Link link { get; set; }
        private LinkSpriteFactory spriteFactory { get; set; }
        private LinkStateMachine linkStateMachine { get; set; }

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
                        linkStateMachine.projectileHandler.Add(new LinkBoomerangProjectile(link, linkStateMachine));
                    }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.boomerangUp)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.boomerangUp;
                        link.linkSprite = spriteFactory.BoomerangUp();
                        linkStateMachine.projectileHandler.Add(new LinkBoomerangProjectile(link, linkStateMachine));
                    }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.boomerangLeft)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.boomerangLeft;
                        link.linkSprite = spriteFactory.BoomerangLeft();
                        linkStateMachine.projectileHandler.Add(new LinkBoomerangProjectile(link, linkStateMachine));
                    }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.boomerangDown)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.boomerangDown;
                        link.linkSprite = spriteFactory.BoomerangDown();
                        linkStateMachine.projectileHandler.Add(new LinkBoomerangProjectile(link, linkStateMachine));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
