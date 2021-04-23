using CSE3902_Game_Sprint0.Classes.GameState;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class Select : ICommand
    {
        private ZeldaGame game { get; set; }
        public Select(ZeldaGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.util.selectSpeed *= -1;
            game.currentGameState = new ItemSelectState(game);
        }
    }
}