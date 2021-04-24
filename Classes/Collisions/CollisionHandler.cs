using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Collision;
using CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Interfaces;
using System;

namespace CSE3902_Game_Sprint0.Classes.Collisions
{
    public class CollisionHandler
    {
        public CollisionManager collisionManager { get; set; }

        public CollisionHandler(CollisionManager collisionManager)
        {
            this.collisionManager = collisionManager;
        }
        public void Update()
        {
            foreach (Tuple<object, object, Collision.Collision.Direction> tuple in collisionManager.collisionSet) {
                if (tuple.Item1 is Link) {
                    if (tuple.Item2 is IEnemy) new LinkOnEnemy((Link)tuple.Item1, (IEnemy)tuple.Item2, tuple.Item3).Execute();
                    else if (tuple.Item2 is IItem) new LinkOnItem((Link)tuple.Item1, (IItem)tuple.Item2, tuple.Item3).Execute();
                    else if (tuple.Item2 is ITile) new LinkOnTile((Link)tuple.Item1, (ITile)tuple.Item2, tuple.Item3).Execute();
                }
                if (tuple.Item1 is LittleHelper.LittleHelper) {
                    if (tuple.Item2 is IEnemy) new LittleHelperOnEnemy((LittleHelper.LittleHelper)tuple.Item1, (IEnemy)tuple.Item2, tuple.Item3).Execute();
                    else if (tuple.Item2 is IItem) new LittleHelperOnItem((LittleHelper.LittleHelper)tuple.Item1, (IItem)tuple.Item2, tuple.Item3).Execute();
                }
                if (tuple.Item1 is IEnemy) {
                    if (tuple.Item2 is ITile) new EnemyOnTile((IEnemy)tuple.Item1, (ITile)tuple.Item2, tuple.Item3).Execute();
                    else if (tuple.Item2 is Link) new EnemyOnLink((IEnemy)tuple.Item1, (Link)tuple.Item2, tuple.Item3).Execute();
                }
                if (tuple.Item1 is IProjectile) {
                    if (tuple.Item2 is Link) new ProjectileOnLink((IProjectile)tuple.Item1, (Link)tuple.Item2, tuple.Item3).Execute();
                    else if (tuple.Item2 is LittleHelper.LittleHelper) new ProjectileOnLittleHelper((IProjectile)tuple.Item1, (LittleHelper.LittleHelper)tuple.Item2, tuple.Item3).Execute();
                    else if (tuple.Item2 is IEnemy) new ProjectileOnEnemy((IProjectile)tuple.Item1, (IEnemy)tuple.Item2, tuple.Item3).Execute();
                    else if (tuple.Item2 is ITile) new ProjectileOnTile((IProjectile)tuple.Item1, (ITile)tuple.Item2, tuple.Item3).Execute();
                }
                if (tuple.Item1 is IItem) {
                    if (tuple.Item2 is ITile) new ItemOnTile((IItem)tuple.Item1, (ITile)tuple.Item2, tuple.Item3).Execute();
                }
            }
            collisionManager.collisionSet.Clear();
        }
    }
}
