using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class BladeTrapStateMachine
    {
        private EeveeSim game;
        private EnemyBladeTrap BladeTrap;
        private EnemySpriteFactory spriteFactory;
        private Boolean InRange;
        private int Range;
        public BladeTrapStateMachine(IEnemy enemy)
        {
            this.game = BladeTrap.game;
            this.BladeTrap = (EnemyBladeTrap) enemy;
            spriteFactory = new EnemySpriteFactory(this.game);
            // spriteFactory.Idle(); //needs sprite factory method
        }

        public void Idle()
        {
            //spriteFactory.BladeTrapIdle();
        }
        public void Update()
        {

        }
    }
}
