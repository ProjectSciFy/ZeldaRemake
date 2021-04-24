using CSE3902_Game_Sprint0.Classes.Doors;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;

namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class PortalGunLink : ICommand
    {
        private LinkStateMachine linkState { get; set; }
        private ZeldaGame game { get; set; }

        public PortalGunLink(ZeldaGame game, LinkStateMachine linkState)
        {
            this.game = game;
            this.linkState = linkState;
        }
        public void Execute()
        {
            linkState.usePortal = true;

            int thisDoorValue;
            int newRoomPortalNumber = 0;
            Room tempRoom;
            foreach (IDoor door in game.currentRoom.getDoors())
            {
                thisDoorValue = door.getDoorValue();
                if (door.GetType() == typeof(TopDoor))
                {
                    if (thisDoorValue % 10 == 6)
                    {
                        game.currentRoom.addDoor(new TopDoor(game, new RoomTextureStorage(game), (door.getDoorValue() / 10 + 7)));
                        game.currentRoom.removeDoor(door);
                        if (game.currentRoom.getRoomNumber() == 6) newRoomPortalNumber = 10;
                        else newRoomPortalNumber = 11;
                    }
                }
                else if (door.GetType() == typeof(BottomDoor))
                {
                    if (thisDoorValue % 10 == 6)
                    {
                        game.currentRoom.addDoor(new BottomDoor(game, new RoomTextureStorage(game), (7)));
                        game.currentRoom.removeDoor(door);
                        if (game.currentRoom.getRoomNumber() == 10) newRoomPortalNumber = 6;
                        else newRoomPortalNumber = 7;
                    }
                }
                if (newRoomPortalNumber != 0)
                {
                    foreach (ITile tile in game.currentRoom.getTiles())
                    {
                        if (tile.GetType() == typeof(GateKeeperTile) && ((GateKeeperTile)tile).isLockedDoor) ((GateKeeperTile)tile).locked = false;
                    }
                    game.sounds["doorUnlock"].CreateInstance().Play();
                    tempRoom = game.currentRoom;
                    foreach (Room r in game.roomList)
                    {
                        if (r.getRoomNumber() == newRoomPortalNumber) tempRoom = r;
                    }
                    foreach (IDoor door2 in tempRoom.getDoors())
                    {
                        thisDoorValue = door2.getDoorValue();
                        if (door2.GetType() == typeof(TopDoor))
                        {
                            if (thisDoorValue % 10 == 6)
                            {
                                tempRoom.addDoor(new TopDoor(game, new RoomTextureStorage(game), (8)));
                                tempRoom.removeDoor(door2);
                                break;
                            }
                        }
                        else if (door2.GetType() == typeof(BottomDoor))
                        {
                            if (thisDoorValue % 10 == 6)
                            {
                                tempRoom.addDoor(new BottomDoor(game, new RoomTextureStorage(game), (8)));
                                tempRoom.removeDoor(door2);
                                break;
                            }
                        }
                    }
                    foreach (ITile tile in tempRoom.getTiles())
                    {
                        if (tile.GetType() == typeof(GateKeeperTile) && ((GateKeeperTile)tile).isLockedDoor) ((GateKeeperTile)tile).locked = false;
                    }
                    break;
                }
            }
        }
    }
}
