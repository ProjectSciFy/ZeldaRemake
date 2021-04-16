using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class ProjectileOnLink : ICommand
    {
        private Link link { get; set; }
        private IProjectile projectile { get; set; }
        private Collision.Collision.Direction direction { get; set; }

        public ProjectileOnLink(IProjectile projectile, Link link, Collision.Collision.Direction direction)
        {
            this.link = link;
            this.projectile = projectile;
            this.direction = direction;
        }

        public void Execute()
        {
            if (projectile is Bomb)
            {
                if (link.linkState.timer <= 0)
                {
                    link.linkState.isDamaged = true;
                }
            }
            else if (projectile is GoriyaBoomerang || projectile is Fireball)
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
            else if (projectile is Arrow)
            {
                if (link.linkState.timer <= 0)
                {
                    link.linkState.isDamaged = true;
                    ((Arrow)projectile).myState.hit = true;
                }
            }
            if (projectile is LinkBoomerangProjectile && ((LinkBoomerangProjectile)projectile).myState.returning)
            {
                ((LinkBoomerangProjectile)projectile).collided = true;
                link.linkState.boomerangCaught = true;
            }
        }
    }
}
