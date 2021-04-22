using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class SecondaryWeaponSelect : ICommand
    {
        private LinkStateMachine state { get; set; }
        private LinkStateMachine.Weapon weapon { get; set; }
        public SecondaryWeaponSelect(LinkStateMachine state, LinkStateMachine.Weapon weapon)
        {
            this.state = state;
            this.weapon = weapon;
        }
        public void Execute() 
        {
            //switch (weapon)
            //{
            //    case LinkStateMachine.Weapon.bomb:
            //        state.weaponSelected = weapon;
            //        break;
            //    case LinkStateMachine.Weapon.boomerang:
            //        state.weaponSelected = weapon;
            //        break;
            //    case LinkStateMachine.Weapon.arrow:
            //        if (state.useArrow)
            //        {
            //            state.weaponSelected = weapon;
            //        }
            //        break;

            //}
            state.weaponSelected = weapon;
        }
    }
}
