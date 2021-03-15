using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;
using CSE3902_Game_Sprint0.Classes.Projectiles;

namespace CSE3902_Game_Sprint0
{
    public class CKeyboard : IController
    {
        private LinkStateMachine linkState;
        private BombStateMachine bombState;
        Dictionary<Keys, ICommand> keyBinds = new Dictionary<Keys, ICommand>();
        HashSet<Keys> heldKeys = new HashSet<Keys>();
        Dictionary<Keys, int> movementKeys = new Dictionary<Keys, int>();

       
        public CKeyboard(ZeldaGame game)
        {

            linkState = game.linkStateMachine;
            bombState = game.bombStateMachine;

            //Change commands in future--

            //Up and W -- change direction (switch case/state machine?) and movement
            // direction added as new parameter being sent to DrawSprite:
            keyBinds.Add(Keys.Up, new MoveLink(linkState, LinkStateMachine.Direction.up));
            keyBinds.Add(Keys.W, new MoveLink(linkState, LinkStateMachine.Direction.up));

            //Left and A
            keyBinds.Add(Keys.Left, new MoveLink(linkState, LinkStateMachine.Direction.left));
            keyBinds.Add(Keys.A, new MoveLink(linkState, LinkStateMachine.Direction.left));

            //Down and S
            keyBinds.Add(Keys.Down, new MoveLink(linkState, LinkStateMachine.Direction.down));
            keyBinds.Add(Keys.S, new MoveLink(linkState, LinkStateMachine.Direction.down));

            //Right and D
            keyBinds.Add(Keys.Right, new MoveLink(linkState, LinkStateMachine.Direction.right));
            keyBinds.Add(Keys.D, new MoveLink(linkState, LinkStateMachine.Direction.right));

            //Z and N -- attack animation
            keyBinds.Add(Keys.N, new WeaponLink(bombState, linkState, LinkStateMachine.Weapon.sword)); // sword item
            keyBinds.Add(Keys.Z, new WeaponLink(bombState, linkState, LinkStateMachine.Weapon.sword)); // sword item

            //E -- test damage taken animation
            keyBinds.Add(Keys.E, new DamagedLink(linkState));

            //1, 2, 3, 4 -- change link's current item
            //NEED TO CHANGE FROM USING WEAPON TO SIMPLY CHANGING IT. ALSO NEED TO ADD SWORD CHANGE [Keys.D1]
            keyBinds.Add(Keys.D2, new WeaponLink(linkState, LinkStateMachine.Weapon.bomb)); // bomb item 
            keyBinds.Add(Keys.NumPad2, new WeaponLink(linkState, LinkStateMachine.Weapon.bomb)); // bomb item 
            keyBinds.Add(Keys.D3, new WeaponLink(linkState, LinkStateMachine.Weapon.arrow)); // bow & arrow item 
            keyBinds.Add(Keys.NumPad3, new WeaponLink(linkState, LinkStateMachine.Weapon.arrow)); // bow & arrow item 
            keyBinds.Add(Keys.D4, new WeaponLink(bombState, linkState, LinkStateMachine.Weapon.boomerang)); // boomerang item 
            keyBinds.Add(Keys.NumPad4, new WeaponLink(bombState, linkState, LinkStateMachine.Weapon.boomerang)); // boomerang item 

            //Q -- quit game
            keyBinds.Add(Keys.Q, new ShutDownGame(game));
            //R -- reset game to initial state
            keyBinds.Add(Keys.R, new Reset(game));
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
                    if (pressedKeys[i] == Keys.W || pressedKeys[i] == Keys.A || pressedKeys[i] == Keys.S || pressedKeys[i] == Keys.D || pressedKeys[i] == Keys.Up || pressedKeys[i] == Keys.Left || pressedKeys[i] == Keys.Down || pressedKeys[i] == Keys.Right)
                    {
                        movementKeys.Add(pressedKeys[i], 0);
                        //WASD
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
                        //ARROWS
                        if (movementKeys.ContainsKey(Keys.Up))
                        {
                            movementKeys[Keys.Up] = movementKeys[Keys.Up] + 1;
                        }
                        if (movementKeys.ContainsKey(Keys.Left))
                        {
                            movementKeys[Keys.Left] = movementKeys[Keys.Left] + 1;
                        }
                        if (movementKeys.ContainsKey(Keys.Down))
                        {
                            movementKeys[Keys.Down] = movementKeys[Keys.Down] + 1;
                        }
                        if (movementKeys.ContainsKey(Keys.Right))
                        {
                            movementKeys[Keys.Right] = movementKeys[Keys.Right] + 1;
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
                    //WASD
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
                    //ARROWS
                    if (movementKeys.ContainsKey(Keys.Up) && movementKeys[Keys.Up] > movePriority)
                    {
                        movementKeys[Keys.Up] = movementKeys[Keys.Up] - 1;
                    }
                    if (movementKeys.ContainsKey(Keys.Left) && movementKeys[Keys.Left] > movePriority)
                    {
                        movementKeys[Keys.Left] = movementKeys[Keys.Left] - 1;
                    }
                    if (movementKeys.ContainsKey(Keys.Down) && movementKeys[Keys.Down] > movePriority)
                    {
                        movementKeys[Keys.Down] = movementKeys[Keys.Down] - 1;
                    }
                    if (movementKeys.ContainsKey(Keys.Right) && movementKeys[Keys.Right] > movePriority)
                    {
                        movementKeys[Keys.Right] = movementKeys[Keys.Right] - 1;
                    }

                    movementKeys.Remove(releasedKey);
                }
            }

            //If a direction is being moved in, adjust link's direction & "queue" if a movement key has been released
            if (movementKeys.Count > 0)
            {
                int newMoveKeyCount = movementKeys.Count;
                Keys currentMoveKey;
                //WASD & KEYS
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
                else if (movementKeys.ContainsKey(Keys.D) && movementKeys[Keys.D] == 1)
                {
                    currentMoveKey = Keys.D;
                } 
                else if (movementKeys.ContainsKey(Keys.Up) && movementKeys[Keys.Up] == 1)
                {
                    currentMoveKey = Keys.Up;
                }
                else if (movementKeys.ContainsKey(Keys.Left) && movementKeys[Keys.Left] == 1)
                {
                    currentMoveKey = Keys.Left;
                }
                else if (movementKeys.ContainsKey(Keys.Down) && movementKeys[Keys.Down] == 1)
                {
                    currentMoveKey = Keys.Down;
                }
                else
                {
                    currentMoveKey = Keys.Right;
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
