using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster.WallmasterScripts
{
    public class WallmasterIdle : ICommand
    {
        private EnemyWallmaster wallmaster;
        private WallmasterSpriteFactory wallmasterSpriteFactory;
        private WallmasterStateMachine wallmasterStateMachine;

        public WallmasterIdle(EnemyWallmaster wallmaster, WallmasterSpriteFactory wallmasterSpriteFactory, WallmasterStateMachine wallmasterStateMachine)
        {
            this.wallmaster = wallmaster;
            this.wallmasterSpriteFactory = wallmasterSpriteFactory;
            this.wallmasterStateMachine = wallmasterStateMachine;
        }

        public void Execute()
        {
            wallmaster.spriteSize.X = 16;
            wallmaster.spriteSize.Y = 16;
            wallmaster.velocity.X = 0;
            wallmaster.velocity.Y = 0;

            if (wallmasterStateMachine.currentState != WallmasterStateMachine.CurrentState.idle)
            {
                wallmasterStateMachine.currentState = WallmasterStateMachine.CurrentState.idle;
                wallmaster.mySprite = wallmasterSpriteFactory.WallmasterIdle();
            }
        }
    }
}
