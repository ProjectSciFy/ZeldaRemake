using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace CSE3902_Game_Sprint0.Classes
{
    public class LinkStateMachine
    {

        // comment

        private EeveeSim game;
        private Link link;
        private LinkSpriteFactory spriteFactory;
        
        public enum Direction {right, up, left, down};
        public Direction direction = Direction.down;
        public bool moving = false;

        //enum for item selected?
        //Starting condition should be bomb
        public enum Weapon {none, sword, bomb, arrow, boomerang};
        public Weapon weaponSelected = Weapon.none;

        private int timer = 0;

        // private Tool = bomb or something

        public bool useSword = false;
        int swordcount = 0;
        public bool useBomb = false;
        int bombcount = 0;
        public bool useArrow = false;
        public bool useBoomerang = false;

        public bool damaged = false;

        private enum CurrentState {idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, damagedUp, damagedRight, damagedDown, damagedLeft };
        private CurrentState currentState = CurrentState.idleDown;

        public LinkStateMachine(Link link)
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
            useSword = false;
            useBomb = false;
            // construct nonanimated link facing up with sprite factory
            if (timer == 0)
            {
                switch (direction)
                {
                    case Direction.right:
                        if (currentState != CurrentState.idleRight)
                        {
                            currentState = CurrentState.idleRight;
                            spriteFactory.IdleRight();
                        }
                        break;

                    case Direction.up:
                        if (currentState != CurrentState.idleUp)
                        {
                            currentState = CurrentState.idleUp;
                            spriteFactory.IdleUp();
                        }
                        break;

                    case Direction.left:
                        if (currentState != CurrentState.idleLeft)
                        {
                            currentState = CurrentState.idleLeft;
                            spriteFactory.IdleLeft();
                        }
                        break;

                    case Direction.down:
                        if (currentState != CurrentState.idleDown)
                        {
                            currentState = CurrentState.idleDown;
                            spriteFactory.IdleDown();
                        }
                        break;

                    default:
                        // default is facing down (looking forward at us)
                        currentState = CurrentState.idleDown;
                        spriteFactory.IdleDown();
                        break;
                }
            }
        }

        //Sets link to a moving state based on the value of direction var
        public void Moving()
        {
            useSword = false;
            useBomb = false;
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                switch (direction)
                {
                    case Direction.right:
                        if (currentState != CurrentState.movingRight)
                        {
                            currentState = CurrentState.movingRight;
                            spriteFactory.MovingRight();
                        }
                        break;

                    case Direction.up:
                        if (currentState != CurrentState.movingUp)
                        {
                            currentState = CurrentState.movingUp;
                            spriteFactory.MovingUp();
                        }
                        break;

                    case Direction.left:
                        if (currentState != CurrentState.movingLeft)
                        {
                            currentState = CurrentState.movingLeft;
                            spriteFactory.MovingLeft();
                        }
                        break;

                    case Direction.down:
                        if (currentState != CurrentState.movingDown)
                        {
                            currentState = CurrentState.movingDown;
                            spriteFactory.MovingDown();
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        //Sets link to an animated state using sword based on the value of direction var
        public void Sword()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 60;

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
        }

        //Sets link to an animated state using sword based on the value of direction var
        public void Bomb()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 60;

                switch (direction)
                {
                    case Direction.right:
                        spriteFactory.BombRight();
                        break;

                    case Direction.up:
                        spriteFactory.BombUp();
                        break;

                    case Direction.left:
                        spriteFactory.BombLeft();
                        break;

                    case Direction.down:
                        spriteFactory.BombDown();
                        break;

                    default:
                        spriteFactory.BombDown();
                        break;
                }
            }
        }

        //Sets link to an animated state using boomerang based on the value of direction var
        public void Boomerang()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 25;

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
        }

        //Sets link to an animated state using arrow based on the value of direction var
        public void Arrow()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 25;
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
        }

        public void Damaged()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 120;
                switch (direction)
                {
                    case Direction.right:
                        if (currentState != CurrentState.damagedRight)
                        {
                            currentState = CurrentState.damagedRight;
                            spriteFactory.DamageRight();
                        }
                        break;

                    case Direction.up:
                        if (currentState != CurrentState.damagedUp)
                        {
                            currentState = CurrentState.damagedUp;
                            spriteFactory.DamageUp();
                        }
                        break;

                    case Direction.left:
                        if (currentState != CurrentState.damagedLeft)
                        {
                            currentState = CurrentState.damagedLeft;
                            spriteFactory.DamageLeft();
                        }
                        break;

                    case Direction.down:
                        if (currentState != CurrentState.damagedDown)
                        {
                            currentState = CurrentState.damagedDown;
                            spriteFactory.DamageRight();
                        }
                        break;

                    default:
                        if (currentState != CurrentState.damagedDown)
                        {
                            currentState = CurrentState.damagedDown;
                            spriteFactory.DamageRight();
                        }
                        break;
                }
            }
        }
        //TODO setup more initial states we think we may need & method bodies for adjusting them when called by Link.cs

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }

            if (moving)
            { 
                //boolean weapon variables not in use yet because of problems: WeaponLink its self is calling the sword sprite
                if (useSword)
                {
                    Sword();  
                }
                else if (useBomb)
                {
                    Bomb();
                }
                else if (useArrow)
                {
                    //Arrow();
                }
                else if (useBoomerang)
                {
                    //Boomerang();
                }
                else
                {
                    Moving();
                }
            } 
            else
            {
                if (useSword)
                {
                    swordcount++;
                    Sword();
                    if (swordcount > 60)
                    {
                        useSword = false;
                        swordcount = 0;
                    }
                }
                else if (useBomb)
                {
                    bombcount++;
                    Bomb();
                    if (bombcount > 60)
                    {
                        useBomb = false;
                        bombcount = 0;
                    }
                }
                else if (useArrow)
                {
                    //shootin arrow animation //Arrow();
                }
                else if (useBoomerang)
                {
                    //throwing boomerang animation //Boomerang();
                }
                else
                {
                    Idle();
                }
            }
        }
    }
}
