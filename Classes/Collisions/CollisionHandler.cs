using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Collision;
using CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        private bool IsLinkHurt(Link link)
        {
            bool result = false;

            switch (link.linkState.currentState)
            {
                case LinkStateMachine.CurrentState.damagedUp:
                    result = true;
                    break;
                case LinkStateMachine.CurrentState.damagedDown:
                    result = true;
                    break;
                case LinkStateMachine.CurrentState.damagedLeft:
                    result = true;
                    break;
                case LinkStateMachine.CurrentState.damagedRight:
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        public void Update()
        {
            foreach (Tuple<object, object, Collision.Collision.Direction> tuple in collisionManager.collisionSet)
            {
                if (tuple.Item1.GetType() == typeof(Link))
                {
                    if (tuple.Item2 is IEnemy)
                    {
                        new LinkOnEnemy((Link)tuple.Item1, (IEnemy)tuple.Item2, tuple.Item3).Execute();
                    }
                    else if (tuple.Item2 is ITile)
                    {
                        new LinkOnTile((Link)tuple.Item1, (ITile)tuple.Item2, tuple.Item3).Execute();
                    }
                }
            }

            //New stuff ^^^
            /*
            foreach (Tuple<object, object, Collision.Collision.Direction> tuple in collisionManager.collisionSet)
            {
                //Link colliding with things
                if (tuple.Item1.GetType() == typeof(Link))
                {
                    //Enemies
                    if (tuple.Item2.GetType() == typeof(EnemyAquamentus) && !IsLinkHurt((Link)tuple.Item1))
                    {
                        //Execute command to hurt link
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(BladeTrap) && !IsLinkHurt((Link)tuple.Item1))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyGel) && !IsLinkHurt((Link)tuple.Item1))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyGoriya) && !IsLinkHurt((Link)tuple.Item1))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyKeese) && !IsLinkHurt((Link)tuple.Item1))
                    {
                        new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyStalfos) && !IsLinkHurt((Link)tuple.Item1))
                    {
                        new DamagedLink(((Link) tuple.Item1).linkState).Execute();
                    }
                    else if (tuple.Item2.GetType() == typeof(EnemyWallmaster))
                    {
                        if (!IsLinkHurt((Link)tuple.Item1))
                        {
                            new DamagedLink(((Link)tuple.Item1).linkState).Execute();
                        }
                        //Setting Link's drawLocation to Wallmaster's
                        ((Link)tuple.Item1).drawLocation = ((EnemyWallmaster)tuple.Item2).drawLocation;
                    }
                }
            }
            */
            //Clear the collision set
            collisionManager.collisionSet.Clear();
        }
    }
}
