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

        public int timer = 90;

        public enum CurrentState { none, spawning, exploding };
        public CurrentState currentState = CurrentState.none;

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

                bomb.collisionRectangle.X = (int)(bomb.drawLocation.X - (bomb.spriteSize.X * bomb.spriteScalar / 2));
                bomb.collisionRectangle.Y = (int)(bomb.drawLocation.Y - (bomb.spriteSize.Y * bomb.spriteScalar / 2));
                bomb.collisionRectangle.Width = (int)(bomb.spriteSize.X * bomb.spriteScalar * 2);
                bomb.collisionRectangle.Height = (int)(bomb.spriteSize.Y * bomb.spriteScalar * 2);
                bomb.game.collisionManager.collisionEntities[bomb] = bomb.CollisionRectangle();
            }
            if (currentState == CurrentState.exploding && timer == 29)
            {
                bomb.game.collisionManager.collisionEntities.Remove(bomb);
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
