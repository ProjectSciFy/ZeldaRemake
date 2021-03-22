using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class ProjectileOnLink : ICommand
    {
        private Link link;
        private IProjectile projectile;
        private Collision.Collision.Direction direction;

        public ProjectileOnLink(IProjectile projectile, Link link, Collision.Collision.Direction direction)
        {
            this.link = link;
            this.projectile = projectile;
            this.direction = direction;
        }

        public void Execute()
        {
            if (projectile is GoriyaBoomerang || projectile is Fireball)
            {
                if (link.linkState.timer <= 0)
                {
                    link.linkState.isDamaged = true;
                }
                if (projectile is Fireball)
                {
                    ((Fireball)projectile).collided = true;
                }
                else
                {
                    ((GoriyaBoomerang)projectile).myState.returning = true;
                }
            }
            if (projectile is LinkBoomerangProjectile)
            {
                ((LinkBoomerangProjectile)projectile).collided = true;
            }
        }
    }
}
