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
        public Weapon weaponSelected = Weapon.bomb;

        public int timer = 0;
        private int invincibilityFrames = 0;

        // private Tool = bomb or something

        public bool grabItem = false;
        public bool isTriforce = false;
        public bool useSword = false;
        public bool useBomb = false;
        public bool useArrow = false;
        public bool useBoomerang = false;
        public bool isDamaged = false;
        public bool isGrabbed = false;
        public bool dying = false;
        public bool dead = false;

        public enum CurrentState {none, idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, damagedUp, damagedDown, damagedLeft, damagedRight, swordUp, swordRight, swordDown, swordLeft, boomerangUp, boomerangRight, boomerangDown, boomerangLeft, bombUp, bombRight, bombDown, bombLeft, arrowUp, arrowRight, arrowDown, arrowLeft, dying, grabbing, grabbed };
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
            useSword = false;
            if (timer == 0)
            {
                timer = 12;
                new LinkSword(link, spriteFactory, this).Execute();
                new LinkOffset(link, false).Execute();
                link.game.sounds["swordSlash"].CreateInstance().Play();
            }
        }

        public void Bomb()
        {
            if (timer == 0)
            {
                timer = 15;
                new LinkBomb(link, spriteFactory, this).Execute();
                link.game.sounds["bombDrop"].CreateInstance().Play();
            }
        }

        //Sets link to an animated state using boomerang based on the value of direction var
        public void Boomerang()
        {
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
                link.game.sounds["arrowBoomerang"].CreateInstance().Play();
            }
        }

        public void Damaged()
        {
            if (timer == 0)
            {
                timer = 12;
                isDamaged = false;
                new LinkDamaged(link, spriteFactory, this).Execute();
                if (invincibilityFrames <= 0)
                {
                    invincibilityFrames = 60;
                    game.util.numLives -= 1;
                    link.game.sounds["linkHurt"].CreateInstance().Play();
                }
            }
        }

        public void Death()
        {
            if (!dead)
            {
                currentState = CurrentState.dying;
                timer = 80;
                new LinkDeath(link, spriteFactory, this).Execute();
                dead = true;
                link.game.sounds["linkDie"].CreateInstance().Play();
            }
            else if (timer <= 0 && dead)
            {
                timer = 180;
                new LinkDeath(link, spriteFactory, this).Execute();
                dying = false;
                dead = false;
            }
        }

        public void GrabItem()
        {
            timer = 60;
            grabItem = false;
            new LinkGrabItem(link, spriteFactory, this).Execute();
        }

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
            if (invincibilityFrames > 0)
            {
                invincibilityFrames--;
            }

            //State calculation
            if (grabItem)
            {
                GrabItem();
            }
            else if (dying)
            {
                Death();
            }
            else if (moving)
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
