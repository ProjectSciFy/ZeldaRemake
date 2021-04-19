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
using CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts;

namespace CSE3902_Game_Sprint0
{
    public class CKeyboard : IController
    {
        private LinkStateMachine linkState { get; set; }
        private BombStateMachine bombState { get; set; }
        Dictionary<Keys, ICommand> keyBinds = new Dictionary<Keys, ICommand>();
        HashSet<Keys> heldKeys = new HashSet<Keys>();
        Dictionary<Keys, int> movementKeys = new Dictionary<Keys, int>();
        private ZeldaGame game { get; set; }

        public CKeyboard(ZeldaGame game)
        {

            linkState = game.linkStateMachine;
            bombState = game.bombStateMachine;
            this.game = game;

            keyBinds.Add(Keys.Up, new MoveLink(linkState, LinkStateMachine.Direction.up));
            keyBinds.Add(Keys.W, new MoveLink(linkState, LinkStateMachine.Direction.up));

            keyBinds.Add(Keys.Left, new MoveLink(linkState, LinkStateMachine.Direction.left));
            keyBinds.Add(Keys.A, new MoveLink(linkState, LinkStateMachine.Direction.left));

            keyBinds.Add(Keys.Down, new MoveLink(linkState, LinkStateMachine.Direction.down));
            keyBinds.Add(Keys.S, new MoveLink(linkState, LinkStateMachine.Direction.down));

            keyBinds.Add(Keys.Right, new MoveLink(linkState, LinkStateMachine.Direction.right));
            keyBinds.Add(Keys.D, new MoveLink(linkState, LinkStateMachine.Direction.right));

            keyBinds.Add(Keys.LeftShift, new RollLink(linkState));
            keyBinds.Add(Keys.T, new TwoPlayer(game));

            keyBinds.Add(Keys.N, new PrimaryWeaponLink(linkState));
            keyBinds.Add(Keys.Z, new PrimaryWeaponLink(linkState));
            keyBinds.Add(Keys.X, new SecondaryWeaponLink(linkState));
            keyBinds.Add(Keys.M, new SecondaryWeaponLink(linkState));

            keyBinds.Add(Keys.D2, new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.bomb));
            keyBinds.Add(Keys.NumPad2, new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.bomb));
            keyBinds.Add(Keys.D3, new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.arrow));
            keyBinds.Add(Keys.NumPad3, new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.arrow));
            keyBinds.Add(Keys.D4, new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.boomerang));
            keyBinds.Add(Keys.NumPad4, new SecondaryWeaponSelect(linkState, LinkStateMachine.Weapon.boomerang));

            keyBinds.Add(Keys.Q, new ShutDownGame(game));
            keyBinds.Add(Keys.R, new Reset(game));
            keyBinds.Add(Keys.P, new Pause(game));
            keyBinds.Add(Keys.I, new Select(game));

            keyBinds.Add(Keys.K, new GiveKeys(game));
        }

        public void Update()
        {
            linkState = game.linkStateMachine;
            KeyboardState keyState = Keyboard.GetState();
            HashSet<Keys> releasedKeys = new HashSet<Keys>(heldKeys);
            Keys[] pressedKeys = keyState.GetPressedKeys();
            int lastMoveKeyCount = movementKeys.Count;

            for (int i = 0; i < pressedKeys.Length; i++)
            {
                releasedKeys.Remove(pressedKeys[i]);

                if (keyBinds.ContainsKey(pressedKeys[i]) && !heldKeys.Contains(pressedKeys[i]))
                {
                    keyBinds[pressedKeys[i]].Execute();
                    heldKeys.Add(pressedKeys[i]);

                    if (pressedKeys[i] == Keys.W || pressedKeys[i] == Keys.A || pressedKeys[i] == Keys.S || pressedKeys[i] == Keys.D || pressedKeys[i] == Keys.Up || pressedKeys[i] == Keys.Left || pressedKeys[i] == Keys.Down || pressedKeys[i] == Keys.Right)
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

            foreach (Keys releasedKey in releasedKeys)
            {
                heldKeys.Remove(releasedKey);
                
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

                if (newMoveKeyCount < lastMoveKeyCount)
                {
                    keyBinds[currentMoveKey].Execute();
                }
            }
            else
            {
                new IdleLink(linkState).Execute();
            }
        }
    }
}
