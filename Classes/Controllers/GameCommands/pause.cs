namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class Pause : ICommand
    {
        private ZeldaGame game { get; set; }
        public Pause(ZeldaGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.util.paused = !game.util.paused;
        }
    }
}