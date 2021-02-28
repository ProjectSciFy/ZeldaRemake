using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Boomerang : IProjectile
    {
        public EeveeSim game;
        public Link link = null;
        public LinkStateMachine linkState = null;
        public EnemyGoriya goriya = null;
        public GoriyaStateMachine goriyaState = null;
        public EnemySpriteFactory spriteFactory;
        public ISprite mySprite;
        public BoomerangStateMachine myState;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2 (0, 0);
        public bool newItem;
        public Vector2 trajectory = new Vector2(0, 0);
        //public enum Direction { right, up, left, down, NE, SE, SW, NW }; // NE = North East
        //public Direction direction = Direction.down;
        //private enum CurrentState {movingUp, movingDown, movingLeft, movingRight, movingNE, movingSE, movingSW, movingNW};
        //private CurrentState currentState = CurrentState.movingDown;
        //public Direction returnDirection;
        //public const int RANGE = 125;
        //public Boolean newItem = true;
        //public Boolean returning = false;

        public Boomerang(EeveeSim game, Link link, LinkStateMachine linkState)
        {
            this.game = game;
            this.link = link;
            this.linkState = linkState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = link.drawLocation;
            this.spawnLocation = link.drawLocation;
            this.myState = new BoomerangStateMachine(this);
        }

        public Boomerang(EeveeSim game, EnemyGoriya goriya, GoriyaStateMachine goriyaState)
        {
            this.game = game;
            this.goriya = goriya;
            this.goriyaState = goriyaState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = goriya.drawLocation;
            this.spawnLocation = goriya.drawLocation;
            this.myState = new BoomerangStateMachine(this);
        }
        public void Update()
        {
            myState.Update();
            mySprite.Update();
            if (linkState == null)
            {
                goriyaState.Update();
            }
            else
            {
                linkState.Update();
            }
            myState.Update();
            //Update position of boomerang
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

            // Logic for trajectory
            
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }

    }
}
