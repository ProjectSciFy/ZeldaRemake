using CSE3902_Game_Sprint0.Classes.Projectiles.ArrowStateMachineUtility;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class ArrowStateMachine
    {
        private Arrow arrow { get; set; }
        private ProjectileSpriteFactory projectileSpriteFactory { get; set; }
        public ProjectileHandler projectileHandler { get; set; }
        public bool hit { get; set; } = false;

        private int timer { get; set; } = ArrowStateMachineStorage.STARTING_TIMER;
        public enum CurrentState { none, soaring, hitting };
        public CurrentState currentState { get; set; } = CurrentState.none;

        public ArrowStateMachine(Arrow arrow)
        {
            this.arrow = arrow;
            projectileSpriteFactory = arrow.projectileSpriteFactory;
            projectileHandler = arrow.projectileHandler;
        }

        public void Soaring()
        {
            if (currentState != CurrentState.soaring)
            {
                currentState = CurrentState.soaring;

                switch (arrow.direction)
                {
                    case Arrow.Direction.up:
                        projectileSpriteFactory.ArrowUp(arrow);
                        break;
                    case Arrow.Direction.down:
                        projectileSpriteFactory.ArrowDown(arrow);
                        break;
                    case Arrow.Direction.left:
                        projectileSpriteFactory.ArrowLeft(arrow);
                        break;
                    case Arrow.Direction.right:
                        projectileSpriteFactory.ArrowRight(arrow);
                        break;
                    default:
                        break;
                }
            }
        }

        public void Hitting()
        {
            if (currentState != CurrentState.hitting)
            {
                timer = ArrowStateMachineStorage.RESET_TIMER;
                currentState = CurrentState.hitting;
                projectileSpriteFactory.ArrowStrike(arrow);
                arrow.game.collisionManager.collisionEntities.Remove(arrow);
            }
        }

        public void Update()
        {
            if (timer <= 0 && !hit)
            {
                hit = true;
                timer = ArrowStateMachineStorage.RESET_TIMER;
            }
            else if (timer <= 0 && hit)
            {
                projectileHandler.Remove(arrow);
            }
            else
            {
                timer--;
            }

            if (!hit)
            {
                Soaring();
            }
            else
            {
                Hitting();
            }
        }
    }
}
