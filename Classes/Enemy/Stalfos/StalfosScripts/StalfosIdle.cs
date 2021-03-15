using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Stalfos.StalfosScripts
{
    public class StalfosIdle : ICommand
    {
        private EnemyStalfos stalfos;
        private StalfosSpriteFactory stalfosSpriteFactory;
        private StalfosStateMachine stalfosStateMachine;
        public StalfosIdle(EnemyStalfos stalfos, StalfosSpriteFactory stalfosSpriteFactory, StalfosStateMachine stalfosStateMachine)
        {
            this.stalfos = stalfos;
            this.stalfosSpriteFactory = stalfosSpriteFactory;
            this.stalfosStateMachine = stalfosStateMachine;
        }

        public void Execute()
        {
            if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.idle)
            {
                stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.idle;
                this.stalfos.mySprite = stalfosSpriteFactory.StalfosIdle();
            }
        }
    }
}
