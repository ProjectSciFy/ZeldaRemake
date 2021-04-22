using CSE3902_Game_Sprint0.Classes.Controllers.CollisionCommands;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.GameState;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class LinkOnTile : ICommand
    {
        private Link link;
        private ITile tile { get; set; }
        private Collision.Collision.Direction direction { get; set; }
        private ZeldaGame game { get; set; }
        public LinkOnTile(Link link, ITile tile, Collision.Collision.Direction direction)
        {
            this.game = link.game;
            this.link = link;
            this.tile = tile;
            this.direction = direction;
        }
        public void Execute()
        {
            if((tile is TPTile) && link.linkState.useSword is false && link.linkState.timer == 0)
            {
                game.changeRoom(16, Collision.Collision.Direction.left);
            }
            if ((tile is BlockTile || tile is WallTile || (tile is GateKeeperTile && ((GateKeeperTile)tile).locked == true)) && !link.linkState.isGrabbed)
            {
                if (tile is GateKeeperTile && ((GateKeeperTile)tile).isLockedDoor == true && game.util.numKeys > 0 && ((GateKeeperTile)tile).isPortal == false)
                {
                    new UnlockDoor(game, direction).Execute();
                }
                else
                {
                    if (direction == Collision.Collision.Direction.down)
                    {
                        link.drawLocation.Y = link.drawLocation.Y - link.velocity.Y;
                    }
                    else if (direction == Collision.Collision.Direction.up)
                    {
                        link.drawLocation.Y = link.drawLocation.Y - link.velocity.Y;
                    }
                    else if (direction == Collision.Collision.Direction.right)
                    {
                        link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                    }
                    else if (direction == Collision.Collision.Direction.left)
                    {
                        link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                    }
                }

            }
            if (tile is StairsTile && !link.linkState.isGrabbed)
            {
                if (game.util.roomNumber == 16 && !game.util.keyPressedTempVariable)
                {
                    game.changeRoom(game.neighbors[game.util.roomNumber][0], Collision.Collision.Direction.right);
                }
                else if (game.util.roomNumber == 17 && !game.util.keyPressedTempVariable)
                {
                    game.changeRoom(18, Collision.Collision.Direction.right);
                }
                else if (direction == Collision.Collision.Direction.down && !game.util.keyPressedTempVariable)
                {
                    game.changeRoom(game.neighbors[game.util.roomNumber][3], direction);
                }
                else if (direction == Collision.Collision.Direction.up && !game.util.keyPressedTempVariable)
                {
                    game.changeRoom(game.neighbors[game.util.roomNumber][0], direction);
                }
                else if (direction == Collision.Collision.Direction.right && !game.util.keyPressedTempVariable)
                {
                    game.changeRoom(game.neighbors[game.util.roomNumber][2], direction);
                }
                else if (direction == Collision.Collision.Direction.left && !game.util.keyPressedTempVariable)
                {
                    game.changeRoom(game.neighbors[game.util.roomNumber][1], direction);
                }
            }
            if(tile is EventTile && game.currentRoom.roomNumber == 8 && ((EventTile)tile).used == false)
            {
                game.currentRoom.closeDoorways();
                game.currentRoom.lockDoor(2);
                ((EventTile)tile).used = true;
            }
            if (tile is PushableTile)
            {
                if (((PushableTile)tile).pushed) 
                {
                    if (direction == Collision.Collision.Direction.down)
                    {
                        link.drawLocation.Y = link.drawLocation.Y - link.velocity.Y;
                    }
                    else if (direction == Collision.Collision.Direction.up)
                    {
                        link.drawLocation.Y = link.drawLocation.Y - link.velocity.Y;
                    }
                    else if (direction == Collision.Collision.Direction.right)
                    {
                        link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                    }
                    else if (direction == Collision.Collision.Direction.left)
                    {
                        link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                    }
                }
                else
                {
                    if (direction is Collision.Collision.Direction.down)
                    {
                        new PushTileUp(game, tile).Execute();
                    }
                    else if (direction is Collision.Collision.Direction.up)
                    {
                        new PushTileDown(game, tile).Execute();
                    }
                    else if (direction == Collision.Collision.Direction.right)
                    {
                        link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                    }
                    else if (direction == Collision.Collision.Direction.left)
                    {
                        link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                    }
                }
            }
            if (tile is WallTile && !link.linkState.isGrabbed)
            {
                foreach (KeyValuePair<ICollisionEntity, Rectangle> entity1 in link.game.collisionManager.collisionEntities)
                {
                    if (entity1.Key is EnemyWallmaster)
                    {
                        if (!((EnemyWallmaster)entity1.Key).myState.activating && !((EnemyWallmaster)entity1.Key).myState.active && link.linkState.wallmasterDeployedTimer <= 0)
                        {
                            link.linkState.wallmasterDeployedTimer = 60;
                            WallmasterStateMachine.Direction wallmasterDirection = WallmasterStateMachine.Direction.up;
                            float drawLocationX = 0;
                            float drawLocationY = 0;
                            switch (direction)
                            {
                                case Collision.Collision.Direction.up:
                                    wallmasterDirection = WallmasterStateMachine.Direction.down;
                                    drawLocationX = link.drawLocation.X + (2 * 16 * link.spriteScalar);
                                    drawLocationY = link.drawLocation.Y - (16 * link.spriteScalar);
                                    break;
                                case Collision.Collision.Direction.down:
                                    wallmasterDirection = WallmasterStateMachine.Direction.up;
                                    drawLocationX = link.drawLocation.X - (2 * 16 * link.spriteScalar);
                                    drawLocationY = link.drawLocation.Y + (16 * link.spriteScalar);
                                    break;
                                case Collision.Collision.Direction.left:
                                    wallmasterDirection = WallmasterStateMachine.Direction.right;
                                    drawLocationX = link.drawLocation.X - (16 * link.spriteScalar);
                                    drawLocationY = link.drawLocation.Y - (2 * 16 * link.spriteScalar);
                                    break;
                                case Collision.Collision.Direction.right:
                                    wallmasterDirection = WallmasterStateMachine.Direction.left;
                                    drawLocationX = link.drawLocation.X + (16 * link.spriteScalar);
                                    drawLocationY = link.drawLocation.Y + (2 * 16 * link.spriteScalar);
                                    break;
                                default:
                                    break;
                            }

                            var random = new Random();

                            switch (random.Next(1))
                            {
                                case 0:
                                    ((EnemyWallmaster)entity1.Key).myState.direction = wallmasterDirection;
                                    ((EnemyWallmaster)entity1.Key).myState.activating = true;
                                    ((EnemyWallmaster)entity1.Key).drawLocation = new Vector2(drawLocationX, drawLocationY);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
