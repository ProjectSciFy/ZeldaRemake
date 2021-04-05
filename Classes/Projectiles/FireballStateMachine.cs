using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class FireballStateMachine
    {
        public Fireball fireball;
        private EnemySpriteFactory enemySpriteFactory;
        private enum Direction { right, left };
        private Direction direction = Direction.left;
        private bool fired = false;

        public FireballStateMachine(Fireball fireball)
        {
            this.fireball = fireball;
            this.enemySpriteFactory = fireball.spriteFactory;
        }

        public void Attack()
        {
            enemySpriteFactory.FireballAttack(fireball);
        }
        public void Update()
        {
            if(!fired)
            {
                Attack();
                fired = true;
            }
        }
    }
}
