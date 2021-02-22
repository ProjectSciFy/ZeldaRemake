using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class WeaponLink : ICommand
    {
        private LinkStateMachine linkState;
        private LinkStateMachine.Weapon weaponSelected;
        private LinkStateMachine.Direction direction;

        public WeaponLink(LinkStateMachine linkState, LinkStateMachine.Weapon weapon, LinkStateMachine.Direction direction)
        {
            this.linkState = linkState;
            this.weaponSelected = weapon;
            this.direction = direction;
        }

        public void Execute()
        { 
            linkState.moving = false;
            // need to update link's state so that corresponding animation is drawn.
            switch (weaponSelected)
            {
                case LinkStateMachine.Weapon.sword:
                    linkState.useSword = true;
                    break;

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
