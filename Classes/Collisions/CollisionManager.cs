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
        public ZeldaGame game;
        public CollisionChecker collisionChecker;
        public CollisionHandler collisionHandler;

        public HashSet<Tuple<Object, Object, Collision.Direction>> collisionSet = new HashSet<Tuple<Object, Object, Collision.Direction>>();

        public Link link;
        //public KeyValuePair<Link, Rectangle> link;
        public Dictionary<IEnemy, Rectangle> enemies = new Dictionary<IEnemy, Rectangle>();
        public Dictionary<IProjectile, Rectangle> projectiles = new Dictionary<IProjectile, Rectangle>();
        public Dictionary<ITile, Rectangle> walls = new Dictionary<ITile, Rectangle>();

        public CollisionManager(ZeldaGame game)
        {
            this.game = game;
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
