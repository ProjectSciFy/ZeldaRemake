using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead.RedeadScripts
{
    public class RedeadMoving
    {
        private EnemyRedead redead { get; set; }
        private RedeadSpriteFactory redeadSpriteFactory { get; set; }
        private RedeadStateMachine redeadStateMachine { get; set; }
        public RedeadMoving(EnemyRedead redead, RedeadSpriteFactory redeadSpriteFactory, RedeadStateMachine redeadStateMachine)
        {
            this.redead = redead;
            this.redeadSpriteFactory = redeadSpriteFactory;
            this.redeadStateMachine = redeadStateMachine;
        }

        public void Execute()
        {
            redead.spriteSize.X = 16;
            redead.spriteSize.Y = 16;

            switch (redeadStateMachine.direction)
            {
                case RedeadStateMachine.Direction.right:
                    if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.movingRight)
                    {
                        redead.velocity.X = 1;
                        redead.velocity.Y = 0;
                        redeadStateMachine.currentState = RedeadStateMachine.CurrentState.movingRight;
                        redead.mySprite = redeadSpriteFactory.RedeadMoving();
                    }
                    break;
                case RedeadStateMachine.Direction.up:
                    if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.movingUp)
                    {
                        redead.velocity.X = 0;
                        redead.velocity.Y = -1;
                        redeadStateMachine.currentState = RedeadStateMachine.CurrentState.movingUp;
                        redead.mySprite = redeadSpriteFactory.RedeadMoving();
                    }
                    break;
                case RedeadStateMachine.Direction.left:
                    if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.movingLeft)
                    {
                        redead.velocity.X = -1;
                        redead.velocity.Y = 0;
                        redeadStateMachine.currentState = RedeadStateMachine.CurrentState.movingLeft;
                        redead.mySprite = redeadSpriteFactory.RedeadMoving();
                    }
                    break;
                case RedeadStateMachine.Direction.down:
                    if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.movingDown)
                    {
                        redead.velocity.X = 0;
                        redead.velocity.Y = 1;
                        redeadStateMachine.currentState = RedeadStateMachine.CurrentState.movingDown;
                        redead.mySprite = redeadSpriteFactory.RedeadMoving();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
