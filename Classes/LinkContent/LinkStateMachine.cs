using CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace CSE3902_Game_Sprint0.Classes
{
    public class LinkStateMachine
    {

        // comment

        private ZeldaGame game;
        private Link link;
        public LinkSpriteFactory spriteFactory;
        public ProjectileHandler projectileHandler;
        
        public enum Direction {right, up, left, down};
        public Direction direction = Direction.down;
        public bool moving = false;

        //enum for item selected?
        //Starting condition should be bomb
        public enum Weapon {none, sword, bomb, arrow, boomerang};
        public Weapon weaponSelected = Weapon.none;

        public int timer = 0;

        // private Tool = bomb or something

        public bool useSword = false;
        int swordcount = 0;
        public bool useBomb = false;
        int bombcount = 0;
        public bool useArrow = false;
        public bool useBoomerang = false;

        public bool isDamaged = false;
        int damcount = 0;

        public enum CurrentState {idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, damagedUp, damagedDown, damagedLeft, damagedRight, swordUp, swordRight, swordDown, swordLeft, boomerangUp, boomerangRight, boomerangDown, boomerangLeft, bombUp, bombRight, bombDown, bombLeft, arrowUp, arrowRight, arrowDown, arrowLeft };
        public CurrentState currentState;

        public LinkStateMachine(Link link)
        {
            game = link.game;
            this.link = link;
            spriteFactory = new LinkSpriteFactory(link);
            this.projectileHandler = game.projectileHandler;
        }

        // Call this method in Keyboard class when a key that changes direction is pressed
        public void ChangeDirection(Direction toThis)
        {
            this.direction = toThis;
        }

        //Sets link to an idle state based on the value of direction var
        public void Idle()
        {
            if (timer == 0)
            {
                new LinkIdle(link, spriteFactory, this).Execute();
            }
        }

        //Sets link to a moving state based on the value of direction var
        public void Moving()
        {
            if (timer == 0)
            {
                new LinkMoving(link, spriteFactory, this).Execute();
            }
        }

        //Sets link to an animated state using sword based on the value of direction var
        public void Sword()
        {
            if (timer == 0)
            {
                timer = 60;
                useSword = false;
                new LinkSword(link, spriteFactory, this).Execute();
                new LinkOffset(link, false).Execute();
            }
        }

        public void Bomb()
        {
            if (timer == 0)
            {
                timer = 15;
                new LinkBomb(link, spriteFactory, this).Execute();
            }
        }

        //Sets link to an animated state using boomerang based on the value of direction var
        public void Boomerang()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 15;
                useBoomerang = false;
                new LinkContent.LinkScripts.LinkBoomerang(link, spriteFactory, this).Execute();
            }
        }

        //Sets link to an animated state using arrow based on the value of direction var
        public void Arrow()
        {
            if (timer == 0)
            {
                timer = 25;
                new LinkArrow(link, spriteFactory, this).Execute();
            }
        }

        public void Damaged()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 12;
                isDamaged = false;
                new LinkDamaged(link, spriteFactory, this).Execute();
            }
        }
        //TODO setup more initial states we think we may need & method bodies for adjusting them when called by Link.cs

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }

            if (timer == 0)
            {
                //Reverse offset
                new LinkOffset(link, true).Execute();
                link.drawOffset.X = 0;
                link.drawOffset.Y = 0;
            }

            //State calculation
            if (moving)
            {
                if (isDamaged)
                {
                    Damaged();
                }
                else if (useSword)
                {
                    Sword();
                }
                else if (useBomb)
                {
                    Bomb();
                    useBomb = false;
                }
                else if (useArrow)
                {
                    Arrow();
                    useArrow = false;
                }
                else if (useBoomerang)
                {
                    Boomerang();
                }
                else
                {
                    Moving();
                }
            }
            else
            {
                if (isDamaged)
                {
                    Damaged();
                }
                else if (useSword)
                {
                    Sword();
                }
                else if (useBomb)
                {
                    Bomb();
                    useBomb = false;
                }
                else if (useArrow)
                {
                    Arrow();
                    useArrow = false;
                }
                else if (useBoomerang)
                {
                    Boomerang();
                }
                else
                {
                    Idle();
                }
            }
        }
    }
}
