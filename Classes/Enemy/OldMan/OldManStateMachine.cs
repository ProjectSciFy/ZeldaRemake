using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.OldMan.OldManScripts;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.OldMan
{
    public class OldManStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyOldMan oldMan;
        private OldManSpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = false;
        private int timer = 0;
        public enum CurrentState { none, idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight };
        public CurrentState currentState = CurrentState.none;

        public OldManStateMachine(EnemyOldMan oldMan)
        {
            this.game = oldMan.game;
            this.oldMan = oldMan;
            enemySpriteFactory = new OldManSpriteFactory(game);
        }
        public void Idle()
        {
            if (timer <= 0)
            {
                timer = 60;
                new OldManIdle(oldMan, enemySpriteFactory, this).Execute();
            }
        }

        public void Moving()
        {

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
