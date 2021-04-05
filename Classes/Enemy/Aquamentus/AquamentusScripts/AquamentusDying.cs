using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus.AquamentusScripts
{
    public class AquamentusDying : ICommand
    {
        private EnemyAquamentus aquamentus;
        private AquamentusSpriteFactory aquaSpriteFactory;
        private AquamentusStateMachine aquaStateMachine;
        public AquamentusDying(EnemyAquamentus aquamentus, AquamentusSpriteFactory aquaSpriteFactory, AquamentusStateMachine aquaStateMachine)
        {
            this.aquamentus = aquamentus;
            this.aquaSpriteFactory = aquaSpriteFactory;
            this.aquaStateMachine = aquaStateMachine;
        }
        public void Execute()
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = 0;
            aquamentus.velocity.Y = 0;

            if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.dying)
            {
                aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.dying;
                aquamentus.mySprite = aquaSpriteFactory.SpawnAquamentus();
                aquamentus.game.collisionManager.collisionEntities.Remove(aquamentus);
                aquamentus.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
