namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    class DamagedLink : ICommand
    {
        private LinkStateMachine linkState { get; set; }

        public DamagedLink(LinkStateMachine linkState)
        {
            this.linkState = linkState;
        }
        public void Execute()
        {
            linkState.isDamaged = true;
        }
    }
}
