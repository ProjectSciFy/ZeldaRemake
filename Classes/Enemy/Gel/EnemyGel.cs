using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Gel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy
{
    public class EnemyGel : IEnemy
    {
        public ZeldaGame game;
        private GelStateMachine myState;
        public GelSpriteFactory enemySpriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(8, 16);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);

        public EnemyGel(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.enemySpriteFactory = new GelSpriteFactory(game);
            drawLocation = spawnLocation;
            myState = new GelStateMachine(this);
            game.collisionManager.enemies.Add(this, collisionRectangle);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();

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

            collisionRectangle.X = (int)drawLocation.X;
            collisionRectangle.Y = (int)drawLocation.Y;
            collisionRectangle.Width = (int)spriteSize.X;
            collisionRectangle.Height = (int)spriteSize.Y;

            game.collisionManager.enemies[this] = collisionRectangle;
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
