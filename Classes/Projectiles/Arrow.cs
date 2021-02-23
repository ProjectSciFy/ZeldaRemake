using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Arrow : ISecondaryEntity
    {
        private EeveeSim game;
        private Link link;
        //private Texture2D arrowTexture;
        public ISprite arrowSprite;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        //public Vector2 trajectory;
        private LinkStateMachine linkState;
        public EnemySpriteFactory spriteFactory;
        public enum Direction { right, up, left, down }; // NE = North East
        public Direction direction = Direction.down;

        public Arrow(EeveeSim game)
        {
            this.game = game;
            this.link = game.link;
            this.linkState = game.link.linkState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = link.drawLocation;
            this.spawnLocation = link.drawLocation;
            spriteFactory.ArrowDown(this);
        }
       
        public void Update()
        {
            linkState.Update();
            arrowSprite.Update();
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;
        }

        public void Draw()
        {
            arrowSprite.Draw(drawLocation);
        }
    }
}
