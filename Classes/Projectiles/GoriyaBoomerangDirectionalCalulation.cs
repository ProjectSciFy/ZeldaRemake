namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class GoriyaBoomerangDirectionalCalulation
    {
        private GoriyaBoomerangStatemachine boomerangState { get; set; }
        private GoriyaBoomerang boomerang { get; set; }
        public enum Direction { right, up, left, down, NE, SE, SW, NW, none }; // NE = North East
        public Direction returnDirection { get; set; }
        public GoriyaBoomerangDirectionalCalulation(GoriyaBoomerangStatemachine boomerangState)
        {
            this.boomerangState = boomerangState;
            this.boomerang = boomerangState.boomerang;
        }
        public Direction CalculateReturnDirection()
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
            return returnDirection;
        }
    }
}
