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
            state.weaponSelected = weapon;
        }
    }
}
