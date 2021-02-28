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

        private EeveeSim game;
        private Link link;
        private LinkSpriteFactory spriteFactory;
        public ProjectileHandler projectileHandler;
        
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

        public bool isDamaged = false;
        int damcount = 0;

        private enum CurrentState {idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, damagedUp, damagedDown, damagedLeft, damagedRight, swordUp, swordRight, swordDown, swordLeft, boomerangUp, boomerangRight, boomerangDown, boomerangLeft, bombUp, bombRight, bombDown, bombLeft, arrowUp, arrowRight, arrowDown, arrowLeft };
        private CurrentState currentState = CurrentState.idleDown;

        public LinkStateMachine(Link link)
        {
            game = link.game;
            this.link = link;
            spriteFactory = new LinkSpriteFactory(link);
            this.projectileHandler = game.projectileHandler;
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
                useSword = false;

                switch (direction)
                {
                    case Direction.right:
                        if (currentState != CurrentState.swordRight)
                        {
                            currentState = CurrentState.swordRight;
                            spriteFactory.SwordRight();
                        }
                        break;

                    case Direction.up:
                        if (currentState != CurrentState.swordUp)
                        {
                            currentState = CurrentState.swordUp;
                            spriteFactory.SwordUp();
                        }
                        break;

                    case Direction.left:
                        if (currentState != CurrentState.swordLeft)
                        {
                            currentState = CurrentState.swordLeft;
                            spriteFactory.SwordLeft();
                        }
                        break;

                    case Direction.down:
                        if (currentState != CurrentState.swordDown)
                        {
                            currentState = CurrentState.swordDown;
                            spriteFactory.SwordDown();
                        }
                        break;

                    default:
                        if (currentState != CurrentState.swordDown)
                        {
                            currentState = CurrentState.swordDown;
                            spriteFactory.SwordDown();
                        }
                        break;
                }
            }
        }

        public void Bomb()
        {
            if (timer == 0)
            {
                timer = 60;
                useBomb = false;

                switch (direction)
                {
                    case Direction.right:
                        if (currentState != CurrentState.bombRight)
                        {
                            currentState = CurrentState.bombRight;
                            spriteFactory.BombRight();
                            projectileHandler.Add(new Bomb(game, new Vector2(link.drawLocation.X + 16, link.drawLocation.Y), projectileHandler));
                        }
                        break;

                    case Direction.up:
                        if (currentState != CurrentState.bombUp)
                        {
                            currentState = CurrentState.bombUp;
                            spriteFactory.BombUp();
                            projectileHandler.Add(new Bomb(game, new Vector2(link.drawLocation.X, link.drawLocation.Y - 16), projectileHandler));
                        }
                        break;

                    case Direction.left:
                        if (currentState != CurrentState.bombLeft)
                        {
                            currentState = CurrentState.bombLeft;
                            spriteFactory.BombLeft();
                            projectileHandler.Add(new Bomb(game, new Vector2(link.drawLocation.X - 16, link.drawLocation.Y), projectileHandler));
                        }
                        break;

                    case Direction.down:
                        if (currentState != CurrentState.bombDown)
                        {
                            currentState = CurrentState.bombDown;
                            spriteFactory.BombDown();
                            projectileHandler.Add(new Bomb(game, new Vector2(link.drawLocation.X, link.drawLocation.Y + 16), projectileHandler));
                        }
                        break;

                    default:
                        if (currentState != CurrentState.bombDown)
                        {
                            currentState = CurrentState.bombDown;
                            spriteFactory.BombDown();
                            projectileHandler.Add(new Bomb(game, new Vector2(link.drawLocation.X, link.drawLocation.Y + 16), projectileHandler));
                        }
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
                useBoomerang = false;

                switch (direction)
                {
                    case Direction.right:
                        if (currentState != CurrentState.boomerangRight)
                        {
                            currentState = CurrentState.boomerangRight;
                            spriteFactory.BoomerangRight();
                        }
                        break;

                    case Direction.up:
                        if (currentState != CurrentState.boomerangUp)
                        {
                            currentState = CurrentState.boomerangUp;
                            spriteFactory.BoomerangUp();
                        }
                        break;

                    case Direction.left:
                        if (currentState != CurrentState.boomerangLeft)
                        {
                            currentState = CurrentState.boomerangLeft;
                            spriteFactory.BoomerangLeft();
                        }
                        break;

                    case Direction.down:
                        if (currentState != CurrentState.boomerangDown)
                        {
                            currentState = CurrentState.boomerangDown;
                            spriteFactory.BoomerangDown();
                        }
                        break;

                    default:
                        if (currentState != CurrentState.boomerangDown)
                        {
                            currentState = CurrentState.boomerangDown;
                            spriteFactory.BoomerangDown();
                        }
                        break;
                }
            }
        }

        //Sets link to an animated state using arrow based on the value of direction var
        public void Arrow()
        {
            if (timer == 0)
            {
                timer = 25;
                useArrow = false;

                switch (direction)
                {
                    case Direction.right:
                        if (currentState != CurrentState.arrowRight)
                        {
                            currentState = CurrentState.arrowRight;
                            spriteFactory.ArrowRight();
                            projectileHandler.Add(new Arrow(game, new Vector2(link.drawLocation.X + 16, link.drawLocation.Y), projectileHandler, Projectiles.Arrow.Direction.right));
                        }
                        break;

                    case Direction.up:
                        if (currentState != CurrentState.arrowUp)
                        {
                            currentState = CurrentState.arrowUp;
                            spriteFactory.ArrowUp();
                            projectileHandler.Add(new Arrow(game, new Vector2(link.drawLocation.X + 4, link.drawLocation.Y - 16), projectileHandler, Projectiles.Arrow.Direction.up));
                        }
                        break;

                    case Direction.left:
                        if (currentState != CurrentState.arrowLeft)
                        {
                            currentState = CurrentState.arrowLeft;
                            spriteFactory.ArrowLeft();
                            projectileHandler.Add(new Arrow(game, new Vector2(link.drawLocation.X - 16, link.drawLocation.Y), projectileHandler, Projectiles.Arrow.Direction.left));
                        }
                        break;

                    case Direction.down:
                        if (currentState != CurrentState.arrowDown)
                        {
                            currentState = CurrentState.arrowDown;
                            spriteFactory.ArrowDown();
                            projectileHandler.Add(new Arrow(game, new Vector2(link.drawLocation.X + 4, link.drawLocation.Y + 16), projectileHandler, Projectiles.Arrow.Direction.down));
                        }
                        break;

                    default:
                        if (currentState != CurrentState.arrowDown)
                        {
                            currentState = CurrentState.arrowDown;
                            spriteFactory.ArrowDown();
                            projectileHandler.Add(new Arrow(game, new Vector2(link.drawLocation.X + 4, link.drawLocation.Y + 16), projectileHandler, Projectiles.Arrow.Direction.down));
                        }
                        break;
                }
            }
        }

        public void Damaged()
        {
            // construct animated link facing up with sprite factory
            if (timer == 0)
            {
                timer = 60;
                isDamaged = false;

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
                            spriteFactory.DamageDown();
                        }
                        break;

                    default:
                        if (currentState != CurrentState.damagedDown)
                        {
                            currentState = CurrentState.damagedDown;
                            spriteFactory.DamageDown();
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
                }
                else if (useArrow)
                {
                    Arrow();
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
                }
                else if (useArrow)
                {
                    Arrow();
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
