using CSE3902_Game_Sprint0.Classes.Doors;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.CollisionCommands
{
    public class UnlockDoor
    {
        private ZeldaGame game;
        public UnlockDoor(ZeldaGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            Room currentRoom;
            currentRoom = null;
            foreach (Room r in game.roomList)
            {
                if (r.getRoomNumber() == game.util.roomNumber)
                {
                    currentRoom = r;
                }
            }
            foreach (ITile tile in currentRoom.getTiles())
            {
                if (tile.GetType() == typeof(GateKeeperTile))
                {
                    if (((GateKeeperTile)tile).isLockedDoor)
                    {
                        ((GateKeeperTile)tile).locked = false;
                    }
                }
            }
            foreach (IDoor door in currentRoom.getDoors().ToArray())
            {
                if(door.getDoorValue() % 10 == 2)
                {
                    switch (door.getDoorValue() / 10)
                    {
                        case 0:
                            currentRoom.addDoor(new TopDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        case 1:
                            currentRoom.addDoor(new LeftDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        case 2:
                            currentRoom.addDoor(new RightDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        case 3:
                            currentRoom.addDoor(new BottomDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        default:
                            break;
                    }
                    currentRoom.removeDoor(door);
                }
            }
        }

    }
}
