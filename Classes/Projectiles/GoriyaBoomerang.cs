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
        private ZeldaGame game;
        private EnemyGoriya goriya;
        private GoriyaStateMachine goriyaState;
        private EnemySpriteFactory spriteFactory;
        private ISprite mySprite;
        private GoriyaBoomerangStatemachine myState;
        private Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public bool newItem;
        public Vector2 trajectory = new Vector2(0, 0);
        public EnemyGoriya Goriya { get { return goriya; } set { goriya = value; } }
        public GoriyaStateMachine GoriyaState { get { return goriyaState; } }
        public ISprite MySprite { set { mySprite = value; } }
        public EnemySpriteFactory SpriteFactory { get { return spriteFactory; } }
        public Vector2 DrawLocation { get { return drawLocation; } set { drawLocation = value; } }

        public GoriyaBoomerang(ZeldaGame game, EnemyGoriya goriya, GoriyaStateMachine goriyaState)
        {
            this.game = game;
            this.goriya = goriya;
            this.goriyaState = goriyaState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = goriya.DrawLocation;
            this.spawnLocation = goriya.DrawLocation;
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
