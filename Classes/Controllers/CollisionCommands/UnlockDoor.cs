using CSE3902_Game_Sprint0.Classes.Doors;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;

namespace CSE3902_Game_Sprint0.Classes.Controllers.CollisionCommands
{
    public class UnlockDoor
    {
        private ZeldaGame game { get; set; }
        private readonly Collision.Collision.Direction direction;
        public UnlockDoor(ZeldaGame game, Collision.Collision.Direction direction)
        {
            this.game = game;
            this.direction = direction;
        }
        public void Execute()
        {
            Room nextRoom = null;
            int nextRoomNumber = 0;
            Room currentRoom = null;
            //FIND NEXT ROOM NUMBER
            switch (direction)
            {
                case (Collision.Collision.Direction.up):
                    nextRoomNumber = game.neighbors[game.util.roomNumber][0];
                    break;
                case (Collision.Collision.Direction.left):
                    nextRoomNumber = game.neighbors[game.util.roomNumber][1];
                    break;
                case (Collision.Collision.Direction.right):
                    nextRoomNumber = game.neighbors[game.util.roomNumber][2];
                    break;
                case (Collision.Collision.Direction.down):
                    nextRoomNumber = game.neighbors[game.util.roomNumber][3];
                    break;
                default:
                    break;
            }
            //FIND NEXT ROOM
            foreach (Room r in game.roomList)
            {
                if (r.getRoomNumber() == nextRoomNumber) nextRoom = r;
            }
            //UNLCOK NEXT ROOM DOOR
            foreach (ITile tile in nextRoom.getTiles())
            {
                if (tile.GetType() == typeof(GateKeeperTile) && ((GateKeeperTile)tile).isLockedDoor) ((GateKeeperTile)tile).locked = false;
            }
            foreach (IDoor door in nextRoom.getDoors().ToArray())
            {
                if (door.getDoorValue() % 10 == 2)
                {
                    switch (door.getDoorValue() / 10)
                    {
                        case 0:
                            nextRoom.addDoor(new TopDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        case 1:
                            nextRoom.addDoor(new LeftDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        case 2:
                            nextRoom.addDoor(new RightDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        case 3:
                            nextRoom.addDoor(new BottomDoor(game, new RoomTextureStorage(game), door.getDoorValue() - 1));
                            break;
                        default:
                            break;
                    }
                    nextRoom.removeDoor(door);
                    game.sounds["doorUnlock"].CreateInstance().Play();
                }
            }
            //FIND CURRENT ROOM
            foreach (Room r in game.roomList)
            {
                if (r.getRoomNumber() == game.util.roomNumber) currentRoom = r;
            }
            //UNLCOK CURRENT ROOM DOOR
            foreach (ITile tile in currentRoom.getTiles())
            {
                if (tile.GetType() == typeof(GateKeeperTile) && ((GateKeeperTile)tile).isLockedDoor) ((GateKeeperTile)tile).locked = false;
            }
            foreach (IDoor door in currentRoom.getDoors().ToArray())
            {
                if (door.getDoorValue() % 10 == 2)
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
                    game.sounds["doorUnlock"].CreateInstance().Play();
                }
            }
            game.util.numKeys = game.util.numKeys - 1;
        }
    }
}
