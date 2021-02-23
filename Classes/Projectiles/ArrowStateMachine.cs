using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class ArrowStateMachine
    {
        private Arrow arrow;
        private Link link;
        private LinkStateMachine.Direction linkDirection = LinkStateMachine.Direction.down;
        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        public EnemySpriteFactory spriteFactory;
        public Boolean newItem = true;
        public ArrowStateMachine(Link link, Arrow arrow)
        {
            this.arrow = arrow;
            this.link = link;
            this.linkDirection = link.linkState.direction;
            spriteFactory = arrow.spriteFactory;
        }

        public void Attack()
        {
            switch (direction)
            {
                case Direction.down:
                    spriteFactory.ArrowDown(this.arrow);
                    break;
                case Direction.up:
                    spriteFactory.ArrowUp(this.arrow);
                    break;
                case Direction.right:
                    spriteFactory.ArrowRight(this.arrow);
                    break;
                case Direction.left:
                    spriteFactory.ArrowLeft(this.arrow);
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            direction = (Direction)this.link.linkState.direction;
            if (newItem)
            {
                Attack();
                newItem = false;
            }
        }
    }
}
