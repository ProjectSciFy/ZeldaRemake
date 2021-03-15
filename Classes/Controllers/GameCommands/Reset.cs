using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Controllers;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class Reset : ICommand
    {
        private ZeldaGame game;
        private LinkStateMachine linkState;
        private LinkStateMachine.Direction direction;
        private LinkStateMachine.Weapon weaponSelected;
        private bool moving;
        private bool useSword;
        private bool useBomb;
        private bool useArrow;
        private bool useBoomerang;
        private bool isDamaged;

        private Vector2 linkLocation;

        private ZeldaGame.Enemies currentEnemy;
        private IEnemy drawnEnemy;

        public Reset(ZeldaGame game)
        {
            this.game = game;
            linkState = game.linkStateMachine;
            direction = game.linkStateMachine.direction;
            weaponSelected = game.linkStateMachine.weaponSelected;
            moving = game.linkStateMachine.moving;
            useSword = game.linkStateMachine.useSword;
            useBomb = game.linkStateMachine.useBomb;
            useArrow = game.linkStateMachine.useArrow;
            useBoomerang = game.linkStateMachine.useBoomerang;
            isDamaged = game.linkStateMachine.isDamaged;

            linkLocation = game.link.drawLocation;
        }

        public void Execute()
        {
            this.direction = linkState.direction;
            this.weaponSelected = linkState.weaponSelected;
            this.moving = linkState.moving;
            this.useSword = linkState.useSword;
            this.useBomb = linkState.useBomb;
            this.useArrow = linkState.useArrow;
            this.useBoomerang = linkState.useBoomerang;
            this.isDamaged = linkState.isDamaged;
            linkState.direction = LinkStateMachine.Direction.down;
            linkState.weaponSelected = LinkStateMachine.Weapon.none;
            linkState.moving = false;
            linkState.useSword = false;
            linkState.useBomb = false;
            linkState.useArrow = false;
            linkState.useBoomerang = false;
            linkState.isDamaged = false;
            this.direction = LinkStateMachine.Direction.down;
            this.weaponSelected = LinkStateMachine.Weapon.none;
            this.moving = false;
            this.useSword = false;
            this.useBomb = false;
            this.useArrow = false;
            this.useBoomerang = false;
            this.isDamaged = false;

            this.linkLocation = game.link.drawLocation;
            game.link.drawLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2));
            this.linkLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2));
        }
    }
}
