using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Collisions;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collision
{
    public class CollisionManager
    {
        public CollisionChecker collisionChecker { get; set; }
        public CollisionHandler collisionHandler { get; set; }
        public HashSet<Tuple<Object, Object, Collision.Direction>> collisionSet = new HashSet<Tuple<Object, Object, Collision.Direction>>();

        public void ClearNotLink()
        {
            HashSet<ICollisionEntity> deleteSet = new HashSet<ICollisionEntity>();

            foreach (KeyValuePair<ICollisionEntity, Rectangle> pair in collisionEntities)
            {
                if (!(pair.Key is Link))
                {
                    deleteSet.Add(pair.Key);
                }
            }

            foreach (ICollisionEntity mask in deleteSet)
            {
                collisionEntities.Remove(mask);
            }

            deleteSet.Clear();
        }
        public Dictionary<ICollisionEntity, Rectangle> collisionEntities = new Dictionary<ICollisionEntity, Rectangle>();
        public CollisionManager()
        {
            collisionChecker = new CollisionChecker(this);
            collisionHandler = new CollisionHandler(this);
        }

        public void Update()
        {
            collisionChecker.Update();
            collisionHandler.Update();
        }
    }
}
