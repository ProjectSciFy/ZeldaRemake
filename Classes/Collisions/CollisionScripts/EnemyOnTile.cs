using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class EnemyOnTile : ICommand
    {
        private IEnemy enemy;
        private ITile tile;
        private Collision.Collision.Direction direction;

        public EnemyOnTile(IEnemy enemy, ITile tile, Collision.Collision.Direction direction)
        {
            this.enemy = enemy;
            this.tile = tile;
            this.direction = direction;
        }
        public void Execute()
        {
            if (enemy is EnemyKeese)
            {
                if (tile is WallTile || tile is StairsTile || tile is GateKeeperTile)
                {
                    if (direction == Collision.Collision.Direction.down)
                    {
                        ((EnemyKeese) enemy).drawLocation.Y = ((EnemyKeese)enemy).drawLocation.Y - ((EnemyKeese)enemy).velocity.Y;
                    }
                    else if (direction == Collision.Collision.Direction.up)
                    {
                        ((EnemyKeese)enemy).drawLocation.Y = ((EnemyKeese)enemy).drawLocation.Y - ((EnemyKeese)enemy).velocity.Y;
                    }
                    else if (direction == Collision.Collision.Direction.right)
                    {
                        ((EnemyKeese)enemy).drawLocation.X = ((EnemyKeese)enemy).drawLocation.X - ((EnemyKeese)enemy).velocity.X;
                    }
                    else if (direction == Collision.Collision.Direction.left)
                    {
                        ((EnemyKeese)enemy).drawLocation.X = ((EnemyKeese)enemy).drawLocation.X - ((EnemyKeese)enemy).velocity.X;
                    }
                }
            }
            else if (enemy is EnemyAquamentus)
            {
                if (direction == Collision.Collision.Direction.down)
                {
                    ((EnemyAquamentus)enemy).drawLocation.Y = ((EnemyAquamentus)enemy).drawLocation.Y - ((EnemyAquamentus)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.up)
                {
                    ((EnemyAquamentus)enemy).drawLocation.Y = ((EnemyAquamentus)enemy).drawLocation.Y - ((EnemyAquamentus)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    ((EnemyAquamentus)enemy).drawLocation.X = ((EnemyAquamentus)enemy).drawLocation.X - ((EnemyAquamentus)enemy).velocity.X;
                }
                else if (direction == Collision.Collision.Direction.left)
                {
                    ((EnemyAquamentus)enemy).drawLocation.X = ((EnemyAquamentus)enemy).drawLocation.X - ((EnemyAquamentus)enemy).velocity.X;
                }
            }
            else if(enemy is EnemySlime) 
            {
                if (direction == Collision.Collision.Direction.down)
                {
                    ((EnemySlime)enemy).drawLocation.Y = ((EnemySlime)enemy).drawLocation.Y - ((EnemySlime)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.up)
                {
                    ((EnemySlime)enemy).drawLocation.Y = ((EnemySlime)enemy).drawLocation.Y - ((EnemySlime)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    ((EnemySlime)enemy).drawLocation.X = ((EnemySlime)enemy).drawLocation.X - ((EnemySlime)enemy).velocity.X;
                }
                else if (direction == Collision.Collision.Direction.left)
                {
                    ((EnemySlime)enemy).drawLocation.X = ((EnemySlime)enemy).drawLocation.X - ((EnemySlime)enemy).velocity.X;
                }
            }
            else if (enemy is EnemyGoriya)
            {
                if (direction == Collision.Collision.Direction.down)
                {
                    ((EnemyGoriya)enemy).drawLocation.Y = ((EnemyGoriya)enemy).drawLocation.Y - ((EnemyGoriya)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.up)
                {
                    ((EnemyGoriya)enemy).drawLocation.Y = ((EnemyGoriya)enemy).drawLocation.Y - ((EnemyGoriya)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    ((EnemyGoriya)enemy).drawLocation.X = ((EnemyGoriya)enemy).drawLocation.X - ((EnemyGoriya)enemy).velocity.X;
                }
                else if (direction == Collision.Collision.Direction.left)
                {
                    ((EnemyGoriya)enemy).drawLocation.X = ((EnemyGoriya)enemy).drawLocation.X - ((EnemyGoriya)enemy).velocity.X;
                }
            }
            else if (enemy is EnemyStalfos)
            {
                if (direction == Collision.Collision.Direction.down)
                {
                    ((EnemyStalfos)enemy).drawLocation.Y = ((EnemyStalfos)enemy).drawLocation.Y - ((EnemyStalfos)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.up)
                {
                    ((EnemyStalfos)enemy).drawLocation.Y = ((EnemyStalfos)enemy).drawLocation.Y - ((EnemyStalfos)enemy).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    ((EnemyStalfos)enemy).drawLocation.X = ((EnemyStalfos)enemy).drawLocation.X - ((EnemyStalfos)enemy).velocity.X;
                }
                else if (direction == Collision.Collision.Direction.left)
                {
                    ((EnemyStalfos)enemy).drawLocation.X = ((EnemyStalfos)enemy).drawLocation.X - ((EnemyStalfos)enemy).velocity.X;
                }
            }
        }
    }
}
