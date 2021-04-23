using CSE3902_Game_Sprint0.Classes._21._2._13;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class FireballStateMachine
    {
        public Fireball fireball { get; set; }
        private EnemySpriteFactory enemySpriteFactory { get; set; }
        private enum Direction { right, left };
        private bool fired { get; set; } = false;

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
            if (!fired)
            {
                Attack();
                fired = true;
            }
        }
    }
}
