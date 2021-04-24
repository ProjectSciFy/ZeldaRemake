using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles.GoriyaBoomerangStateMachineUtility;
using Microsoft.Xna.Framework;
using System;

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
            movementCalc.MovementCalculationOutward(GoriyaBoomerangStateMachineStorage.BASE_SPEED);
        }
        public void OutwardReturnWindow()
        {
            movementCalc.MovementCalculationOutward(GoriyaBoomerangStateMachineStorage.PIVOT_SPEED);
        }
        public void Inward()
        {
            movementCalc.MovementCalculationInward(GoriyaBoomerangStateMachineStorage.BASE_SPEED);
        }
        public void InwardReturnWindow()
        {
            movementCalc.MovementCalculationInward(GoriyaBoomerangStateMachineStorage.PIVOT_SPEED);
        }
        public void Update()
        {
            if (newItem)
            {
                direction = (Direction)boomerang.goriyaState.direction;
            }
            movementCalc.Update();
            if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) < (GoriyaBoomerangStateMachineStorage.RANGE - GoriyaBoomerangStateMachineStorage.RETURN_WINDOW) && newItem)
            {
                direction = (Direction)boomerang.goriyaState.direction;
                Outward();
                newItem = false;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > (GoriyaBoomerangStateMachineStorage.RANGE - GoriyaBoomerangStateMachineStorage.RETURN_WINDOW) &&
                (int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) < GoriyaBoomerangStateMachineStorage.RANGE && !returning)
            {
                OutwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > GoriyaBoomerangStateMachineStorage.RANGE && !returning)
            {
                returning = true;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > (GoriyaBoomerangStateMachineStorage.RANGE - GoriyaBoomerangStateMachineStorage.RETURN_WINDOW) && returning)
            {
                returnDirection = (Direction)directionalCalc.CalculateReturnDirection();
                InwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) < (GoriyaBoomerangStateMachineStorage.RANGE - GoriyaBoomerangStateMachineStorage.RETURN_WINDOW) &&
                (int)Vector2.Distance(boomerang.drawLocation, boomerang.SpawnLocation) > GoriyaBoomerangStateMachineStorage.DESPAWN_DISTANCE && returning)
            {
                if (!brake) brake = true;
                returnDirection = (Direction)directionalCalc.CalculateReturnDirection();
                Inward();
            }
        }
    }
}
