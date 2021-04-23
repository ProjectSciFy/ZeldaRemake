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
        private const int RANGE = 175;
        private const int RETURN_WINDOW = 30;
        private const int DESPAWN_DISTANCE = 5;
        private const float BASE_SPEED = 3, PIVOT_SPEED = (float)2.0;
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
                direction = (Direction)boomerang.linkState.direction;
            }
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
                returnDirection = (Direction)directionCalc.CalculateReturnDireciton();
                InwardReturnWindow();
            }
            else if ((int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) < (RANGE - RETURN_WINDOW) && (int)Vector2.Distance(boomerang.drawLocation, boomerang.spawnLocation) > DESPAWN_DISTANCE && returning)
            {
                if (!brake) brake = true;
                returnDirection = (Direction)directionCalc.CalculateReturnDireciton();
                Inward();
            }
        }
    }
}
