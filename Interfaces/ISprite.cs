using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0
{
    public interface ISprite
    {
        void Update();

        void Draw(Vector2 drawLocation);
    }
}
