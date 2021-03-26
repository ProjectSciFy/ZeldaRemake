using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class ProjectileOnEnemy : ICommand
    {
        private IEnemy enemy;
        private IProjectile projectile;
        private Collision.Collision.Direction direction;
        private int ArrowDamage = 1;

        public ProjectileOnEnemy(IProjectile projectile, IEnemy enemy, Collision.Collision.Direction direction)
        {
            this.enemy = enemy;
            this.projectile = projectile;
            this.direction = direction;
        }

        public void Execute()
        {
            if (projectile is Arrow)
            {
                if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(ArrowDamage);
                    ((Arrow)projectile).myState.hit = true;
                }
            }
        }
    }
}
