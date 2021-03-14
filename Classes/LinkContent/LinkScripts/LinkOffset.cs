using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class LinkOffset : ICommand
    {
        private Link link;
        private Vector2 drawOffset;
        private bool reverse;
        public LinkOffset(Link link, bool reverse)
        {
            this.link = link;
            this.drawOffset = link.drawOffset;
            this.reverse = reverse;
        }

        public void Execute()
        {
            if (reverse)
            {
                link.drawLocation.X = link.drawLocation.X - drawOffset.X;
                link.drawLocation.Y = link.drawLocation.Y - drawOffset.Y;
            }
            else
            {
                link.drawLocation.X = link.drawLocation.X + drawOffset.X;
                link.drawLocation.Y = link.drawLocation.Y + drawOffset.Y;
            }
        }
    }
}
