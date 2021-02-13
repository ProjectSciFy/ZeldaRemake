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
        private enum Direction {right, up, left, down};
        private Direction direction = Direction.down;
        //enum for item selected?
        // private Tool = bomb or something
        private bool useTool = false;
        private bool useSword = false;

        public StateMachine(Link link)
        {
            game = link.game;
            this.link = link;
            spriteFactory = new LinkSpriteFactory(link);
        }

        public void MoveUp()
        {
            // construct animated link moving up with sprite factory
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
        public void MoveDown()
        {
            // construct animated link moving down with sprite factory
        }
        public void IdleDown()
        {
            // construct nonanimated link facing down with sprite factory
        }
        public void MoveRight()
        {
            // construct animated link moving right with sprite factory
        }
        public void IdleRight()
        {
            // construct nonanimated link facing right with sprite factory
        }
        public void MoveLeft()
        {
            // construct animated link moving left with sprite factory
        }
        public void IdleLeft()
        {
            // construct nonanimated link facing left with sprite factory
        }
        public void UpSword()
        {
            // construct animated link using sword up
        }
        public void DownSword()
        {
            // construct animated link using sword down
        }
        public void RightSword()
        {
            // construct animated link using sword right
        }
        public void LeftSword()
        {
            // construct animated link using sword left
        }
        public void BoomerangUp()
        {
            // construct animated link using boomerang up
        }
        public void BoomerangDown()
        {
            // construct animated link using boomerang down
        }
        public void BoomerangRight()
        {
            // construct animated link using boomerang right
        }
        public void BoomerangLeft()
        {
            // construct animated link using boomerang left
        }
        public void ArrowUp()
        {
            // construct animated link using arrow up
        }
        public void ArrowDown()
        {
            // construct animated link using arrow down
        }
        public void ArrowRight()
        {
            // construct animated link using arrow right
        }
        public void ArrowLeft()
        {
            // construct animated link using arrow left
        }
        //TODO setup more initial states we think we may need & method bodies for adjusting them when called by Link.cs
    }
}
