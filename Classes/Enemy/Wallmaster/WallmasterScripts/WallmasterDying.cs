using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts
{
    public class WallmasterDying : ICommand
    {
        private EnemyWallmaster wallmaster;
        private WallmasterSpriteFactory wallmasterSpriteFactory;
        private WallmasterStateMachine wallmasterStateMachine;

        public WallmasterDying(EnemyWallmaster walmaster, WallmasterSpriteFactory wallmasterSpriteFactory, WallmasterStateMachine wallmasterStateMachine)
        {
            this.wallmaster = walmaster;
            this.wallmasterSpriteFactory = wallmasterSpriteFactory;
            this.wallmasterStateMachine = wallmasterStateMachine;
        }

        public void Execute()
        {
            wallmaster.spriteSize.X = 16;
            wallmaster.spriteSize.Y = 16;
            wallmaster.velocity.X = 0;
            wallmaster.velocity.Y = 0;

            if (wallmasterStateMachine.currentState != WallmasterStateMachine.CurrentState.dying)
            {
                wallmasterStateMachine.currentState = WallmasterStateMachine.CurrentState.dying;
                wallmaster.mySprite = wallmasterSpriteFactory.KillWallmaster();
                wallmaster.game.collisionManager.collisionEntities.Remove(wallmaster);
                wallmaster.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
