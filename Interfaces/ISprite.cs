using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0
{
    public interface ISprite
    {
        void Update();

        void Draw(Vector2 drawLocation);
    }
}
