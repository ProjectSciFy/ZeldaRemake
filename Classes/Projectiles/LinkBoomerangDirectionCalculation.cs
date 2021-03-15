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
            return returnDirection;
        }
    }
}
