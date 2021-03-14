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
        private ZeldaGame game;
        public Link link { get; protected set; }
        public LinkStateMachine linkState { get; protected set; }

        public EnemySpriteFactory spriteFactory { get; protected set; }
        public ISprite mySprite { protected get; set; }
        public LinkBoomerangStateMachine myState { get; protected set; }
        public Vector2 drawLocation { get; set; }
        public Vector2 spawnLocation { get; set; }
        public Vector2 velocity { get; set; } = new Vector2(0, 0);
        public Vector2 spriteSize { get; set; } = new Vector2(0, 0);
        public bool newItem { get; set; }
        public Vector2 trajectory { get; set; } = new Vector2(0, 0);

        public LinkBoomerang(ZeldaGame game, Link link, LinkStateMachine linkState)
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
            drawLocation = drawLocation + velocity;
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }

    }
}
