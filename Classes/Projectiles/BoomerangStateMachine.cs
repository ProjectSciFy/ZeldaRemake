using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class BoomerangStateMachine
    {
        public Boomerang boomerang;
        private EnemySpriteFactory spriteFactory;
        public enum Direction { right, up, left, down, NE, SE, SW, NW }; // NE = North East
        public Direction direction = Direction.down;
        private enum CurrentState { movingUp, movingDown, movingLeft, movingRight, movingNE, movingSE, movingSW, movingNW, none };
        private CurrentState currentState;
        public Direction returnDirection;
        public const int RANGE = 175;
        public const int RETURN_WINDOW = 30;
        public const int DESPAWN_DISTANCE = 5;
        public const float BASE_SPEED = (float)1.5, PIVOT_SPEED = (float) 1.0;
        public Boolean returning = false, newItem = true, brake = false;


        public BoomerangStateMachine(Boomerang boomerang)
        {
            this.boomerang = boomerang;
            this.spriteFactory = boomerang.spriteFactory;
        }
        public void Outward()
        {
            //switch (direction)
            //{
            //    case Direction.down:
            //        spriteFactory.BoomerangDown(boomerang);
            //        returnDirection = direction;
            //        break;
            //    case Direction.up:
            //        spriteFactory.BoomerangUp(boomerang);
            //        returnDirection = direction;
            //        break;
            //    case Direction.right:
            //        spriteFactory.BoomerangRight(boomerang);
            //        returnDirection = direction;
            //        break;
            //    case Direction.left:
            //        spriteFactory.BoomerangLeft(boomerang);
            //        returnDirection = direction;
            //        break;
            //    default:
            //        break;
            //}
            switch (direction)
            {
                case Direction.down:
                    boomerang.trajectory = new Vector2(0, BASE_SPEED);
                    spriteFactory.BoomerangAttack(boomerang);
                    break;
                case Direction.up:
                    boomerang.trajectory = new Vector2(0, -BASE_SPEED);
                    spriteFactory.BoomerangAttack(boomerang);
                    break;
                case Direction.right:
                    boomerang.trajectory = new Vector2(BASE_SPEED, 0);
                    spriteFactory.BoomerangAttack(boomerang);
                    break;
                case Direction.left:
                    boomerang.trajectory = new Vector2(-BASE_SPEED, 0);
                    spriteFactory.BoomerangAttack(boomerang);
                    break;
                default:
                    break;
            }
        }
        public void OutwardReturnWindow()
        {
            //switch (direction)
            //{
            //    case Direction.down:
            //        spriteFactory.BoomerangDown(boomerang);
            //        returnDirection = direction;
            //        break;
            //    case Direction.up:
            //        spriteFactory.BoomerangUp(boomerang);
            //        returnDirection = direction;
            //        break;
            //    case Direction.right:
            //        spriteFactory.BoomerangRight(boomerang);
            //        returnDirection = direction;
            //        break;
            //    case Direction.left:
            //        spriteFactory.BoomerangLeft(boomerang);
            //        returnDirection = direction;
            //        break;
            //    default:
            //        break;
            //}
            switch (direction)
            {
                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        boomerang.trajectory = new Vector2(0, PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        boomerang.trajectory = new Vector2(0, -PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        boomerang.trajectory = new Vector2(PIVOT_SPEED, 0);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        boomerang.trajectory = new Vector2(-PIVOT_SPEED, 0);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
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
                        boomerang.trajectory = new Vector2(0, BASE_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        boomerang.trajectory = new Vector2(0, -BASE_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        boomerang.trajectory = new Vector2(BASE_SPEED, 0);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        boomerang.trajectory = new Vector2(-BASE_SPEED, 0);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.NE:
                    if (currentState != CurrentState.movingNE)
                    {
                        currentState = CurrentState.movingNE;
                        boomerang.trajectory = new Vector2(BASE_SPEED, -BASE_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.SE:
                    if (currentState != CurrentState.movingSE)
                    {
                        currentState = CurrentState.movingSE;
                        boomerang.trajectory = new Vector2(BASE_SPEED, BASE_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.SW:
                    if (currentState != CurrentState.movingSW)
                    {
                        currentState = CurrentState.movingSW;
                        boomerang.trajectory = new Vector2(-BASE_SPEED, BASE_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.NW:
                    if (currentState != CurrentState.movingNW)
                    {
                        currentState = CurrentState.movingNW;
                        boomerang.trajectory = new Vector2(-BASE_SPEED, -BASE_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                default:
                    break;
            }
        }
        public void InwardReturnWindow()
        {
            switch (returnDirection)
            {
                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        boomerang.trajectory = new Vector2(0, PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        boomerang.trajectory = new Vector2(0, -PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        boomerang.trajectory = new Vector2(PIVOT_SPEED, 0);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        boomerang.trajectory = new Vector2(-PIVOT_SPEED, 0);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.NE:
                    if (currentState != CurrentState.movingNE)
                    {
                        currentState = CurrentState.movingNE;
                        boomerang.trajectory = new Vector2(PIVOT_SPEED, -PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.SE:
                    if (currentState != CurrentState.movingSE)
                    {
                        currentState = CurrentState.movingSE;
                        boomerang.trajectory = new Vector2(PIVOT_SPEED, PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.SW:
                    if (currentState != CurrentState.movingSW)
                    {
                        currentState = CurrentState.movingSW;
                        boomerang.trajectory = new Vector2(-PIVOT_SPEED, PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                case Direction.NW:
                    if (currentState != CurrentState.movingNW)
                    {
                        currentState = CurrentState.movingNW;
                        boomerang.trajectory = new Vector2(-PIVOT_SPEED, -PIVOT_SPEED);
                        spriteFactory.BoomerangAttack(boomerang);
                    }
                    break;
                default:
                    break;
            }
        }
        // (Math.Abs(boomerang.drawLocation.X - boomerang.spawnLocation.X) < RANGE && newItem == true) || (Math.Abs(boomerang.drawLocation.Y - boomerang.spawnLocation.Y) < RANGE && newItem == true)
        // (Math.Abs(boomerang.drawLocation.X - boomerang.spawnLocation.X) > RANGE && returning == false) || (Math.Abs(boomerang.drawLocation.Y - boomerang.spawnLocation.Y) > RANGE && returning == false)
        public void Update()
        {            
            if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < (RANGE - RETURN_WINDOW) && newItem)
            {
                if (boomerang.link == null)
                {
                    direction = (Direction)boomerang.goriyaState.direction;
                }
                else
                {
                    direction = (Direction)boomerang.linkState.direction;
                } 
                Outward();
                newItem = false;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > (RANGE - RETURN_WINDOW) && (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < RANGE && !returning)
            {
                OutwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > RANGE && !returning)
            {
                returning = true;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > (RANGE - RETURN_WINDOW) && returning)
            {
                if (boomerang.link == null)
                {
                    if (boomerang.drawLocation.X > boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y > boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.NW;
                    }
                    else if (boomerang.drawLocation.X > boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y < boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.SW;
                    }
                    else if (boomerang.drawLocation.X < boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y < boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.SE;
                    }
                    else if (boomerang.drawLocation.X < boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y > boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.NE;
                    }
                    else if (boomerang.drawLocation.X == boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y > boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.up;
                    }
                    else if (boomerang.drawLocation.X == boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y < boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.down;
                    }
                    else if (boomerang.drawLocation.X < boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y == boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.right;
                    }
                    else if (boomerang.drawLocation.X > boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y == boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.left;
                    }
                }
                else
                {
                    if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.NW;
                    }
                    else if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.SW;
                    }
                    else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.SE;
                    }
                    else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.NE;
                    }
                    else if (boomerang.drawLocation.X == boomerang.link.drawLocation.X && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.up;
                    }
                    else if (boomerang.drawLocation.X == boomerang.link.drawLocation.X && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.down;
                    }
                    else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && boomerang.drawLocation.Y == boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.right;
                    }
                    else if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && boomerang.drawLocation.Y == boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.left;
                    }
                }
                InwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < (RANGE - RETURN_WINDOW) && (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > DESPAWN_DISTANCE && returning)
            {
                if (!brake)
                {
                    currentState = CurrentState.none;
                    brake = true;
                }
                if (boomerang.link == null)
                {
                    if (boomerang.drawLocation.X > boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y > boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.NW;
                    }
                    else if (boomerang.drawLocation.X > boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y < boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.SW;
                    }
                    else if (boomerang.drawLocation.X < boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y < boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.SE;
                    }
                    else if (boomerang.drawLocation.X < boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y > boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.NE;
                    }
                    else if (boomerang.drawLocation.X == boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y > boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.up;
                    }
                    else if (boomerang.drawLocation.X == boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y < boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.down;
                    }
                    else if (boomerang.drawLocation.X < boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y == boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.right;
                    }
                    else if (boomerang.drawLocation.X > boomerang.goriya.drawLocation.X && boomerang.drawLocation.Y == boomerang.goriya.drawLocation.Y)
                    {
                        returnDirection = Direction.left;
                    }
                }
                else
                {
                    if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.NW;
                    }
                    else if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.SW;
                    }
                    else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.SE;
                    }
                    else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.NE;
                    }
                    else if (boomerang.drawLocation.X == boomerang.link.drawLocation.X && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.up;
                    }
                    else if (boomerang.drawLocation.X == boomerang.link.drawLocation.X && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.down;
                    }
                    else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && boomerang.drawLocation.Y == boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.right;
                    }
                    else if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && boomerang.drawLocation.Y == boomerang.link.drawLocation.Y)
                    {
                        returnDirection = Direction.left;
                    }
                }
                Inward();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < DESPAWN_DISTANCE && (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > 0 && returning)
            {
                // boomerang.inFlight = false;
            }
        }
    }
}
