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
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.GameState;
using Microsoft.Xna.Framework.Media;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands
{
    public class Reset : ICommand
    {
        private static int CENTER { get; set; } = 24;
        private int Y_ADJUST { get; set; } = 0;

        private ZeldaGame game { get; set; }

        private Vector2 linkLocation;

        public Reset(ZeldaGame game)
        {
            this.game = game;
            linkLocation = game.link.drawLocation;
            this.Y_ADJUST = (game.GraphicsDevice.Viewport.Bounds.Height / 4) - 2 * CENTER;
        }

        public void Execute()
        {
            //RESET MUSIC
            MediaPlayer.Play(game.song);
            MediaPlayer.IsRepeating = true;

            //RESET LINK
            game.link.drawLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - CENTER, (game.GraphicsDevice.Viewport.Bounds.Height / 2) + Y_ADJUST);
            game.link.linkState.ChangeDirection(LinkStateMachine.Direction.down);
            game.linkStateMachine.Idle();
            game.link.linkState.timer = 0;

            //RESET HUD
            game.util.numLives = 3;
            game.util.numXP = 0;
            game.util.numKeys = 0;
            game.util.numBrups = 0;
            game.util.numYrups = 0;
            game.util.hasMap = false;
            game.util.hasCompass = false;
            game.util.linkInd = true;

            //RE-PARSE ROOMS HERE
            game.collisionManager.ClearNotLink();
            game.projectileHandler.Clear();
            game.roomList = new List<Room>();
            game.util.roomNumber = 2;
            for (int i = 1; i < 19; i++)
            {
                game.roomList.Add(Parser.ParseRoomCSV(game, i));
            }
            game.currentRoom = game.roomList[1];
            
            game.currentRoom.Initialize();
            game.currentMainGameState = new MainState(game, game.currentRoom);
            game.currentGameState = game.currentMainGameState;
        }
    }
}
