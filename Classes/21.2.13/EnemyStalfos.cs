using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemyStalfos : IEnemy
    {
        //When defeated, can frop a heart, rupee, 5rupee or a clock
        //Pathing is random, no sense of direction
        //Method of attack is melee, bumping into the player

        public EeveeSim game;
        private EnemyStateMachine myState;
        private EnemySpriteFactory spriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);

        public EnemyStalfos(EeveeSim game, Vector2 spawnLocation)
        {
            this.game = game;
            spriteFactory = game.enemySpriteFactory;
            drawLocation = spawnLocation;
            myState = new EnemyStateMachine(this);
            spawn();
        }

        public void spawn()
        {
            spriteFactory.spawnStalfos(this);
        }

        public void update()
        {

        }

        public void draw()
        {

        }
    }
}
