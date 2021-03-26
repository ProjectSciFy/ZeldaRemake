using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class ArrowStateMachine
    {
        private Arrow arrow;
        private ProjectileSpriteFactory projectileSpriteFactory;
        public ProjectileHandler projectileHandler;
        public bool hit = false;

        private int timer = 180;
        public enum CurrentState { none, soaring, hitting };
        public CurrentState currentState = CurrentState.none;

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
                timer = 15;
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
