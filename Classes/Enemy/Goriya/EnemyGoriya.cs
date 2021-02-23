using CSE3902_Game_Sprint0.Classes.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemyGoriya : IEnemy
    {
        //When defeated, can drop a heart, rupee, 5rupee or a clock
        //Pathing is random, no sense of direction
        //Method of attack is melee, bumping into the player

        public EeveeSim game;
        private GoriyaStateMachine myState;
        public EnemySpriteFactory enemySpriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Boomerang boomerang;

        public EnemyGoriya(EeveeSim game, Vector2 spawnLocation)
        {
            this.game = game;
            this.enemySpriteFactory = game.enemySpriteFactory;
            drawLocation = spawnLocation;
            myState = new GoriyaStateMachine(this);
            boomerang = new Boomerang(game, this, myState);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update(); 
            if (!myState.moving)
            {
                boomerang.Update();
            }

            //Update the position of Link here
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;

            if (drawLocation.X >= game.GraphicsDevice.Viewport.Bounds.Width && velocity.X > 0)
            {
                drawLocation.X = 0 - spriteSize.X;
            }
            else if (drawLocation.X + spriteSize.X <= 0 && velocity.X < 0)
            {
                drawLocation.X = game.GraphicsDevice.Viewport.Bounds.Width;
            }

            if (drawLocation.Y >= game.GraphicsDevice.Viewport.Bounds.Height && velocity.Y > 0)
            {
                drawLocation.Y = 0 - spriteSize.Y;
            }
            else if (drawLocation.Y + spriteSize.Y <= 0 && velocity.Y < 0)
            {
                drawLocation.Y = game.GraphicsDevice.Viewport.Bounds.Height;
            }
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
            if (!myState.moving)
            {
                boomerang.Draw();
            }
        }
    }
}
