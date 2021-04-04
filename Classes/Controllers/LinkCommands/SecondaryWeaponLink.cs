using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class SecondaryWeaponLink : ICommand
    {
        private LinkStateMachine linkState;
        private LinkStateMachine.Weapon weaponSelected;

        public SecondaryWeaponLink(LinkStateMachine linkState)
        {
            this.linkState = linkState;
        }
        public void Execute()
        {
            this.weaponSelected = linkState.weaponSelected;
            // need to update link's state so that corresponding animation is drawn.
            switch (weaponSelected)
            {
                case LinkStateMachine.Weapon.bomb:
                    linkState.useBomb = true;
                    break;

                case LinkStateMachine.Weapon.arrow:
                    linkState.useArrow = true;
                    break;

                case LinkStateMachine.Weapon.boomerang:
                    linkState.useBoomerang = true;
                    break;
            }
        }
    }
}
