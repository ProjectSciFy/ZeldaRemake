using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Roshi;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class SpiritBombStateMachine
    {
        public SpiritBomb spiritBomb { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        public bool fire { get; set; } = false;
        public bool charging { get; set; } = true;
        public bool explode { get; set; } = true;

        public SpiritBombStateMachine(SpiritBomb spiritBomb)
        {
            this.spiritBomb = spiritBomb;
            this.spriteFactory = spiritBomb.spriteFactory;
        }
        public void Charge()
        {
            spiritBomb.mySprite =  spriteFactory.SpiritBombCharge();
        }
        public void Attack()
        {
            spiritBomb.velocity = new Vector2(2, 1);
            spiritBomb.mySprite = spriteFactory.SpiritBombProjectile();
        }
        public void Explode()
        {
            spiritBomb.velocity = Vector2.Zero;
            spiritBomb.mySprite = spriteFactory.Explosion();
        }
        public void Update()
        {
            if (charging)
            {
                Charge();
            }
            else if (fire)
            {
                Attack();
            }
            else if (explode)
            {
                Explode();
            }
        }
    }
}
