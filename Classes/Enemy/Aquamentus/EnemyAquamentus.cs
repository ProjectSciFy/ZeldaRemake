using CSE3902_Game_Sprint0.Classes._21._2._13;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{
    public class EnemyAquamentus : IEnemy
    {
        public EeveeSim game;
        private AquamentusStateMachine myState;
        public EnemySpriteFactory enemySpriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);

        public EnemyAquamentus(EeveeSim game, Vector2 spawnLocation)
        {
            this.game = game;
            this.enemySpriteFactory = game.enemySpriteFactory;
            drawLocation = spawnLocation;
            myState = new AquamentusStateMachine(this);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();

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
        }
    }
}
