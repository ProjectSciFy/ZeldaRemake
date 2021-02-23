using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class WeaponLink : ICommand
    {
        private LinkStateMachine linkState;
        private LinkStateMachine.Weapon weaponSelected;
        private BombStateMachine bombState;

        public WeaponLink(LinkStateMachine linkState, LinkStateMachine.Weapon weapon)
        {
            this.linkState = linkState;
            this.weaponSelected = weapon;
        }
        public WeaponLink(BombStateMachine bombState, LinkStateMachine linkState, LinkStateMachine.Weapon weapon)
        {
            this.linkState = linkState;
            this.bombState = bombState;
            this.weaponSelected = weapon;
            this.bombState = bombState;
        }

        public void Execute()
        { 
            // need to update link's state so that corresponding animation is drawn.
            switch (weaponSelected)
            {
                case LinkStateMachine.Weapon.sword:
                    linkState.useSword = true;
                    break;

                case LinkStateMachine.Weapon.bomb:
                    linkState.useBomb = true;
                    bombState.spawning = true;
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
