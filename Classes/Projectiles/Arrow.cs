using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Arrow : IProjectile
    {
        public ProjectileSpriteFactory projectileSpriteFactory;
        public ProjectileHandler projectileHandler;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 velocity;
        public Vector2 spriteSize;
        public enum Direction { up, down, left, right};
        public Direction direction;
        private ArrowStateMachine myState;

        public Arrow(ZeldaGame game, Vector2 drawLocation, ProjectileHandler projectileHandler, Direction direction)
        {
            this.projectileSpriteFactory = game.projectileSpriteFactory;
            this.drawLocation = drawLocation;
            this.projectileHandler = projectileHandler;
            this.direction = direction;
            myState = new ArrowStateMachine(this);
        }
       
        public void Update()
        {
            myState.Update();
            mySprite.Update();

            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
