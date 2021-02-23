using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class BombStateMachine
    {
        private Bomb bomb;
        private ItemSpriteFactory spriteFactory;
        public bool fuse = true;

        private int timer = 90;

        private enum CurrentState { none, spawning, exploding };
        private CurrentState currentState = CurrentState.none;

        public BombStateMachine(Bomb bomb)
        {
            this.bomb = bomb;
            spriteFactory = bomb.spriteFactory;
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                spriteFactory.SpawnBomb(bomb);
            }

            if (timer <= 0)
            {
                fuse = false;
                currentState = CurrentState.none;
            }
        }

        public void Exploding()
        {
            if (currentState != CurrentState.exploding)
            {
                currentState = CurrentState.exploding;
                spriteFactory.ExplodeBomb(bomb);
            }
        }

        public void Update()
        {
            if (timer <= 0)
            {
                fuse = false;
                timer = 30;
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
