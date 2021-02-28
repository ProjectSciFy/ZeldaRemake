using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Bomb : IProjectile
    {
        public ProjectileSpriteFactory projectileSpriteFactory;
        public ProjectileHandler projectileHandler;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 spriteSize;
        private BombStateMachine myState;
        public bool exploding = false;
        private int explosionTimer = 6;
        private bool explosionMirror = false;

        public Bomb(EeveeSim game, Vector2 drawLocation, ProjectileHandler projectileHandler)
        {
            this.projectileSpriteFactory = game.projectileSpriteFactory;
            this.drawLocation = drawLocation;
            this.projectileHandler = projectileHandler;
            myState = new BombStateMachine(this);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();
        }

        public void Draw()
        {
            if (!exploding)
            {
                mySprite.Draw(drawLocation);
            }
            else
            {
                if (explosionMirror)
                {
                    mySprite.Draw(new Vector2(drawLocation.X - 8, drawLocation.Y - 16));
                    mySprite.Draw(new Vector2(drawLocation.X + 16, drawLocation.Y));
                    mySprite.Draw(drawLocation);
                    mySprite.Draw(new Vector2(drawLocation.X + 8, drawLocation.Y + 16));
                }
                else
                {
                    mySprite.Draw(new Vector2(drawLocation.X + 8, drawLocation.Y - 16));
                    mySprite.Draw(new Vector2(drawLocation.X - 16, drawLocation.Y));
                    mySprite.Draw(drawLocation);
                    mySprite.Draw(new Vector2(drawLocation.X - 8, drawLocation.Y + 16));
                }

                if (explosionTimer <= 0)
                {
                    explosionMirror = !explosionMirror;
                    explosionTimer = 6;
                }
                else
                {
                    explosionTimer--;
                }
            }
        }
    }
}
