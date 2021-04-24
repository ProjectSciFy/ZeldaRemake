using Microsoft.Xna.Framework.Media;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands.ResetUtility
{
    public class ResetMusic : ICommand
    {
        private readonly ZeldaGame game;
        public ResetMusic(ZeldaGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            MediaPlayer.Play(game.song);
            MediaPlayer.IsRepeating = true;
        }
    }
}
