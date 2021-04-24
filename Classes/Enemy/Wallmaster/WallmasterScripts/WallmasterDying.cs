using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts
{
    public class WallmasterDying : ICommand
    {
        private EnemyWallmaster wallmaster { get; set; }
        private WallmasterSpriteFactory wallmasterSpriteFactory { get; set; }
        private WallmasterStateMachine wallmasterStateMachine { get; set; }

        public WallmasterDying(EnemyWallmaster walmaster, WallmasterSpriteFactory wallmasterSpriteFactory, WallmasterStateMachine wallmasterStateMachine)
        {
            this.wallmaster = walmaster;
            this.wallmasterSpriteFactory = wallmasterSpriteFactory;
            this.wallmasterStateMachine = wallmasterStateMachine;
        }

        public void Execute()
        {
            wallmaster.spriteSize.X = WallmasterHelper.size;
            wallmaster.spriteSize.Y = WallmasterHelper.size;
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
