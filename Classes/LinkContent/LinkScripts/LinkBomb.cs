using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkBomb : ICommand
    {
        private Link link { get; set; }
        private LinkSpriteFactory spriteFactory { get; set; }
        private LinkStateMachine linkStateMachine { get; set; }

        public LinkBomb(Link link, LinkSpriteFactory spriteFactory, LinkStateMachine linkStateMachine)
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
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.bombRight)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.bombRight;
                        link.linkSprite = spriteFactory.BombRight();
                        linkStateMachine.projectileHandler.Add(new Bomb(link.game, new Vector2(link.drawLocation.X + 16, link.drawLocation.Y), linkStateMachine.projectileHandler));
                    }
                    break;
                case LinkStateMachine.Direction.up:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.bombUp)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.bombUp;
                        link.linkSprite = spriteFactory.BombUp();
                        linkStateMachine.projectileHandler.Add(new Bomb(link.game, new Vector2(link.drawLocation.X, link.drawLocation.Y - 16), linkStateMachine.projectileHandler));
                    }
                    break;
                case LinkStateMachine.Direction.left:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.bombLeft)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.bombLeft;
                        link.linkSprite = spriteFactory.BombLeft();
                        linkStateMachine.projectileHandler.Add(new Bomb(link.game, new Vector2(link.drawLocation.X - 16, link.drawLocation.Y), linkStateMachine.projectileHandler));
                    }
                    break;
                case LinkStateMachine.Direction.down:
                    if (linkStateMachine.currentState != LinkStateMachine.CurrentState.bombDown)
                    {
                        linkStateMachine.currentState = LinkStateMachine.CurrentState.bombDown;
                        link.linkSprite = spriteFactory.BombDown();
                        linkStateMachine.projectileHandler.Add(new Bomb(link.game, new Vector2(link.drawLocation.X, link.drawLocation.Y + 16), linkStateMachine.projectileHandler));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
