using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class GoriyaBoomerangStatemachine
    {
        public GoriyaBoomerang boomerang { get; set; }
        public EnemySpriteFactory spriteFactory { get; set; }
        public enum Direction { right, up, left, down, NE, SE, SW, NW, none };
        public Direction direction { get; set; }
        public enum CurrentState { movingUp, movingDown, movingLeft, movingRight, movingNE, movingSE, movingSW, movingNW, none };
        public CurrentState currentState { get; set; }
        public Direction returnDirection { get; set; } = Direction.none;
        private const int RANGE = 175;
        private const int RETURN_WINDOW = 30;
        private const int DESPAWN_DISTANCE = 5;
        private const float BASE_SPEED = (float)3.0, PIVOT_SPEED = (float)2.0;
        public Boolean returning = false, newItem = true, brake = false;
        private GoriyaBoomerangDirectionalCalulation directionalCalc { get; set; }
        private GoriyaBoomerangMovementCalculation movementCalc { get; set; }

        public GoriyaBoomerangStatemachine(GoriyaBoomerang boomerang)
        {
            this.boomerang = boomerang;
            this.spriteFactory = boomerang.spriteFactory;
            this.directionalCalc = new GoriyaBoomerangDirectionalCalulation(this);
            this.movementCalc = new GoriyaBoomerangMovementCalculation(this);
            spriteFactory.GoriyaBoomerangAttack(boomerang);
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
            if (newItem)
            {
                direction = (Direction)boomerang.goriyaState.direction;
            }
            movementCalc.Update();
            if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) < (RANGE - RETURN_WINDOW) && newItem)
            {
                direction = (Direction)boomerang.goriyaState.direction;
                Outward();
                newItem = false;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > (RANGE - RETURN_WINDOW) && (int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) < RANGE && !returning)
            {
                OutwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > RANGE && !returning)
            {
                returning = true;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > (RANGE - RETURN_WINDOW) && returning)
            {
                returnDirection = (Direction)directionalCalc.CalculateReturnDirection();
                InwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) < (RANGE - RETURN_WINDOW) && (int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > DESPAWN_DISTANCE && returning)
            {
                if (!brake) brake = true;
                returnDirection = (Direction) directionalCalc.CalculateReturnDirection();
                Inward();
            }
        }
    }
}
