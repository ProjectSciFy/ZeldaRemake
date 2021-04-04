using CSE3902_Game_Sprint0.Classes._21._2._13;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Goriya.Scripts
{
    public class GoriyaIdle : ICommand
    {
        private EnemyGoriya goriya;
        private GoriyaSpriteFactory enemySpriteFactory;
        private GoriyaStateMachine GoriyaStateMachine;
        public GoriyaIdle(EnemyGoriya goriya, GoriyaSpriteFactory enemySpriteFactory, GoriyaStateMachine GoriyaStateMachine)
        {
            this.goriya = goriya;
            this.enemySpriteFactory = enemySpriteFactory;
            this.GoriyaStateMachine = GoriyaStateMachine;
        }
        public void Execute()
        {
            switch (GoriyaStateMachine.direction)
            {
                case GoriyaStateMachine.Direction.right:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.idleRight)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.idleRight;
                        goriya.velocity.X = 0;
                        goriya.velocity.Y = 0;
                        goriya.mySprite = enemySpriteFactory.GoriyaIdleRight();
                    }
                    break;

                case GoriyaStateMachine.Direction.up:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.idleUp)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.idleUp;
                        goriya.velocity.X = 0;
                        goriya.velocity.Y = 0;
                        goriya.mySprite = enemySpriteFactory.GoriyaIdleUp();
                    }
                    break;

                case GoriyaStateMachine.Direction.left:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.idleLeft)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.idleLeft;
                        goriya.velocity.X = 0;
                        goriya.velocity.Y = 0;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaIdleLeft();
                    }
                    break;

                case GoriyaStateMachine.Direction.down:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.idleDown)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.idleDown;
                        goriya.velocity.X = 0;
                        goriya.velocity.Y = 0;
                        goriya.mySprite = enemySpriteFactory.GoriyaIdleDown();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}