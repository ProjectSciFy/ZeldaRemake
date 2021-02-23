using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class ArrowStateMachine
    {
        private Arrow arrow;
        private Link link;
        private LinkStateMachine.Direction direction = LinkStateMachine.Direction.down;
        public ArrowStateMachine(Link link, Arrow arrow)
        {
            this.arrow = arrow;
            this.link = link;
            this.direction = link.linkState.direction;
        }
    }
}
