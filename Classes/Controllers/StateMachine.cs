using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class StateMachine
    {

        // comment

        private EeveeSim game;
        private Link link;
        private ISprite LinkSprite;
        private LinkSpriteFactory spriteFactory;
        //Starting condition should be bomb
        public enum Direction {right, up, left, down};
        public Direction direction = Direction.down;
        //enum for item selected?
        // private Tool = bomb or something
        private bool useTool = false;
        private bool useSword = false;

        public StateMachine(Link link)
        {
            game = link.game;
            this.link = link;
            spriteFactory = new LinkSpriteFactory(link);
            spriteFactory.IdleDown();
        }

        // Call this method in Keyboard class when a key that changes direction is pressed
        public void ChangeDirection(Direction toThis)
        {
            this.direction = toThis;
        }

        //Sets link to an idle state based on the value of direction var
        public void Idle()
        {
            // construct nonanimated link facing up with sprite factory

            switch (direction)
            {
                case Direction.right:
                    spriteFactory.IdleRight();
                    break;

                case Direction.up:
                    spriteFactory.IdleUp();
                    break;

                case Direction.left:
                    spriteFactory.IdleLeft();
                    break;

                case Direction.down:
                    spriteFactory.IdleDown();
                    break;

                default:
                    // default is facing down (looking forward at us)
                    spriteFactory.IdleDown();
                    break;
            }
        }

        //Sets link to a moving state based on the value of direction var
        public void Moving()
        {
            // construct animated link facing up with sprite factory

            switch (direction)
            {
                case Direction.right:
                    spriteFactory.MovingRight();
                    break;

                case Direction.up:
                    spriteFactory.MovingUp();
                    break;

                case Direction.left:
                    spriteFactory.MovingLeft();
                    break;

                case Direction.down:
                    spriteFactory.MovingDown();
                    break;

                default:
                    break;
            }
        }

        //Sets link to an animated state using sword based on the value of direction var
        public void Sword()
        {
            // construct animated link facing up with sprite factory

            switch (direction)
            {
                case Direction.right:
                    spriteFactory.SwordRight();
                    break;

                case Direction.up:
                    spriteFactory.SwordUp();
                    break;

                case Direction.left:
                    spriteFactory.SwordLeft();
                    break;

                case Direction.down:
                    spriteFactory.SwordDown();
                    break;

                default:
                    spriteFactory.SwordDown();
                    break;
            }
        }

        //Sets link to an animated state using boomerang based on the value of direction var
        public void Boomerang()
        {
            // construct animated link facing up with sprite factory

            switch (direction)
            {
                case Direction.right:
                    spriteFactory.BoomerangRight();
                    break;

                case Direction.up:
                    spriteFactory.BoomerangUp();
                    break;

                case Direction.left:
                    spriteFactory.BoomerangLeft();
                    break;

                case Direction.down:
                    spriteFactory.BoomerangDown();
                    break;

                default:
                    spriteFactory.BoomerangDown();
                    break;
            }
        }

        //Sets link to an animated state using arrow based on the value of direction var
        public void Arrow()
        {
            // construct animated link facing up with sprite factory

            switch (direction)
            {
                case Direction.right:
                    spriteFactory.ArrowRight();
                    break;

                case Direction.up:
                    spriteFactory.ArrowUp();
                    break;

                case Direction.left:
                    spriteFactory.ArrowLeft();
                    break;

                case Direction.down:
                    spriteFactory.ArrowDown();
                    break;

                default:
                    spriteFactory.ArrowDown();
                    break;
            }
        }

        //TODO setup more initial states we think we may need & method bodies for adjusting them when called by Link.cs
    }
}
