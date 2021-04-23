using CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster.WallmasterScripts;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Interfaces;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game { get; set; }
        private EnemyWallmaster wallmaster { get; set; }
        private WallmasterSpriteFactory wallmasterSpriteFactory { get; set; }

        public enum Direction { right, up, left, down };
        public Direction direction { get; set; } = Direction.up;
        private int staging { get; set; } = 0;
        public bool activating { get; set; } = false;
        public bool active { get; set; } = false;
        public int timer { get; set; } = 0;
        private int deathTimer { get; set; } = 30;
        public enum CurrentState { none, emerging, hiding, idle, movingUp, movingDown, movingLeft, movingRight, dying };
        public CurrentState currentState { get; set; } = CurrentState.none;

        public WallmasterStateMachine(EnemyWallmaster wallmaster)
        {
            this.wallmaster = wallmaster;
            game = wallmaster.game;
            wallmasterSpriteFactory = new WallmasterSpriteFactory(game);
        }
        public void Dying()
        {
            new WallmasterDying(wallmaster, wallmasterSpriteFactory, this).Execute();
        }
        public void Idle()
        {
            new WallmasterIdle(wallmaster, wallmasterSpriteFactory, this).Execute();
        }

        public void Moving()
        {
            new WallmasterMoving(wallmaster, wallmasterSpriteFactory, this).Execute();
        }

        public void Hiding()
        {
            if (timer <= 0)
            {
                new WallmasterHiding(wallmaster, wallmasterSpriteFactory).Execute();
            }
        }

        public void Update()
        {
            if (wallmaster.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    new DropMinorItem(wallmaster.game, wallmaster.drawLocation).Execute();
                    wallmaster.game.currentRoom.removeEnemy(wallmaster);
                }
            }
            if (timer <= 0)
            {
                if (activating && !active)
                {
                    timer = 32;
                    activating = false;
                    active = true;
                    Moving();
                }
                else if (active)
                {
                    switch (staging)
                    {
                        case 0:
                            timer = 64;
                            new WallmasterTurnClockwise(this).Execute();
                            Moving();
                            break;
                        case 1:
                            timer = 128;
                            new WallmasterTurnClockwise(this).Execute();
                            Moving();
                            break;
                        case 2:
                            Hiding();
                            active = false;
                            staging = -1;
                            break;
                        default:
                            break;
                    }
                    staging++;
                }
            }
            else
            {
                timer--;
            }
        }
    }
}
