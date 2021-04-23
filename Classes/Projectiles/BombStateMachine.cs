using CSE3902_Game_Sprint0.Classes.Projectiles.BombStateMachineUtility;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class BombStateMachine : IProjectileStateMachine
    {
        private Bomb bomb { get; set; }
        private ProjectileSpriteFactory projectileSpriteFactory { get; set; }
        public ProjectileHandler projectileHandler { get; set; }
        public bool fuse { get; set; } = true;

        public int timer { get; set; } = BombStateMachineStorage.STARTING_TIMER;

        public enum CurrentState { none, spawning, exploding };
        public CurrentState currentState { get; set; } = CurrentState.none;

        public BombStateMachine(Bomb bomb)
        {
            this.bomb = bomb;
            projectileSpriteFactory = bomb.projectileSpriteFactory;
            projectileHandler = bomb.projectileHandler;
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                projectileSpriteFactory.BombPlaced(bomb);
            }
        }

        public void Exploding()
        {
            if (currentState != CurrentState.exploding)
            {
                currentState = CurrentState.exploding;
                projectileSpriteFactory.BombExploding(bomb);
                bomb.exploding = true;

                bomb.collisionRectangle.X = (int)(bomb.drawLocation.X - (bomb.spriteSize.X * bomb.spriteScalar / BombStateMachineStorage.OFFSET));
                bomb.collisionRectangle.Y = (int)(bomb.drawLocation.Y - (bomb.spriteSize.Y * bomb.spriteScalar / BombStateMachineStorage.OFFSET));
                bomb.collisionRectangle.Width = (int)(bomb.spriteSize.X * bomb.spriteScalar * BombStateMachineStorage.OFFSET);
                bomb.collisionRectangle.Height = (int)(bomb.spriteSize.Y * bomb.spriteScalar * BombStateMachineStorage.OFFSET);
                bomb.game.collisionManager.collisionEntities[bomb] = bomb.CollisionRectangle();
                bomb.game.sounds["bombBlow"].CreateInstance().Play();
            }
            if (currentState == CurrentState.exploding && timer == BombStateMachineStorage.TIMER_TRIGGER)
            {
                bomb.game.collisionManager.collisionEntities.Remove(bomb);
            }
        }

        public void Update()
        {
            if (timer <= BombStateMachineStorage.ZERO && fuse)
            {
                fuse = false;
                timer = BombStateMachineStorage.TIMER_RESET;
            }
            else if (timer <= BombStateMachineStorage.ZERO && !fuse)
            {
                projectileHandler.Remove(bomb);
            }
            else
            {
                timer--;
            }

            if (fuse)
            {
                Spawning();
            }
            else
            {
                Exploding();
            }
        }
    }
}
