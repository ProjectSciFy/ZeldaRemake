using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class LinkSpriteFactory
    {
        private EeveeSim game;
        private Link link;
        private Texture2D linkTexture;
        private Rectangle spriteIndex;

        public LinkSpriteFactory(EeveeSim game, Link link)
        {
            this.game = game;
            linkTexture = this.game.Content.Load<Texture2D>("NES - The Legend of Zelda - Link");
            this.link = link;
        }
        
        public void IdleUp()
        {
            spriteIndex = new Rectangle(69, 11, 16, 16);
            link.LinkSprite = new StaticSprite(game, linkTexture, link.drawLocation, link.velocity = new Vector2(0, 0), spriteIndex, Color.White);
        }
    }
}
