using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class BombStateMachine : IProjectileStateMachine
    {
        private Bomb bomb;
        private ProjectileSpriteFactory projectileSpriteFactory;
        public ProjectileHandler projectileHandler;
        public bool fuse = true;

        private int timer = 90;

        private enum CurrentState { none, spawning, exploding };
        private CurrentState currentState = CurrentState.none;

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
            }
        }

        public void Update()
        {
            if (timer <= 0 && fuse)
            {
                fuse = false;
                timer = 30;
            }
            else if (timer <= 0 && !fuse)
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
