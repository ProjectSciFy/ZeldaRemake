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
        //Created in main
        //Has HashSet for each major object type {Link, enemy, projectile, block, item, etc}
        //Is passed to every object created henceforth so they can add themselves to their respective sets in their constructors, & later to the removeSet when unloaded
        //Has a deletion HashSet, either general with data type "type" that checks for correct typage before removing from a set in all sets when the object is unloaded, or a HashSet for each major object type used for deletion.

        //Update
        //Checks major object types against eachother by use of CollisionChecker
        //If a collision is detected, a tuple is created of the colliding objects & from which direction, then sent to collisionHandler
        //At the end, removeSet clears unloaded entities from respective lists
        public CollisionChecker collisionChecker;
        public CollisionHandler collisionHandler;

        //Set of detected collisions
        public HashSet<Tuple<Object, Object, Collision.Direction>> collisionSet = new HashSet<Tuple<Object, Object, Collision.Direction>>();

        //Link's collision rectangle accessed directly
        public Link link;
        //Dictionary of all enemies & their respective collision rectangle
        public Dictionary<IEnemy, Rectangle> enemies = new Dictionary<IEnemy, Rectangle>();
        //Dictionary of all projectiles & their respective collision rectangle
        public Dictionary<IProjectile, Rectangle> projectiles = new Dictionary<IProjectile, Rectangle>();
        //Dictionary of all Items & their respective collision rectangle
        //Dictionary of all Tiles & their respective collision rectangle
        public Dictionary<ITile, Rectangle> walls = new Dictionary<ITile, Rectangle>();

        //LEGACY ^^^

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

        //Dictionary of all collision entities loaded
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
