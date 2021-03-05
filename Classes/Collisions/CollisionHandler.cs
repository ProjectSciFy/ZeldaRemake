using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Collision;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
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
                    if (tuple.Item2.GetType() == typeof(EnemyStalfos))
                    {
                        //Set Link's direction
                        switch (tuple.Item3)
                        {
                            case Collision.Collision.Direction.up:
                                ((Link)tuple.Item1).linkState.ChangeDirection(LinkStateMachine.Direction.up);
                                break;
                            case Collision.Collision.Direction.down:
                                ((Link)tuple.Item1).linkState.ChangeDirection(LinkStateMachine.Direction.down);
                                break;
                            case Collision.Collision.Direction.left:
                                ((Link)tuple.Item1).linkState.ChangeDirection(LinkStateMachine.Direction.left);
                                break;
                            case Collision.Collision.Direction.right:
                                ((Link)tuple.Item1).linkState.ChangeDirection(LinkStateMachine.Direction.right);
                                break;
                            default:
                                break;
                        }

                        //Execute command to hurt link
                        new DamagedLink(((Link) tuple.Item1).linkState).Execute();
                    }
                }
            }

            //Clear the collision set
            collisionManager.collisionSet.Clear();
        }
    }
}
