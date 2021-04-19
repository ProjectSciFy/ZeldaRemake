using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Goriya.Scripts
{
    public class GoriyaDying : ICommand
    {
        private EnemyGoriya goriya { get; set; }
        private GoriyaSpriteFactory goriyaSpriteFactory { get; set; }
        private GoriyaStateMachine goriyaStateMachine { get; set; }
        public GoriyaDying(EnemyGoriya goriya, GoriyaSpriteFactory aquaSpriteFactory, GoriyaStateMachine aquaStateMachine)
        {
            this.goriya = goriya;
            this.goriyaSpriteFactory = aquaSpriteFactory;
            this.goriyaStateMachine = aquaStateMachine;
        }
        public void Execute()
        {
            goriya.spriteSize.X = 24;
            goriya.spriteSize.Y = 32;
            goriya.velocity.X = 0;
            goriya.velocity.Y = 0;

            if (goriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.dying)
            {
                goriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.dying;
                goriya.mySprite = goriyaSpriteFactory.SpawnGoriya();
                goriya.game.collisionManager.collisionEntities.Remove(goriya);
                goriya.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
