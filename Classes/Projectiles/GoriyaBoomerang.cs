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
        public EnemyGoriya goriya { get; protected set; }
        public GoriyaStateMachine goriyaState { get; protected set; }
        public EnemySpriteFactory spriteFactory { get; protected set; }
        public ISprite mySprite { protected get; set; }
        public GoriyaBoomerangStatemachine myState { get; set; }
        public Vector2 drawLocation { get; set; }
        public Vector2 SpawnLocation { get; set; }
        public Vector2 velocity { get; set; } = new Vector2 (0,0);
        public Vector2 spriteSize { get; set; }  = new Vector2(16, 16);
        public bool newItem { get; set; }
        public Vector2 trajectory { get; set; } = new Vector2(0, 0);

        public GoriyaBoomerang(ZeldaGame game, EnemyGoriya goriya, GoriyaStateMachine goriyaState)
        {
            this.game = game;
            this.goriya = goriya;
            this.goriyaState = goriyaState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = goriya.drawLocation;
            this.SpawnLocation = goriya.drawLocation;
            this.myState = new GoriyaBoomerangStatemachine(this);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();
            goriyaState.Update();

            //Update position of boomerang
            drawLocation = drawLocation + velocity;

        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
