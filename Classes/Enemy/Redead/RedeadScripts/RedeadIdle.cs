using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead.RedeadScripts
{
    public class RedeadIdle : ICommand
    {
        private EnemyRedead redead { get; set; }
        private RedeadSpriteFactory redeadSpriteFactory { get; set; }
        private RedeadStateMachine redeadStateMachine { get; set; }
        public RedeadIdle(EnemyRedead redead, RedeadSpriteFactory redeadSpriteFactory, RedeadStateMachine redeadStateMachine)
        {
            this.redead = redead;
            this.redeadSpriteFactory = redeadSpriteFactory;
            this.redeadStateMachine = redeadStateMachine;
        }

        public void Execute()
        {
            if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.idle)
            {
                redead.spriteSize.X = 16;
                redead.spriteSize.Y = 16;
                redead.velocity.X = 0;
                redead.velocity.Y = 0;

                redeadStateMachine.currentState = RedeadStateMachine.CurrentState.idle;
                this.redead.mySprite = redeadSpriteFactory.RedeadIdle();
                redead.game.sounds["redeadIdle"].CreateInstance().Play();
            }
        }
    }
}
