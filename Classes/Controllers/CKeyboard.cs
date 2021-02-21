using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes.Controllers.BlockCommands;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0
{
    public class CKeyboard : IController
    {
        private StateMachine linkState;
        Dictionary<Keys, ICommand> keyBinds = new Dictionary<Keys, ICommand>();
        HashSet<Keys> heldKeys = new HashSet<Keys>();
        Dictionary<Keys, int> movementKeys = new Dictionary<Keys, int>();

       
        public CKeyboard(EeveeSim game)
        {

            linkState = game.linkStateMachine;

            //Change commands in future--

            //Up and W -- change direction (switch case/state machine?) and movement
            // direction added as new parameter being sent to DrawSprite:
            keyBinds.Add(Keys.Up, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2)), new Vector2(0, 0), new Rectangle(21, 0, 21, 24), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.W, new MoveLink(linkState, StateMachine.Direction.up));

            //Left and A
            keyBinds.Add(Keys.Left, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.A, new MoveLink(linkState, StateMachine.Direction.left));

            //Down and S
            keyBinds.Add(Keys.Down, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.S, new MoveLink(linkState, StateMachine.Direction.down));

            //Right and D
            keyBinds.Add(Keys.Right, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.D, new MoveLink(linkState, StateMachine.Direction.right));

            //Z and N -- attack and animation
            keyBinds.Add(Keys.Z, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.N, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //E -- test damage taken animation
            keyBinds.Add(Keys.E, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));

            //1, 2, 3, 4 -- change between items animation
            keyBinds.Add(Keys.D1, new ItemLink(linkState, StateMachine.Item.sword, linkState.direction)); // sword item
            keyBinds.Add(Keys.D2, new ItemLink(linkState, StateMachine.Item.bomb, linkState.direction)); // bomb item 
            keyBinds.Add(Keys.D3, new ItemLink(linkState, StateMachine.Item.arrow, linkState.direction)); // bow & arrow item 
            keyBinds.Add(Keys.D4, new ItemLink(linkState, StateMachine.Item.boomerang, linkState.direction)); // boomerang item 

            //T and Y -- test block animation
            keyBinds.Add(Keys.T, new DecrementBlock(game.tileSpriteFactory));
            keyBinds.Add(Keys.Y, new IncrementBlock(game.tileSpriteFactory));

            //U and I -- cycle through items
            keyBinds.Add(Keys.U, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.I, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //O and P -- test other characters/NPCs animation (cycles through sprites)
            keyBinds.Add(Keys.O, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.P, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //Q -- quit game
            keyBinds.Add(Keys.Q, new ShutDownGame(game));
            //R -- reset game to initial state
            keyBinds.Add(Keys.R, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            //Set of all keys released on this update (begins as copy of keys held down)
            HashSet<Keys> releasedKeys = new HashSet<Keys>(heldKeys);
            //Array of all keys pressed this update
            Keys[] pressedKeys = keyState.GetPressedKeys();
            int lastMoveKeyCount = movementKeys.Count;

            //For every key pressed on this update-
            for (int i = 0; i < pressedKeys.Length; i++)
            {
                //Removing keys being held still from the releasedKeys set
                releasedKeys.Remove(pressedKeys[i]);

                //If there is a keyBind for the currently pressed key && it is not in heldKeys set (as in, it has not already been executed), execute the associated command & add the key to heldKeys
                if (keyBinds.ContainsKey(pressedKeys[i]) && !heldKeys.Contains(pressedKeys[i]))
                {
                   keyBinds[pressedKeys[i]].Execute();
                    heldKeys.Add(pressedKeys[i]);

                    //If any movement key is being pressed, add it to movementKeys & incrememt key priority of all entries by 1
                    if (pressedKeys[i] == Keys.W || pressedKeys[i] == Keys.A || pressedKeys[i] == Keys.S || pressedKeys[i] == Keys.D)
                    {
                        movementKeys.Add(pressedKeys[i], 0);

                        if (movementKeys.ContainsKey(Keys.W))
                        {
                            movementKeys[Keys.W] = movementKeys[Keys.W] + 1;
                        }
                        if (movementKeys.ContainsKey(Keys.A))
                        {
                            movementKeys[Keys.A] = movementKeys[Keys.A] + 1;
                        }
                        if (movementKeys.ContainsKey(Keys.S))
                        {
                            movementKeys[Keys.S] = movementKeys[Keys.S] + 1;
                        }
                        if (movementKeys.ContainsKey(Keys.D))
                        {
                            movementKeys[Keys.D] = movementKeys[Keys.D] + 1;
                        }
                    }
                }
            }

            //For each key released on this update, remove it from heldKeys set
            foreach (Keys releasedKey in releasedKeys)
            {
                heldKeys.Remove(releasedKey);
                
                //If a movement key has been removed, raise priority of all keys with lower priority than the removed key
                if (movementKeys.ContainsKey(releasedKey))
                {
                    int movePriority = movementKeys[releasedKey];

                    if (movementKeys.ContainsKey(Keys.W) && movementKeys[Keys.W] > movePriority)
                    {
                        movementKeys[Keys.W] = movementKeys[Keys.W] - 1;
                    }
                    if (movementKeys.ContainsKey(Keys.A) && movementKeys[Keys.A] > movePriority)
                    {
                        movementKeys[Keys.A] = movementKeys[Keys.A] - 1;
                    }
                    if (movementKeys.ContainsKey(Keys.S) && movementKeys[Keys.S] > movePriority)
                    {
                        movementKeys[Keys.S] = movementKeys[Keys.S] - 1;
                    }
                    if (movementKeys.ContainsKey(Keys.D) && movementKeys[Keys.D] > movePriority)
                    {
                        movementKeys[Keys.D] = movementKeys[Keys.D] - 1;
                    }

                    movementKeys.Remove(releasedKey);
                }
            }

            //If a direction is being moved in, adjust link's direction & "queue" if a movement key has been released
            if (movementKeys.Count > 0)
            {
                int newMoveKeyCount = movementKeys.Count;
                Keys currentMoveKey;

                if (movementKeys.ContainsKey(Keys.W) && movementKeys[Keys.W] == 1)
                {
                    currentMoveKey = Keys.W;
                }
                else if (movementKeys.ContainsKey(Keys.A) && movementKeys[Keys.A] == 1)
                {
                    currentMoveKey = Keys.A;
                }
                else if (movementKeys.ContainsKey(Keys.S) && movementKeys[Keys.S] == 1)
                {
                    currentMoveKey = Keys.S;
                }
                else
                {
                    currentMoveKey = Keys.D;
                }
                
                //We need to execute a new movement ONCE, to handle this we only execute a new direction when the movement keys decreases
                if (newMoveKeyCount < lastMoveKeyCount)
                {
                    keyBinds[currentMoveKey].Execute();
                }
            }
            else
            {
                //New Idle command
                new IdleLink(linkState).Execute();
            }
        }
    }
}
