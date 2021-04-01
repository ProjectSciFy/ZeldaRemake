using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public interface IGameState
    {
        void Update();

        void UpdateCollisions();
        void Draw();
    }
}
