using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class GoriyaBoomerang
    {
        public EeveeSim game;
        public EnemyGoriya goriya = null;
        public GoriyaStateMachine goriyaState = null;
        public EnemySpriteFactory spriteFactory;
        public ISprite mySprite;
        public GoriyaBoomerangStatemachine myState;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public bool newItem;
        public Vector2 trajectory = new Vector2(0, 0);


        public GoriyaBoomerang(EeveeSim game, EnemyGoriya goriya, GoriyaStateMachine goriyaState)
        {
            this.game = game;
            this.goriya = goriya;
            this.goriyaState = goriyaState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = goriya.drawLocation;
            this.spawnLocation = goriya.drawLocation;
            this.myState = new GoriyaBoomerangStatemachine(this);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();
            goriyaState.Update();

            //Update position of boomerang
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;

        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
