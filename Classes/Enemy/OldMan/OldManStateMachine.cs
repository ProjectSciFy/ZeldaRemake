﻿using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.OldMan
{
    public class OldManStateMachine : IEnemyStateMachine
    {
        private EnemyOldMan oldMan;
        private EnemySpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = false;
        private int timer = 0;
        private enum CurrentState { none, idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight };
        private CurrentState currentState = CurrentState.none;

        public OldManStateMachine(EnemyOldMan oldMan)
        {
            this.oldMan = oldMan;
            enemySpriteFactory = oldMan.enemySpriteFactory;
        }

        public void Idle()
        {
            if (currentState != CurrentState.idleDown)
            {
                currentState = CurrentState.idleDown;
                enemySpriteFactory.OldManIdle(oldMan);
            }
        }

        public void Moving()
        {
            //OldMen don't move :|
        }

        public void Update()
        {
            if (moving)
            {
                Moving();
            }
            else
            {
                Idle();
            }
        }
    }
}