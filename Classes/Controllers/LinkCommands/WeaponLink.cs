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
                    linkState.weaponSelected = LinkStateMachine.Weapon.sword;
                    linkState.Sword();
                    break;

                case LinkStateMachine.Weapon.bomb:
                    linkState.weaponSelected = LinkStateMachine.Weapon.bomb;
                    linkState.Bomb();
                    break;

                case LinkStateMachine.Weapon.arrow:
                    linkState.weaponSelected = LinkStateMachine.Weapon.arrow;
                    linkState.Arrow();
                    break;

                case LinkStateMachine.Weapon.boomerang:
                    linkState.weaponSelected = LinkStateMachine.Weapon.boomerang;
                    linkState.Boomerang();
                    break;
            }
        }
    }
}
