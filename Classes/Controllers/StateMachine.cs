using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class StateMachine
    {

        // comment

        //Starting condition should be bomb
        private int direction = 270;
        //enum for item selected?
        // private Tool = bomb or something
        private bool useTool = false;
        private bool useSword = false;

        public void MoveUp()
        {
            // construct animated link moving up with sprite factory
        }
        public void IdleUp()
        {
            // construct nonanimated link facing up with sprite factory
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
