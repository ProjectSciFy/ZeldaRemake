using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{
    public class EnemyAquamentus : IEnemy
    {
        public ZeldaGame game;
        private AquamentusStateMachine myState;
        public AquamentusSpriteFactory enemySpriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public Fireball fireball_1, fireball_2, fireball_3;
        public int timer = 0;

        public EnemyAquamentus(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.enemySpriteFactory = new AquamentusSpriteFactory(game);
            drawLocation = spawnLocation;
            myState = new AquamentusStateMachine(this);
            game.collisionManager.enemies.Add(this, collisionRectangle);
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }
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

            if (timer <= 0)
            {
                timer = 200;
                fireball_1 = new Fireball(game, this, myState, new Vector2(-1, 0));
                fireball_2 = new Fireball(game, this, myState, new Vector2(-1, (float)0.15));
                fireball_3 = new Fireball(game, this, myState, new Vector2(-1, (float)-0.15));
            }

            fireball_1.Update();
            fireball_2.Update();
            fireball_3.Update();

            collisionRectangle.X = (int)drawLocation.X;
            collisionRectangle.Y = (int)drawLocation.Y;
            collisionRectangle.Width = (int)spriteSize.X;
            collisionRectangle.Height = (int)spriteSize.Y;

            game.collisionManager.enemies[this] = collisionRectangle;
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
            fireball_1.Draw();
            fireball_2.Draw();
            fireball_3.Draw();
        }
    }
}
