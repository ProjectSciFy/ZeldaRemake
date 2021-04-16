using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class ProjectileOnLittleHelper : ICommand
    {
        private LittleHelper.LittleHelper littleHelper { get; set; }
        private IProjectile projectile { get; set; }
        private Collision.Collision.Direction direction { get; set; }
        public ProjectileOnLittleHelper(IProjectile projectile, LittleHelper.LittleHelper littleHelper, Collision.Collision.Direction direction)
        {
            this.littleHelper = littleHelper;
            this.projectile = projectile;
            this.direction = direction;
        }

        public void Execute()
        {
            if (projectile is GoriyaBoomerang || projectile is Fireball)
            {
                if (projectile is Fireball)
                {
                    ((Fireball)projectile).collided = true;
                }
                else
                {
                    ((GoriyaBoomerang)projectile).myState.returning = true;
                }
                littleHelper.game.sounds["shield"].CreateInstance().Play();
            }
            else if (projectile is Arrow)
            {
                ((Arrow)projectile).myState.hit = true;
                littleHelper.game.sounds["shield"].CreateInstance().Play();
            }
            else if (projectile is LinkBoomerangProjectile)
            {
                ((LinkBoomerangProjectile)projectile).myState.returning = true;
                littleHelper.game.sounds["shield"].CreateInstance().Play();
            }
        }
    }
}
