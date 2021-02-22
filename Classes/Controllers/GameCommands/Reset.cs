using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes.Controllers.TileCommands;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Controllers.ItemCommands;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.NewBlocks;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class Reset : ICommand
    {
        private EeveeSim game;

        private ItemStateMachine itemStateMachine;
        private ItemStateMachine.ItemType currentItem;

        private TileStateMachine tileStateMachine;
        private TileStateMachine.TileType currentTile;

        private LinkStateMachine linkState;
        private LinkStateMachine.Direction direction;
        private LinkStateMachine.Weapon weaponSelected;
        private bool moving;

        private Vector2 linkLocation;

        public Reset(EeveeSim game)
        {
            this.game = game;

            itemStateMachine = game.itemStateMachine;
            currentItem = game.itemStateMachine.currentState;

            tileStateMachine = game.tileStateMachine;
            currentTile = game.tileStateMachine.currentState;

            linkState = game.linkStateMachine;
            direction = game.linkStateMachine.direction;
            weaponSelected = game.linkStateMachine.weaponSelected;
            moving = game.linkStateMachine.moving;

            linkLocation = game.link.drawLocation;
        }

        public void Execute()
        {
            this.currentItem = itemStateMachine.currentState;
            itemStateMachine.currentState = ItemStateMachine.ItemType.Heart;
            this.currentItem = ItemStateMachine.ItemType.Heart;

            this.currentTile = tileStateMachine.currentState;
            tileStateMachine.currentState = TileStateMachine.TileType.Wall;
            this.currentTile = TileStateMachine.TileType.Wall;

            this.direction = linkState.direction;
            this.weaponSelected = linkState.weaponSelected;
            this.moving = linkState.moving;
            linkState.direction = LinkStateMachine.Direction.down;
            linkState.weaponSelected = LinkStateMachine.Weapon.none;
            linkState.moving = false;
            this.direction = LinkStateMachine.Direction.down;
            this.weaponSelected = LinkStateMachine.Weapon.none;
            this.moving = false;

            this.linkLocation = game.link.drawLocation;
            game.link.drawLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2));
            this.linkLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2));


        }
    }
}
