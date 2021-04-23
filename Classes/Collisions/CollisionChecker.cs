using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace CSE3902_Game_Sprint0.Classes.Collision
{
    public class CollisionChecker
    {
        public CollisionManager collisionManager { get; set; }

        public CollisionChecker(CollisionManager collisionManager)
        {
            this.collisionManager = collisionManager;
        }

        private Collision.Direction CollisionDirection(Rectangle entity1, Rectangle entity2)
        {
            Rectangle collisionRectangle = Rectangle.Intersect(entity1, entity2);
            Collision.Direction direction = Collision.Direction.none;
            if (collisionRectangle.Width > collisionRectangle.Height) {
                if (collisionRectangle.Y == entity1.Y) direction = Collision.Direction.up;
                else direction = Collision.Direction.down;
            }
            else if (collisionRectangle.Height >= collisionRectangle.Width) {
                if (collisionRectangle.X == entity1.X) direction = Collision.Direction.left;
                else direction = Collision.Direction.right;
            }
            return direction;
        }

        public void Update()
        {
            foreach (KeyValuePair<ICollisionEntity, Rectangle> entity1 in collisionManager.collisionEntities) {
                foreach (KeyValuePair<ICollisionEntity, Rectangle> entity2 in collisionManager.collisionEntities) {
                    if (!entity1.Equals(entity2)){
                        if (entity1.Value.Intersects(entity2.Value)) {
                            collisionManager.collisionSet.Add(new Tuple<object, object, Collision.Direction>(entity1.Key, entity2.Key, CollisionDirection(entity1.Value, entity2.Value)));
                        }
                    }
                }
            }
        }
    }
}
