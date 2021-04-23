using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;
using CSE3902_Game_Sprint0.Classes.Enemy.Redead;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class LinkOnEnemy : ICommand
    {
        private Link link { get; set; }
        private IEnemy enemy { get; set; }
        private Collision.Collision.Direction direction { get; set; }

        public LinkOnEnemy(Link link, IEnemy enemy, Collision.Collision.Direction direction)
        {
            this.link = link;
            this.enemy = enemy;
            this.direction = direction;
        }

        public void Execute()
        {
            if (enemy is EnemyRedead && ((EnemyRedead)enemy).myState.idle)
            {
                link.linkState.timer = 0;
                link.linkState.Idle();
                link.linkState.timer = 120;
                new LinkOffset(link, true).Execute();
                link.drawOffset.X = 0; link.drawOffset.Y = 0;
                ((EnemyRedead)enemy).myState.idle = false;
                ((EnemyRedead)enemy).myState.shriekTimer = 360;
                ((EnemyRedead)enemy).game.sounds["redeadScream"].CreateInstance().Play();
            }
            if (link.linkState.timer <= 0) link.linkState.isDamaged = true;
            if (enemy is EnemyWallmaster)
            {
                if (link.linkState.timer <= 0 && !(link.linkState.isGrabbed))
                {
                    link.drawLocation = ((EnemyWallmaster)enemy).drawLocation;
                    link.linkState.isGrabbed = true;
                    link.linkState.Idle();
                    link.linkState.timer = 96;
                }
                else if (link.linkState.timer <= 0) { new Reset(link.game).Execute(); link.linkState.isGrabbed = false; }
                else if (link.linkState.isGrabbed)
                {
                    link.drawLocation = ((EnemyWallmaster)enemy).drawLocation;
                    link.linkState.currentState = LinkStateMachine.CurrentState.grabbed;
                    link.linkState.Idle();
                }
            }
        }
    }
}
