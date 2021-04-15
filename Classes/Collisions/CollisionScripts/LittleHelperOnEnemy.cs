using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.Redead;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class LittleHelperOnEnemy : ICommand
    {
        private LittleHelper.LittleHelper littleHelper;
        private IEnemy enemy;
        private Collision.Collision.Direction direction;
        public LittleHelperOnEnemy(LittleHelper.LittleHelper littleHelper, IEnemy enemy, Collision.Collision.Direction direction)
        {
            this.littleHelper = littleHelper;
            this.enemy = enemy;
            this.direction = direction;
        }

        public void Execute()
        {
            if (enemy is EnemyAquamentus)
            {
                littleHelper.myState.interacting = true;
                ((EnemyAquamentus)enemy).velocity = new Vector2(0, 0);
            }
            else if (enemy is EnemySlime)
            {
                littleHelper.myState.interacting = true;
                ((EnemySlime)enemy).velocity = new Vector2(0, 0);
            }
            else if (enemy is EnemyGoriya)
            {
                littleHelper.myState.interacting = true;
                ((EnemyGoriya)enemy).velocity = new Vector2(0, 0);
            }
            else if (enemy is EnemyKeese)
            {
                littleHelper.myState.interacting = true;
                ((EnemyKeese)enemy).velocity = new Vector2(0, 0);
            }
            else if (enemy is EnemyRedead)
            {
                littleHelper.myState.interacting = true;
                ((EnemyRedead)enemy).velocity = new Vector2(0, 0);
            }
            else if (enemy is EnemyStalfos)
            {
                littleHelper.myState.interacting = true;
                ((EnemyStalfos)enemy).velocity = new Vector2(0, 0);
            }
            else if (enemy is EnemyWallmaster)
            {
                littleHelper.myState.interacting = true;
                ((EnemyWallmaster)enemy).velocity = new Vector2(0, 0);
            }
        }
    }
}
