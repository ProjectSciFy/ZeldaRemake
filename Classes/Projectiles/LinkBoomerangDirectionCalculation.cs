using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class LinkBoomerangDirectionCalculation
    {
        private LinkBoomerangStateMachine boomerangState { get; set; }
        private LinkBoomerangProjectile boomerang { get; set; }
        public enum Direction { right, up, left, down, NE, SE, SW, NW }; // NE = North East
        public Direction returnDirection { get; set; }
        private const int BOUND = 5;
        public LinkBoomerangDirectionCalculation (LinkBoomerangStateMachine boomerangState)
        {
            this.boomerangState = boomerangState;
            this.boomerang = boomerangState.boomerang;
        }
        public Direction CalculateReturnDireciton()
        {
            if (Math.Abs(boomerang.drawLocation.X - boomerang.link.drawLocation.X) < BOUND && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
            {
                returnDirection = Direction.up;
            }
            else if (Math.Abs(boomerang.drawLocation.X - boomerang.link.drawLocation.X) < BOUND && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
            {
                returnDirection = Direction.down;
            }
            else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && Math.Abs(boomerang.drawLocation.Y - boomerang.link.drawLocation.Y) < BOUND)
            {
                returnDirection = Direction.right;
            }
            else if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && Math.Abs(boomerang.drawLocation.Y - boomerang.link.drawLocation.Y) < BOUND)
            {
                returnDirection = Direction.left;
            }
            else if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
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
            return returnDirection;
        }
    }
}
