using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class LinkBoomerangDirectionCalculation
    {
        private LinkBoomerangStateMachine boomerangState;
        private LinkBoomerangProjectile boomerang;
        public enum Direction { right, up, left, down, NE, SE, SW, NW }; // NE = North East
        public Direction returnDirection;
        public LinkBoomerangDirectionCalculation (LinkBoomerangStateMachine boomerangState)
        {
            this.boomerangState = boomerangState;
            this.boomerang = boomerangState.boomerang;
        }
        public Direction CalculateReturnDireciton()
        {
            if (Math.Abs(boomerang.drawLocation.X - boomerang.link.drawLocation.X) < 5 && boomerang.drawLocation.Y > boomerang.link.drawLocation.Y)
            {
                returnDirection = Direction.up;
            }
            else if (Math.Abs(boomerang.drawLocation.X - boomerang.link.drawLocation.X) < 5 && boomerang.drawLocation.Y < boomerang.link.drawLocation.Y)
            {
                returnDirection = Direction.down;
            }
            else if (boomerang.drawLocation.X < boomerang.link.drawLocation.X && Math.Abs(boomerang.drawLocation.Y - boomerang.link.drawLocation.Y) < 5)
            {
                returnDirection = Direction.right;
            }
            else if (boomerang.drawLocation.X > boomerang.link.drawLocation.X && Math.Abs(boomerang.drawLocation.Y - boomerang.link.drawLocation.Y) < 5)
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
