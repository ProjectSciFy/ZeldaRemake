using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Roshi;
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
        private IEnemy enemy { get; set; }
        private IProjectile projectile { get; set; }
        private Collision.Collision.Direction direction { get; set; }
        private int arrowDamage { get; set; } = 1;
        private int bombDamage { get; set; } = 3;

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
                    ((EnemyAquamentus)enemy).TakeDamage(arrowDamage + (((EnemyAquamentus)enemy).game.util.numXP / ((EnemyAquamentus)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(arrowDamage + (((EnemySlime)enemy).game.util.numXP / ((EnemySlime)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(arrowDamage + (((EnemyGoriya)enemy).game.util.numXP / ((EnemyGoriya)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(arrowDamage + (((EnemyKeese)enemy).game.util.numXP / ((EnemyKeese)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(arrowDamage + (((EnemyStalfos)enemy).game.util.numXP / ((EnemyStalfos)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(arrowDamage + (((EnemyWallmaster)enemy).game.util.numXP / ((EnemyWallmaster)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyRoshi)
                {
                    ((EnemyRoshi)enemy).TakeDamage(arrowDamage + (((EnemyRoshi)enemy).game.util.numXP / ((EnemyRoshi)enemy).game.util.XPPerLevel));
                }

                ((Arrow)projectile).myState.hit = true;
            }
            else if (projectile is Bomb)
            {
                if (enemy is EnemyAquamentus)
                {
                    ((EnemyAquamentus)enemy).TakeDamage(bombDamage + (((EnemyAquamentus)enemy).game.util.numXP / ((EnemyAquamentus)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(bombDamage + (((EnemySlime)enemy).game.util.numXP / ((EnemySlime)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(bombDamage + (((EnemyGoriya)enemy).game.util.numXP / ((EnemyGoriya)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(bombDamage + (((EnemyKeese)enemy).game.util.numXP / ((EnemyKeese)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(bombDamage + (((EnemyStalfos)enemy).game.util.numXP / ((EnemyStalfos)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(bombDamage + (((EnemyWallmaster)enemy).game.util.numXP / ((EnemyWallmaster)enemy).game.util.XPPerLevel));
                }
                else if (enemy is EnemyRoshi)
                {
                    ((EnemyRoshi)enemy).TakeDamage(bombDamage + (((EnemyRoshi)enemy).game.util.numXP / ((EnemyRoshi)enemy).game.util.XPPerLevel));
                }
            }
            else if (projectile is LinkBoomerangProjectile)
            {
                if (enemy is EnemyAquamentus)
                {
                    ((EnemyAquamentus)enemy).TakeDamage(arrowDamage + (((EnemyAquamentus)enemy).game.util.numXP / ((EnemyAquamentus)enemy).game.util.XPPerLevel));
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemySlime)
                {
                    ((EnemySlime)enemy).TakeDamage(arrowDamage + (((EnemySlime)enemy).game.util.numXP / ((EnemySlime)enemy).game.util.XPPerLevel));
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyGoriya)
                {
                    ((EnemyGoriya)enemy).TakeDamage(arrowDamage + (((EnemyGoriya)enemy).game.util.numXP / ((EnemyGoriya)enemy).game.util.XPPerLevel));
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyKeese)
                {
                    ((EnemyKeese)enemy).TakeDamage(arrowDamage + (((EnemyKeese)enemy).game.util.numXP / ((EnemyKeese)enemy).game.util.XPPerLevel));
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyStalfos)
                {
                    ((EnemyStalfos)enemy).TakeDamage(arrowDamage + (((EnemyStalfos)enemy).game.util.numXP / ((EnemyStalfos)enemy).game.util.XPPerLevel));
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyWallmaster)
                {
                    ((EnemyWallmaster)enemy).TakeDamage(arrowDamage + (((EnemyWallmaster)enemy).game.util.numXP / ((EnemyWallmaster)enemy).game.util.XPPerLevel));
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
                else if (enemy is EnemyRoshi)
                {
                    ((EnemyRoshi)enemy).TakeDamage(arrowDamage + (((EnemyRoshi)enemy).game.util.numXP / ((EnemyRoshi)enemy).game.util.XPPerLevel));
                    ((LinkBoomerangProjectile)projectile).myState.returning = true;
                }
            }
            else if (projectile is GoriyaBoomerang)
            {
                if (enemy is EnemyGoriya && ((GoriyaBoomerang)projectile).myState.returning)
                {
                    ((EnemyGoriya)enemy).throwing = false;
                    ((GoriyaBoomerang)projectile).collided = true;
                }
            }
        }
    }
}
