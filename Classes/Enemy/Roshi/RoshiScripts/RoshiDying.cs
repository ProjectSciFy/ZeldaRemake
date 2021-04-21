using CSE3902_Game_Sprint0.Classes.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiDying : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiDying(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
        {
            this.roshi = roshi;
            this.spriteFactory = spriteFactory;
            this.roshiState = roshiState;
        }

        public void Execute()
        {
            roshi.spriteSize.X = 43;
            roshi.spriteSize.Y = 41;
            roshi.velocity.X = 0;
            roshi.velocity.Y = 0;
            if (roshiState.kiBlast != null)
            {
                roshi.game.projectileHandler.Remove(roshiState.kiBlast);
                roshi.game.collisionManager.collisionEntities.Remove(roshiState.kiBlast);
            }
            if (roshiState.currentState != RoshiStateMachine.CurrentState.dying)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.dying;
                roshi.mySprite = spriteFactory.RoshiDying();
                roshi.game.collisionManager.collisionEntities.Remove(roshi);
                roshi.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
