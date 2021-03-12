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
    public class LinkBoomerang : IProjectile
    {
        public EeveeSim game;
        public Link link;
        public LinkStateMachine linkState;
        
        public EnemySpriteFactory spriteFactory;
        public ISprite mySprite;
        public LinkBoomerangStateMachine myState;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2 (0, 0);
        public bool newItem;
        public Vector2 trajectory = new Vector2(0, 0);

        public LinkBoomerang(EeveeSim game, Link link, LinkStateMachine linkState)
        {
            this.game = game;
            this.link = link;
            this.linkState = linkState;
            this.spriteFactory = game.enemySpriteFactory;
            this.drawLocation = link.drawLocation;
            this.spawnLocation = link.drawLocation;
            this.myState = new LinkBoomerangStateMachine(this);
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();
            linkState.Update();

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
