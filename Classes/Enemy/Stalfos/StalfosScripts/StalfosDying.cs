using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Stalfos.StalfosScripts
{
    public class StalfosDying : ICommand
    {
        private EnemyStalfos stalfos;
        private StalfosSpriteFactory spriteFactory;
        private StalfosStateMachine stalfosStateMachine;

        public StalfosDying(EnemyStalfos stalfos, StalfosSpriteFactory spriteFactory, StalfosStateMachine stalfosStateMachine)
        {
            this.stalfos = stalfos;
            this.spriteFactory = spriteFactory;
            this.stalfosStateMachine = stalfosStateMachine;
        }

        public void Execute()
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = 0;

            if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.dying)
            {
                stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.dying;
                stalfos.mySprite = spriteFactory.SpawnStalfos();
                stalfos.game.collisionManager.collisionEntities.Remove(stalfos);
            }
        }
    }
}
