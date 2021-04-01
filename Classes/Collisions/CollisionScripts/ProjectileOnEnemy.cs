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
        private int arrowDamage = 1;
        private int bombDamage = 3;

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
                    ((EnemyAquamentus)enemy).TakeDamage(arrowDamage);
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(arrowDamage);
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(arrowDamage);
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(arrowDamage);
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(arrowDamage);
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(arrowDamage);
                }

                ((Arrow)projectile).myState.hit = true;
            }
            else if (projectile is Bomb)
            {
                if (enemy is EnemyAquamentus)
                {
                    ((EnemyAquamentus)enemy).TakeDamage(bombDamage);
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(bombDamage);
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(bombDamage);
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(bombDamage);
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(bombDamage);
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(bombDamage);
                }
            }
            else if (projectile is LinkBoomerangProjectile)
            {
                if (enemy is EnemyAquamentus)
                {
                    ((EnemyAquamentus)enemy).TakeDamage(arrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(arrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(arrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(arrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(arrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(arrowDamage);
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
            }
        }
    }
}
