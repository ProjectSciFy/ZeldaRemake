using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Collision;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions
{
    public class CollisionHandler
    {
        public CollisionManager collisionManager;

        public CollisionHandler(CollisionManager collisionManager)
        {
            this.collisionManager = collisionManager;
        }

        public void Update()
        {
            foreach (Tuple<object, object, Collision.Collision.Direction> tuple in collisionManager.collisionSet)
            {
                //Link colliding with things
                if (tuple.Item1.GetType() == typeof(Link))
                {
                    //Enemies
                    if (tuple.Item2.GetType() == typeof(EnemyAquamentus))
                    {
                        //Execute command to hurt link
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(BladeTrap))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyGel))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyGoriya))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyStalfos))
                    {
                        new DamagedLink(((Link) tuple.Item1).linkState).Execute();
                    } 
                }
            }

            //Clear the collision set
            collisionManager.collisionSet.Clear();
        }
    }
}
