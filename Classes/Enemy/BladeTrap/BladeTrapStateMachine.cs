using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.BladeTrap;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class BladeTrapStateMachine
    {
        private ZeldaGame game;
        private EnemyBladeTrap BladeTrap;
        public BladeTrapSpriteFactory spriteFactory;
        private Link link;
        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        public Boolean attacking = false, nested = true, returning = false, pivot = false;
        public enum CurrentState { idle, attackingUp, attackingDown, attackingRight, attackingLeft, retractingUp, retractingDown, retractingRight, retractingLeft };
        public CurrentState currentState = CurrentState.idle;
        public const int TRAP_WIDTH = 16;
        private const float attackVelocity = (float)3.0;
        private const float returnVelocity = (float)1.5;
        public BladeTrapStateMachine(EnemyBladeTrap enemy, Link link)
        {
            this.BladeTrap = enemy;
            this.game = BladeTrap.game;
            this.link = link;
            spriteFactory = new BladeTrapSpriteFactory(this.game);
            this.BladeTrap.mySprite = spriteFactory.BladeTrapIdle();
        }

        public void Idle()
        {
            if (currentState != CurrentState.idle)
            {
                currentState = CurrentState.idle;
                this.BladeTrap.velocity = new Vector2(0, 0);
                this.BladeTrap.mySprite = spriteFactory.BladeTrapIdle();
            }
         }
        public void Attack()
        {
            new BladeTrapAttackDirection(link, BladeTrap, this, attackVelocity).Execute();
        }
        public void Retract()
        {
            new BladeTrapAttackDirection(link, BladeTrap, this, returnVelocity).Execute();
        }
        public void Update()
        {
            new BladeTrapTrajectoryCalc(link, BladeTrap, this).Execute();
            if (nested)
            {
                Idle();
            }
            else if (attacking && !returning)
            {
                Attack();
            }
            else if (returning)
            {
                Retract();
            }
        }
    }
}
