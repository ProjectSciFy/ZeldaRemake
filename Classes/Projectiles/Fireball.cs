using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Fireball : ISecondaryEntity
    {
        public EeveeSim game;
        public EnemyAquamentus aquamentus;
        public AquamentusStateMachine aquamentusState;
        public EnemySpriteFactory spriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Vector2 trajectory;
        public bool newItem = true;
        
        public Fireball(EeveeSim game, EnemyAquamentus aquamentus, AquamentusStateMachine aquamentusState, Vector2 trajectory)
        {
            this.game = game;
            this.aquamentus = aquamentus;
            this.aquamentusState = aquamentusState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = aquamentus.drawLocation;
            this.spawnLocation = aquamentus.drawLocation;
            this.trajectory = trajectory;
        }
        public void Update()
        {
            if (newItem)
            {
                newItem = false;
                spriteFactory.FireballAttack(this);
            }
            aquamentusState.Update();
            mySprite.Update();

            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;

            //if (drawLocation.X >= game.GraphicsDevice.Viewport.Bounds.Width && velocity.X > 0)
            //{
            //    drawLocation.X = 0 - spriteSize.X;
            //}
            //else if (drawLocation.X + spriteSize.X <= 0 && velocity.X < 0)
            //{
            //    drawLocation.X = game.GraphicsDevice.Viewport.Bounds.Width;
            //}

            //if (drawLocation.Y >= game.GraphicsDevice.Viewport.Bounds.Height && velocity.Y > 0)
            //{
            //    drawLocation.Y = 0 - spriteSize.Y;
            //}
            //else if (drawLocation.Y + spriteSize.Y <= 0 && velocity.Y < 0)
            //{
            //    drawLocation.Y = game.GraphicsDevice.Viewport.Bounds.Height;
            //}
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
