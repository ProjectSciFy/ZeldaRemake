using CSE3902_Game_Sprint0.Classes._21._2._13;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class EnemyOnLink : ICommand
    {
        private IEnemy enemy { get; set; }
        private Link link { get; set; }
        private Collision.Collision.Direction direction { get; set; }

        public EnemyOnLink(IEnemy enemy, Link link, Collision.Collision.Direction direciton)
        {
            this.enemy = enemy;
            this.link = link;
            this.direction = direciton;
        }

        public void Execute()
        {
            switch (link.linkState.currentState)
            {
                case (LinkStateMachine.CurrentState.swordDown):
                    enemy.TakeDamage(1 + (link.game.util.numXP / link.game.util.XPPerLevel));
                    break;
                case LinkStateMachine.CurrentState.swordLeft:
                    enemy.TakeDamage(1 + (link.game.util.numXP / link.game.util.XPPerLevel));
                    break;
                case LinkStateMachine.CurrentState.swordRight:
                    enemy.TakeDamage(1 + (link.game.util.numXP / link.game.util.XPPerLevel));
                    break;
                case LinkStateMachine.CurrentState.swordUp:
                    enemy.TakeDamage(1 + (link.game.util.numXP / link.game.util.XPPerLevel));
                    break;
                default:
                    break;
            }
        }
    }
}
