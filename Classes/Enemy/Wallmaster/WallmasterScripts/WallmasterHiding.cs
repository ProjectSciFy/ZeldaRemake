namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster.WallmasterScripts
{
    public class WallmasterHiding : ICommand
    {
        private EnemyWallmaster wallmaster { get; set; }
        private WallmasterSpriteFactory wallmasterSpriteFactory { get; set; }

        public WallmasterHiding(EnemyWallmaster wallmaster, WallmasterSpriteFactory wallmasterSpriteFactory)
        {
            this.wallmaster = wallmaster;
            this.wallmasterSpriteFactory = wallmasterSpriteFactory;
        }

        public void Execute()
        {
            wallmaster.drawLocation.X = 0;
            wallmaster.drawLocation.Y = 0;
            wallmaster.spriteSize.X = 0;
            wallmaster.spriteSize.Y = 0;
            wallmaster.velocity.X = 0;
            wallmaster.velocity.Y = 0;
            wallmaster.mySprite = wallmasterSpriteFactory.WallmasterHiding();
        }
    }
}
