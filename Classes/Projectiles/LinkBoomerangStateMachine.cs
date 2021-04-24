using CSE3902_Game_Sprint0.Classes.Projectiles.LinkBoomerangStateMachineUtility;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using System;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class LinkBoomerangStateMachine
    {
        public LinkBoomerangProjectile boomerang { get; set; }
        public LinkSpriteFactory spriteFactory { get; set; }
        public enum Direction { right, up, left, down, NE, SE, SW, NW, none }; // NE = North East
        public Direction direction { get; set; } = Direction.down;
        public Direction returnDirection { get; set; }
        public Boolean returning = false, newItem = true, brake = false;
        private LinkBoomerangDirectionCalculation directionCalc { get; set; }
        private LinkBoomerangMovementCalculation movementCalc { get; set; }
        public LinkBoomerangStateMachine(LinkBoomerangProjectile boomerang)
        {
            this.boomerang = boomerang;
            this.spriteFactory = boomerang.spriteFactory;
            this.directionCalc = new LinkBoomerangDirectionCalculation(this);
            this.movementCalc = new LinkBoomerangMovementCalculation(this);
            spriteFactory.LinkBoomerangAttack(boomerang);
        }
        public void Outward()
        {
            movementCalc.MovementCalculationOutward(LinkBoomerangStateMachineStorage.BASE_SPEED);
        }
        public void OutwardReturnWindow()
        {
            movementCalc.MovementCalculationOutward(LinkBoomerangStateMachineStorage.PIVOT_SPEED);
        }
        public void Inward()
        {
            movementCalc.MovementCalculationInward(LinkBoomerangStateMachineStorage.BASE_SPEED);
        }
        public void InwardReturnWindow()
        {
            movementCalc.MovementCalculationInward(LinkBoomerangStateMachineStorage.PIVOT_SPEED);
        }
        public void Update()
        {
            if (newItem)
            {
                direction = (Direction)boomerang.linkState.direction;
            }
            movementCalc.Update();
            if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < (LinkBoomerangStateMachineStorage.RANGE - LinkBoomerangStateMachineStorage.RETURN_WINDOW) && newItem)
            {
                direction = (Direction)boomerang.linkState.direction;
                Outward();
                newItem = false;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > (LinkBoomerangStateMachineStorage.RANGE - LinkBoomerangStateMachineStorage.RETURN_WINDOW) &&
                (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < LinkBoomerangStateMachineStorage.RANGE && !returning)
            {
                OutwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > LinkBoomerangStateMachineStorage.RANGE && !returning)
            {
                returning = true;
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > (LinkBoomerangStateMachineStorage.RANGE - LinkBoomerangStateMachineStorage.RETURN_WINDOW) && returning)
            {
                returnDirection = (Direction)directionCalc.CalculateReturnDireciton();
                InwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < (LinkBoomerangStateMachineStorage.RANGE - LinkBoomerangStateMachineStorage.RETURN_WINDOW) &&
                (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > LinkBoomerangStateMachineStorage.DESPAWN_DISTANCE && returning)
            {
                if (!brake) brake = true;
                returnDirection = (Direction)directionCalc.CalculateReturnDireciton();
                Inward();
            }
        }
    }
}
