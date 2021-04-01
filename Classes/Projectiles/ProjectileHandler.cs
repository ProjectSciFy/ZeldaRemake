using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class ProjectileHandler
    {
        public HashSet<IProjectile> projectileSet = new HashSet<IProjectile>();
        public HashSet<IProjectile> differenceSet = new HashSet<IProjectile>();
        private ZeldaGame game;

        public ProjectileHandler(ZeldaGame game)
        {
            this.game = game;
        }

        public void Add(IProjectile projectile)
        {
            projectileSet.Add(projectile);
        }

        public void Remove(IProjectile projectile)
        {
            differenceSet.Add(projectile);
        }
        public void Clear()
        {
            projectileSet.Clear();
        }
        public void Update()
        {
            foreach (IProjectile projectile in projectileSet)
            {
                projectile.Update();
            }

            foreach (IProjectile projectile in differenceSet)
            {
                if (projectileSet.Contains(projectile))
                {
                    projectileSet.Remove(projectile);
                }
            }

            differenceSet.Clear();
        }

        public void Draw()
        {
            foreach (IProjectile projectile in projectileSet)
            {
                projectile.Draw();
            }
        }
    }
}
