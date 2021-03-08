using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Collision;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
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
                    else if (tuple.Item2.GetType() == typeof(EnemyKeese))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyStalfos))
                    {
                        new DamagedLink(((Link) tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyWallmaster))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                        //Setting Link's drawLocation to Wallmaster's
                        ((Link)tuple.Item1).drawLocation = ((EnemyWallmaster)tuple.Item2).drawLocation;
                    }
                }
            }

            //Clear the collision set
            collisionManager.collisionSet.Clear();
        }
    }
}
