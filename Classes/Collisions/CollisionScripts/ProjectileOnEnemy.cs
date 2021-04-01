using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
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
                if (enemy is EnemyAquamentus)
                {
                    ((EnemyAquamentus)enemy).TakeDamage(ArrowDamage);
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(ArrowDamage);
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(ArrowDamage);
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(ArrowDamage);
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(ArrowDamage);
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(ArrowDamage);
                }

                ((Arrow)projectile).myState.hit = true;
            }
            if (projectile is LinkBoomerangProjectile)
            {
                if (enemy is EnemyAquamentus)
                {
                    ((EnemyAquamentus)enemy).TakeDamage(ArrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(ArrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(ArrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(ArrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(ArrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(ArrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
            }
        }
    }
}
