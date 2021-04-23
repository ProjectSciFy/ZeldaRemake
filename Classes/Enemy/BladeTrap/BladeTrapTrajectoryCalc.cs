using CSE3902_Game_Sprint0.Classes._21._2._13;
using Microsoft.Xna.Framework;
using System;

namespace CSE3902_Game_Sprint0.Classes.Enemy
{
    public class BladeTrapTrajectoryCalc : ICommand
    {
        private Link link { get; set; }
        private EnemyBladeTrap BladeTrap { get; set; }
        private BladeTrapStateMachine state { get; set; }
        public BladeTrapTrajectoryCalc(Link link, EnemyBladeTrap bladetrap, BladeTrapStateMachine state)
        {
            this.link = link;
            this.BladeTrap = bladetrap;
            this.state = state;
        }

        public void Execute()
        {
            if ((Math.Abs(link.drawLocation.X - BladeTrap.spawnLocation.X) <= BladeTrap.range.X) && Math.Abs(link.drawLocation.Y - BladeTrap.spawnLocation.Y) < BladeTrapStateMachine.TRAP_WIDTH && !state.returning)
            {
                state.attacking = true;
                state.nested = false;
                if (link.drawLocation.X > BladeTrap.spawnLocation.X)
                {
                    state.direction = BladeTrapStateMachine.Direction.right;
                }
                else if (link.drawLocation.X < BladeTrap.spawnLocation.X)
                {
                    state.direction = BladeTrapStateMachine.Direction.left;
                }
            }
            else if ((Math.Abs(link.drawLocation.Y - BladeTrap.spawnLocation.Y) <= BladeTrap.range.Y) && Math.Abs(link.drawLocation.X - BladeTrap.spawnLocation.X) < BladeTrapStateMachine.TRAP_WIDTH && !state.returning)
            {
                state.attacking = true;
                state.nested = false;
                if (link.drawLocation.Y > BladeTrap.spawnLocation.Y)
                {
                    state.direction = BladeTrapStateMachine.Direction.down;
                }
                else if (link.drawLocation.Y < BladeTrap.spawnLocation.Y)
                {
                    state.direction = BladeTrapStateMachine.Direction.up;
                }
            }

            if (((int)Math.Abs(BladeTrap.drawLocation.X - BladeTrap.spawnLocation.X) > BladeTrap.range.X) && (BladeTrap.drawLocation.Y - BladeTrap.spawnLocation.Y) < BladeTrapStateMachine.TRAP_WIDTH && !state.returning)
            {
                state.returning = true;
                if (state.direction == BladeTrapStateMachine.Direction.right)
                {
                    state.direction = BladeTrapStateMachine.Direction.left;
                }
                else if (state.direction == BladeTrapStateMachine.Direction.left)
                {
                    state.direction = BladeTrapStateMachine.Direction.right;
                }
            }
            else if ((int)Math.Abs(BladeTrap.drawLocation.Y - BladeTrap.spawnLocation.Y) > BladeTrap.range.Y && (BladeTrap.drawLocation.X - BladeTrap.spawnLocation.X) < BladeTrapStateMachine.TRAP_WIDTH && !state.returning)
            {
                state.returning = true;
                if (state.direction == BladeTrapStateMachine.Direction.up)
                {
                    state.direction = BladeTrapStateMachine.Direction.down;
                }
                else if (state.direction == BladeTrapStateMachine.Direction.down)
                {
                    state.direction = BladeTrapStateMachine.Direction.up;
                }
            }
            if ((int)Vector2.Distance(BladeTrap.drawLocation, BladeTrap.spawnLocation) == 0 && state.returning)
            {
                state.nested = true;
                state.returning = false;
            }
        }
    }
}
