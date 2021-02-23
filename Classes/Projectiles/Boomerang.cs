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
    public class Boomerang : ISecondaryEntity
    {
        public EeveeSim game;
        public Link link = null;
        public LinkStateMachine linkState = null;
        public EnemyGoriya goriya = null;
        public GoriyaStateMachine goriyaState = null;
        public EnemySpriteFactory spriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        //public Vector2 recieveLocation; // where link is at point of return
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public enum Direction { right, up, left, down, NE, SE, SW, NW }; // NE = North East
        public Direction direction = Direction.down;
        private enum CurrentState {movingUp, movingDown, movingLeft, movingRight, movingNE, movingSE, movingSW, movingNW};
        private CurrentState currentState = CurrentState.movingDown;
        public Direction returnDirection;
        public const int RANGE = 125;
        public Boolean newItem = true;
        public Boolean returning = false;

        public Boomerang(EeveeSim game, Link link, LinkStateMachine linkState)
        {
            this.game = game;
            this.link = link;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = link.drawLocation;
            this.spawnLocation = link.drawLocation;
            this.linkState = linkState;
            this.direction = (Direction)linkState.direction;
        }

        public Boomerang(EeveeSim game, EnemyGoriya goriya, GoriyaStateMachine goriyaState)
        {
            this.game = game;
            this.goriya = goriya;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = goriya.drawLocation;
            this.spawnLocation = goriya.drawLocation;
            this.goriyaState = goriyaState;
            this.direction = (Direction)goriyaState.direction;
        }
        public void Outward()
        {
            switch (direction)
            {
                case Direction.down:
                    spriteFactory.BoomerangDown(this);
                    returnDirection = direction;
                    break;
                case Direction.up:
                    spriteFactory.BoomerangUp(this);
                    returnDirection = direction;
                    break;
                case Direction.right:
                    spriteFactory.BoomerangRight(this);
                    returnDirection = direction;
                    break;
                case Direction.left:
                    spriteFactory.BoomerangLeft(this);
                    returnDirection = direction;
                    break;
                default:
                    break;
            }
        }
        public void Inward()
        {
            switch (returnDirection)
            {
                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        spriteFactory.BoomerangDown(this);
                    }
                    break;
                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        spriteFactory.BoomerangUp(this);
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        spriteFactory.BoomerangRight(this);
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        spriteFactory.BoomerangLeft(this);
                    }
                    break;
                case Direction.NE:
                    if (currentState != CurrentState.movingNE)
                    {
                        currentState = CurrentState.movingNE;
                        spriteFactory.BoomerangNE(this);
                    }
                    break;
                case Direction.SE:
                    if (currentState != CurrentState.movingSE)
                    {
                        currentState = CurrentState.movingSE;
                        spriteFactory.BoomerangSE(this);
                    }
                    break;
                case Direction.SW:
                    if (currentState != CurrentState.movingSW)
                    {
                        currentState = CurrentState.movingSW;
                        spriteFactory.BoomerangSW(this);
                    }
                    break;
                case Direction.NW:
                    if (currentState != CurrentState.movingNW)
                    {
                        currentState = CurrentState.movingNW;
                        spriteFactory.BoomerangNW(this);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            if (newItem)
            {
                spriteFactory.BoomerangUp(this);
            }
            mySprite.Update();
            if (linkState == null)
            {
                goriyaState.Update();
                direction = (Direction)goriyaState.direction;
            }
            else
            {
                linkState.Update();
                direction = (Direction)linkState.direction;
            }
            //Update position of boomerang
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

            // Logic for trajectory
            if ((Math.Abs(drawLocation.X - spawnLocation.X) < RANGE && newItem == true) || (Math.Abs(drawLocation.Y - spawnLocation.Y) < RANGE && newItem == true))
            {
                newItem = false;
                Outward();
            }
            else if ((Math.Abs(drawLocation.X - spawnLocation.X) > RANGE && returning == false) || (Math.Abs(drawLocation.Y - spawnLocation.Y) > RANGE && returning == false))
            {
                returning = true;
                Inward();
            }
            else if (newItem == false && returning == true && !(drawLocation == spawnLocation))
            {
                if (linkState == null)
                {
                    if (drawLocation.X > goriya.drawLocation.X && drawLocation.Y > goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.NW;
                    }
                    else if(drawLocation.X > goriya.drawLocation.X && drawLocation.Y < goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.SW;
                    }
                    else if (drawLocation.X < goriya.drawLocation.X && drawLocation.Y < goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.SE;
                    }
                    else if (drawLocation.X < goriya.drawLocation.X && drawLocation.Y > goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.NE;
                    }
                    else if (drawLocation.X == goriya.drawLocation.X && drawLocation.Y > goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.up;
                    }
                    else if (drawLocation.X == goriya.drawLocation.X && drawLocation.Y < goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.down;
                    }
                    else if (drawLocation.X < goriya.drawLocation.X && drawLocation.Y == goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.right;
                    }
                    else if (drawLocation.X > goriya.drawLocation.X && drawLocation.Y == goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.left;
                    }
                }
                else
                {
                    if (drawLocation.X > link.drawLocation.X && drawLocation.Y > link.drawLocation.Y)
                    {
                        returnDirection = Direction.NW;
                    }
                    else if (drawLocation.X > link.drawLocation.X && drawLocation.Y < link.drawLocation.Y)
                    {
                        returnDirection = Direction.SW;
                    }
                    else if (drawLocation.X < link.drawLocation.X && drawLocation.Y < link.drawLocation.Y)
                    {
                        returnDirection = Direction.SE;
                    }
                    else if (drawLocation.X < link.drawLocation.X && drawLocation.Y > link.drawLocation.Y)
                    {
                        returnDirection = Direction.NE;
                    }
                }
                Inward();
            }
            else
            {
                //despawn boomerang somehow
            }
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }

    }
}
