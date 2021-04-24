using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands.ResetUtility
{
    public class ResetLink : ICommand
    {
        private int Y_ADJUST { get; set; } = 0;
        private readonly ZeldaGame game;
        public ResetLink(ZeldaGame game)
        {
            this.game = game;
            this.Y_ADJUST = (game.GraphicsDevice.Viewport.Bounds.Height / 4) - 2 * ResetHelper.CENTER;
        }

        public void Execute()
        {
            game.link.drawLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - ResetHelper.CENTER, (game.GraphicsDevice.Viewport.Bounds.Height / 2) + Y_ADJUST);
            game.link.linkState.ChangeDirection(LinkStateMachine.Direction.down);
            game.linkStateMachine.Idle();
            game.link.linkState.timer = 0;
            game.link.linkState.isGrabbed = false;
        }
    }
}
