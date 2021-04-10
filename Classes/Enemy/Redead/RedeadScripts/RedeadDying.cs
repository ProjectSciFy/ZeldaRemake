using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead.RedeadScripts
{
    public class RedeadDying : ICommand
    {
        private EnemyRedead redead;
        private RedeadSpriteFactory spriteFactory;
        private RedeadStateMachine redeadStateMachine;

        public RedeadDying(EnemyRedead redead, RedeadSpriteFactory spriteFactory, RedeadStateMachine redeadStateMachine)
        {
            this.redead = redead;
            this.spriteFactory = spriteFactory;
            this.redeadStateMachine = redeadStateMachine;
        }

        public void Execute()
        {
            redead.spriteSize.X = 16;
            redead.spriteSize.Y = 16;
            redead.velocity.X = 0;
            redead.velocity.Y = 0;

            if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.dying)
            {
                redeadStateMachine.currentState = RedeadStateMachine.CurrentState.dying;
                redead.mySprite = spriteFactory.SpawnRedead();
                redead.game.collisionManager.collisionEntities.Remove(redead);
                redead.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
