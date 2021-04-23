namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public interface IGameState
    {
        void Update();

        void UpdateCollisions();
        void Draw();
    }
}
