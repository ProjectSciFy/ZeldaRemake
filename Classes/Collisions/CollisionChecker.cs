using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collision
{
    public class CollisionChecker
    {
        public CollisionManager collisionManager;

        public CollisionChecker(CollisionManager collisionManager)
        {
            this.collisionManager = collisionManager;
        }

        private Collision.Direction CollisionDirection(Rectangle entity1, Rectangle entity2)
        {
            Rectangle collisionRectangle = Rectangle.Intersect(entity1, entity2);
            Collision.Direction direction = Collision.Direction.none;

            if (collisionRectangle.Width > collisionRectangle.Height)
            {
                //Vertical collisions
                if (collisionRectangle.Y == entity1.Y)
                {
                    direction = Collision.Direction.up;
                }
                else
                {
                    direction = Collision.Direction.down;
                }

            }
            else if (collisionRectangle.Height >= collisionRectangle.Width)
            {
                //Horizontal & diagonal collisions
                if (collisionRectangle.X == entity1.X)
                {
                    direction = Collision.Direction.left;
                }
                else
                {
                    direction = Collision.Direction.right;
                }
            }

            return direction;
        }

        public void Update()
        {
            //Link on Enemy Collisions
            foreach (KeyValuePair<IEnemy, Rectangle> pair in collisionManager.enemies)
            {
                if (pair.Key.GetType() == typeof(EnemyAquamentus))
                {
                    if (collisionManager.link.collisionRectangle.Intersects(((EnemyAquamentus)pair.Key).collisionRectangle))
                    {
                        collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(collisionManager.link, pair.Key, CollisionDirection(collisionManager.link.collisionRectangle, pair.Value)));
                    }
                }
                else if (pair.Key.GetType() == typeof(BladeTrap))
                {
                    if (collisionManager.link.collisionRectangle.Intersects(((BladeTrap)pair.Key).collisionRectangle))
                    {
                        collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(collisionManager.link, pair.Key, CollisionDirection(collisionManager.link.collisionRectangle, pair.Value)));
                    }
                }
                else if (pair.Key.GetType() == typeof(EnemyGel))
                {
                    if (collisionManager.link.collisionRectangle.Intersects(((EnemyGel)pair.Key).collisionRectangle))
                    {
                        collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(collisionManager.link, pair.Key, CollisionDirection(collisionManager.link.collisionRectangle, pair.Value)));
                    }
                }
                else if (pair.Key.GetType() == typeof(EnemyGoriya))
                {
                    if (collisionManager.link.collisionRectangle.Intersects(((EnemyGoriya)pair.Key).CollisionRectangle))
                    {
                        collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(collisionManager.link, pair.Key, CollisionDirection(collisionManager.link.collisionRectangle, pair.Value)));
                    }
                }
                else if (pair.Key.GetType() == typeof(EnemyKeese))
                {
                    if (collisionManager.link.collisionRectangle.Intersects(((EnemyKeese)pair.Key).collisionRectangle))
                    {
                        collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(collisionManager.link, pair.Key, CollisionDirection(collisionManager.link.collisionRectangle, pair.Value)));
                    }
                }
                else if (pair.Key.GetType() == typeof(EnemyStalfos))
                {
                    if (collisionManager.link.collisionRectangle.Intersects(((EnemyStalfos)pair.Key).collisionRectangle))
                    {
                        collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(collisionManager.link, pair.Key, CollisionDirection(collisionManager.link.collisionRectangle, pair.Value)));
                    }
                }
                else if (pair.Key.GetType() == typeof(EnemyWallmaster))
                {
                    if (collisionManager.link.collisionRectangle.Intersects(((EnemyWallmaster)pair.Key).collisionRectangle))
                    {
                        collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(collisionManager.link, pair.Key, CollisionDirection(collisionManager.link.collisionRectangle, pair.Value)));
                    }
                }
            }
            foreach (KeyValuePair<ITile, Rectangle> pair in collisionManager.walls)
            {
                /*if (pair.Key.GetType() == typeof(Wall))
                {
                }


                else if (pair.Key.GetType() == typeof(DungeonWall))
                {
                }*/
            }
        }
    }
}
