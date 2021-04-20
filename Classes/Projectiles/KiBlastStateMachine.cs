using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class KiBlastStateMachine
    {
        public KiBlast kiBlast { get; set; }
        private EnemySpriteFactory enemySpriteFactory { get; set; }
        private bool fired { get; set; } = false;

        public KiBlastStateMachine(KiBlast kiBlast)
        {
            this.kiBlast = kiBlast;
            this.enemySpriteFactory = kiBlast.spriteFactory;
        }

        public void Attack()
        {
            enemySpriteFactory.KiBlastAttack(kiBlast);
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
