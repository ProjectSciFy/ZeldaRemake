using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;


namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class LinkBoomerangStateMachine
    {
        public LinkBoomerang boomerang { get; set; }
        public EnemySpriteFactory spriteFactory { get; set; }
        public enum Direction { right, up, left, down, NE, SE, SW, NW, none }; // NE = North East
        public Direction direction = Direction.down;
        public enum CurrentState { movingUp, movingDown, movingLeft, movingRight, movingNE, movingSE, movingSW, movingNW, none };
        public CurrentState currentState;
        public Direction returnDirection;
        private const int RANGE = 175;
        private const int RETURN_WINDOW = 30;
        private const int DESPAWN_DISTANCE = 5;
        private const float BASE_SPEED = (float)1.5, PIVOT_SPEED = (float) 1.0;
        public Boolean returning = false, newItem = true, brake = false;
        private LinkBoomerangDirectionCalculation directionCalc;
        private LinkBoomerangMovementCalculation movementCalc;
        public LinkBoomerangStateMachine(LinkBoomerang boomerang)
        {
            this.boomerang = boomerang;
            this.spriteFactory = boomerang.spriteFactory;
            this.directionCalc = new LinkBoomerangDirectionCalculation(this);
            this.movementCalc = new LinkBoomerangMovementCalculation(this);
            spriteFactory.LinkBoomerangAttack(boomerang);
        }
        public void Outward()
        {
            movementCalc.MovementCalculationOutward(BASE_SPEED);
        }
        public void OutwardReturnWindow()
        {
            movementCalc.MovementCalculationOutward(PIVOT_SPEED);
        }
        public void Inward()
        {
            movementCalc.MovementCalculationInward(BASE_SPEED);
        }
        public void InwardReturnWindow()
        {
            movementCalc.MovementCalculationInward(PIVOT_SPEED);
        }
        public void Update()
        {
            movementCalc.Update();
            if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < (RANGE - RETURN_WINDOW) && newItem)
            {
                direction = (Direction)boomerang.linkState.direction;
                Outward();
                newItem = false;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > (RANGE - RETURN_WINDOW) && (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < RANGE && !returning)
            {
                OutwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > RANGE && !returning)
            {
                returning = true;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > (RANGE - RETURN_WINDOW) && returning)
            {
                returnDirection = (Direction) directionCalc.CalculateReturnDireciton();
                InwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < (RANGE - RETURN_WINDOW) && (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > DESPAWN_DISTANCE && returning)
            {
                if (!brake) brake = true;
                returnDirection = (Direction) directionCalc.CalculateReturnDireciton();
                Inward();
            }
        }
    }
}
