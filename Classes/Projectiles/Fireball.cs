using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Fireball : IProjectile
    {
        private ZeldaGame game;
        private EnemyAquamentus aquamentus;
        private AquamentusStateMachine aquamentusState;
        public EnemySpriteFactory spriteFactory { get; set; }
        private FireballStateMachine myState;
        private ISprite mySprite;
        private Vector2 drawLocation;
        private Vector2 velocity = new Vector2(0, 0);
        private Vector2 spriteSize = new Vector2(0, 0);
        private Vector2 trajectory;
        private bool newItem = true;
        
        public Fireball(ZeldaGame game, EnemyAquamentus aquamentus, AquamentusStateMachine aquamentusState, Vector2 trajectory)
        {
            this.game = game;
            this.aquamentus = aquamentus;
            this.aquamentusState = aquamentusState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = aquamentus.drawLocation;
            this.myState = new FireballStateMachine(this);
            this.trajectory = trajectory;
        }
        public void Update()
        {
            myState.Update();
            aquamentusState.Update();
            mySprite.Update();

            drawLocation = drawLocation + velocity;
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
