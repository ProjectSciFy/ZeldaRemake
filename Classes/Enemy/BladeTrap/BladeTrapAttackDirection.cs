using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy
{
    public class BladeTrapAttackDirection : ICommand
    {
        private Link link;
        private EnemyBladeTrap BladeTrap;
        private BladeTrapStateMachine state;
        private float speed;
        public BladeTrapAttackDirection(Link link, EnemyBladeTrap bladetrap, BladeTrapStateMachine state, float speed)
        {
            this.link = link;
            this.BladeTrap = bladetrap;
            this.state = state;
            this.speed = speed;
        }

        public void Execute()
        {
            switch (state.direction)
            {
                case BladeTrapStateMachine.Direction.down:
                    if (state.currentState != BladeTrapStateMachine.CurrentState.attackingDown)
                    {
                        state.currentState = BladeTrapStateMachine.CurrentState.attackingDown;
                        this.BladeTrap.velocity.X = 0;
                        this.BladeTrap.velocity.Y = speed;
                        this.BladeTrap.mySprite = state.spriteFactory.BladeTrapDown();
                    }
                    break;
                case BladeTrapStateMachine.Direction.up:
                    if (state.currentState != BladeTrapStateMachine.CurrentState.attackingUp)
                    {
                        state.currentState = BladeTrapStateMachine.CurrentState.attackingUp;
                        this.BladeTrap.velocity.X = 0;
                        this.BladeTrap.velocity.Y = -speed;
                        this.BladeTrap.mySprite = state.spriteFactory.BladeTrapUp();
                    }
                    break;
                case BladeTrapStateMachine.Direction.right:
                    if (state.currentState != BladeTrapStateMachine.CurrentState.attackingRight)
                    {
                        state.currentState = BladeTrapStateMachine.CurrentState.attackingRight;
                        this.BladeTrap.velocity.X = speed;
                        this.BladeTrap.velocity.Y = 0;
                        this.BladeTrap.mySprite = state.spriteFactory.BladeTrapRight();
                    }
                    break;
                case BladeTrapStateMachine.Direction.left:
                    if (state.currentState != BladeTrapStateMachine.CurrentState.attackingLeft)
                    {
                        state.currentState = BladeTrapStateMachine.CurrentState.attackingLeft;
                        this.BladeTrap.velocity.X = -speed;
                        this.BladeTrap.velocity.Y = 0;
                        this.BladeTrap.mySprite = state.spriteFactory.BladeTrapLeft();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
