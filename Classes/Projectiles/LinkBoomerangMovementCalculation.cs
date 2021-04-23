using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class LinkBoomerangMovementCalculation
    {
        private LinkBoomerangStateMachine boomerangState { get; set; }
        private LinkBoomerangProjectile boomerang { get; set; }
        private enum Direction { right, up, left, down, NE, SE, SW, NW, none }; // NE = North East
        private Direction returnDirection { get; set; }
        private Direction direction { get; set; }
        private LinkSpriteFactory spriteFactory { get; set; }
        public LinkBoomerangMovementCalculation(LinkBoomerangStateMachine boomerangState)
        {
            this.boomerangState = boomerangState;
            this.boomerang = boomerangState.boomerang;
            this.spriteFactory = boomerangState.spriteFactory;
        }
        public void MovementCalculationInward(float speed)
        {
            switch (returnDirection)
            {
                case Direction.down:
                    boomerang.velocity = new Vector2(0, speed);
                    break;
                case Direction.up:
                    boomerang.velocity = new Vector2(0, -speed);
                    break;
                case Direction.right:
                    boomerang.velocity = new Vector2(speed, 0);
                    break;
                case Direction.left:
                    boomerang.velocity = new Vector2(-speed, 0);
                    break;
                case Direction.NE:
                    boomerang.velocity = new Vector2(speed, -speed);
                    break;
                case Direction.SE:
                    boomerang.velocity = new Vector2(speed, speed);
                    break;
                case Direction.SW:
                    boomerang.velocity = new Vector2(-speed, speed);
                    break;
                case Direction.NW:
                    boomerang.velocity = new Vector2(-speed, -speed);
                    break;
                default:
                    break;
            }
        }
        public void MovementCalculationOutward(float speed)
        {
            switch (direction)
            {
                case Direction.down:
                    boomerang.velocity = new Vector2(0, speed);
                    break;
                case Direction.up:
                    boomerang.velocity = new Vector2(0, -speed);
                    break;
                case Direction.right:
                    boomerang.velocity = new Vector2(speed, 0);
                    break;
                case Direction.left:
                    boomerang.velocity = new Vector2(-speed, 0);
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {
            this.returnDirection = (Direction)boomerangState.returnDirection;
            this.direction = (Direction)boomerangState.direction;
        }
    }
}
