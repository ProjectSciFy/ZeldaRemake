using CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CSE3902_Game_Sprint0.Classes.Controllers
{
    class ItemSelectionController : IController
    {
        readonly Dictionary<int, ICommand> keyBinds = new Dictionary<int, ICommand>();
        private ZeldaGame game { get; set; }
        private readonly LinkStateMachine linkState;

        public ItemSelectionController(ZeldaGame game)
        {
            this.game = game;
            keyBinds.Add(0, new ShutDownGame(game));
            linkState = game.linkStateMachine;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                keyBinds[0].Execute();
            }
            if (mouseState.LeftButton == ButtonState.Pressed && !game.util.keyPressedTempVariable)
            {
                float ValueX = mouseState.X;
                float ValueY = mouseState.Y;
                float Xscalar = 8 * game.util.spriteScalar;
                float Yscalar = 16 * game.util.spriteScalar;
                if (ValueX > (game.util.topPos.X + 390) && ValueX < (game.util.topPos.X + 390 + Xscalar) && ValueY > (game.util.topPos.Y + 144) && ValueY < game.util.topPos.Y + 144 + Yscalar)
                {
                    new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.bomb).Execute();
                }
                if (ValueX > (game.util.topPos.X + 460) && ValueX < (game.util.topPos.X + 460 + Xscalar) && ValueY > (game.util.topPos.Y + 144) && ValueY < game.util.topPos.Y + 144 + Yscalar)
                {
                    new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.boomerang).Execute();
                }
                if (ValueX > (game.util.topPos.X + 530) && ValueX < (game.util.topPos.X + 530 + Xscalar) && ValueY > (game.util.topPos.Y + 144) && ValueY < game.util.topPos.Y + 144 + Yscalar)
                {
                    new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.arrow).Execute();
                }
            }
        }
    }
}
