using CSE3902_Game_Sprint0.Classes.Doors;
using CSE3902_Game_Sprint0.Classes.Header;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class TransitionState : IGameState
    {
        private ZeldaGame game { get; set; }
        private PushableTile oldTile { get; set; }
        private PushableTile nextTile { get; set; }
        private Room oldroom { get; set; }

        private bool foundOldTile { get; set; } = false;
        private bool foundNextTile { get; set; } = false;

        private Room nextroom { get; set; }
        private int timer { get; set; } = 0;
        private Vector2 drawLocationInteriorOld;
        private Vector2 drawLocationExteriorOld;
        private Vector2 drawLocationInteriorNext;
        private Vector2 drawLocationExteriorNext;

        private ISprite roominteriorOld { get; set; }
        private ISprite roomexteriorOld { get; set; }

        private ISprite roominteriorNext { get; set; }
        private ISprite roomexteriorNext { get; set; }

        private ISprite topDoorOld { get; set; }
        private ISprite leftDoorOld { get; set; }
        private ISprite rightDoorOld { get; set; }
        private ISprite bottomDoorOld { get; set; }

        private ISprite topDoorNext { get; set; }
        private ISprite leftDoorNext { get; set; }
        private ISprite rightDoorNext { get; set; }
        private ISprite bottomDoorNext { get; set; }

        private ISprite oldPushableTile { get; set; }
        private ISprite nextPushableTile { get; set; }

        private Vector2 drawLocationTopDoorOld;
        private Vector2 drawLocationLeftDoorOld;
        private Vector2 drawLocationRightDoorOld;
        private Vector2 drawLocationBottomDoorOld;
        private Vector2 drawLocationTopDoorNext;
        private Vector2 drawLocationLeftDoorNext;
        private Vector2 drawLocationRightDoorNext;
        private Vector2 drawLocationBottomDoorNext;

        private Vector2 drawLocationOldPushableTile;
        private Vector2 drawLocationNextPushableTile;

        private int windowWidth { get; set; }
        private int windowHeight { get; set; }
        private readonly Texture2D itemSpriteSheet;
        private int roomLimiter { get; set; }
        private int drawOffset { get; set; }
        private Collision.Collision.Direction transitionDirection { get; set; }
        private int animationSpeed { get; set; } = TransitionStateStorage.animationSpeed;

        private readonly playerHUD pHUD;

        public TransitionState(ZeldaGame game, Room oldroom, Room nextroom, Collision.Collision.Direction transitionDirection)
        {
            this.game = game;
            this.pHUD = new playerHUD(game, game.hudSpriteFactory);
            this.oldroom = oldroom;
            this.nextroom = nextroom;
            timer = TransitionStateStorage.timer;

            RoomTextureStorage roomTextures = new RoomTextureStorage(this.game);
            game.spriteSheets.TryGetValue("DungeonTileset", out itemSpriteSheet);

            windowWidth = game.GraphicsDevice.Viewport.Width;
            windowHeight = game.GraphicsDevice.Viewport.Height;

            int windowHeightFloor = ((windowHeight / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;

            roomLimiter = TransitionStateStorage.roomLimiter;
            drawOffset = TransitionStateStorage.drawOffset;

            this.transitionDirection = transitionDirection;

            Vector2 newRoomShift = new Vector2(0, 0);

            //SLIDE
            switch (transitionDirection)
            {
                case Collision.Collision.Direction.up:
                    newRoomShift = new Vector2(0, -TransitionStateStorage.roomTransitionY * ParserUtility.SCALE_FACTOR);
                    timer = TransitionStateStorage.roomTransitionY * ParserUtility.SCALE_FACTOR / animationSpeed;
                    break;
                case Collision.Collision.Direction.left:
                    newRoomShift = new Vector2(-TransitionStateStorage.roomTransitionX * ParserUtility.SCALE_FACTOR, 0);
                    timer = TransitionStateStorage.roomTransitionX * ParserUtility.SCALE_FACTOR / animationSpeed;
                    break;
                case Collision.Collision.Direction.right:
                    newRoomShift = new Vector2(TransitionStateStorage.roomTransitionX * ParserUtility.SCALE_FACTOR, 0);
                    timer = TransitionStateStorage.roomTransitionX * ParserUtility.SCALE_FACTOR / animationSpeed;
                    break;
                case Collision.Collision.Direction.down:
                    newRoomShift = new Vector2(0, TransitionStateStorage.roomTransitionY * ParserUtility.SCALE_FACTOR);
                    timer = TransitionStateStorage.roomTransitionY * ParserUtility.SCALE_FACTOR / animationSpeed;
                    break;
            }

            drawLocationInteriorOld = new Vector2(windowWidthFloor + drawOffset, windowHeightFloor + drawOffset);
            drawLocationExteriorOld = new Vector2(windowWidthFloor, windowHeightFloor);


            drawLocationInteriorNext = new Vector2(windowWidthFloor + drawOffset, windowHeightFloor + drawOffset) + newRoomShift;
            drawLocationExteriorNext = new Vector2(windowWidthFloor, windowHeightFloor) + newRoomShift;


            int oldRoomNumber = this.oldroom.getRoomNumber();
            roominteriorOld = roomTextures.getRoom(oldRoomNumber);

            int nextRoomNumber = nextroom.getRoomNumber();
            roominteriorNext = roomTextures.getRoom(nextRoomNumber);

            roomexteriorNext = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.exteriorTemp, Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);

            if (this.oldroom.getRoomNumber() == TransitionStateStorage.specialRoomNumber)
            {
                roomexteriorOld = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.exteriorActual, Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
                drawLocationInteriorOld = drawLocationInteriorOld - new Vector2(0, TransitionStateStorage.interiorPosAdjust);
                roominteriorOld = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.exteriorActual, Color.Transparent, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }
            else
            {
                roomexteriorOld = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.exteriorTemp, Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }

            if (this.nextroom.getRoomNumber() == TransitionStateStorage.specialRoomNumber)
            {

                roomexteriorNext = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.exteriorActual, Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
                roominteriorNext = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.exteriorActual, Color.Transparent, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }
            else
            {
                roomexteriorNext = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.exteriorTemp, Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }

            drawLocationTopDoorOld = new Vector2(windowWidthFloor + TransitionStateStorage.verticalDoorAdjust * ParserUtility.SCALE_FACTOR, windowHeightFloor);
            drawLocationLeftDoorOld = new Vector2(windowWidthFloor, windowHeightFloor + TransitionStateStorage.smallAdjust * ParserUtility.SCALE_FACTOR);
            drawLocationRightDoorOld = new Vector2(windowWidthFloor + TransitionStateStorage.horizontalDoorAdjust * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.smallAdjust * ParserUtility.SCALE_FACTOR);
            drawLocationBottomDoorOld = new Vector2(windowWidthFloor + TransitionStateStorage.verticalDoorAdjust * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.largeAdjust * ParserUtility.SCALE_FACTOR);

            drawLocationTopDoorNext = new Vector2(windowWidthFloor + TransitionStateStorage.verticalDoorAdjust * ParserUtility.SCALE_FACTOR, windowHeightFloor) + newRoomShift;
            drawLocationLeftDoorNext = new Vector2(windowWidthFloor, windowHeightFloor + TransitionStateStorage.smallAdjust * ParserUtility.SCALE_FACTOR) + newRoomShift;
            drawLocationRightDoorNext = new Vector2(windowWidthFloor + TransitionStateStorage.horizontalDoorAdjust * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.smallAdjust * ParserUtility.SCALE_FACTOR) + newRoomShift;
            drawLocationBottomDoorNext = new Vector2(windowWidthFloor + TransitionStateStorage.verticalDoorAdjust * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.largeAdjust * ParserUtility.SCALE_FACTOR) + newRoomShift;

            foreach (IDoor door in oldroom.getDoors())
            {
                if (door.GetType() == typeof(TopDoor))
                {
                    topDoorOld = roomTextures.getDoor(door.getDoorValue());
                }
                else if (door.GetType() == typeof(LeftDoor))
                {
                    leftDoorOld = roomTextures.getDoor(door.getDoorValue());
                }
                else if (door.GetType() == typeof(RightDoor))
                {
                    rightDoorOld = roomTextures.getDoor(door.getDoorValue());
                }
                else if (door.GetType() == typeof(BottomDoor))
                {
                    bottomDoorOld = roomTextures.getDoor(door.getDoorValue());
                }
            }

            foreach (IDoor door in nextroom.getDoors())
            {
                if (door.GetType() == typeof(TopDoor))
                {
                    topDoorNext = roomTextures.getDoor(door.getDoorValue());
                }
                else if (door.GetType() == typeof(LeftDoor))
                {
                    leftDoorNext = roomTextures.getDoor(door.getDoorValue());
                }
                else if (door.GetType() == typeof(RightDoor))
                {
                    rightDoorNext = roomTextures.getDoor(door.getDoorValue());
                }
                else if (door.GetType() == typeof(BottomDoor))
                {
                    bottomDoorNext = roomTextures.getDoor(door.getDoorValue());
                }
            }

            foreach (ITile tile in oldroom.getTiles())
            {
                if (tile.GetType() == typeof(PushableTile))
                {
                    this.oldTile = (PushableTile)tile;
                    foundOldTile = true;
                }
            }

            foreach (ITile tile in nextroom.getTiles())
            {
                if (tile.GetType() == typeof(PushableTile))
                {
                    this.nextTile = (PushableTile)tile;
                    foundNextTile = true;
                }
            }

            if (foundOldTile)
            {
                oldTile.pushed = false;
                drawLocationOldPushableTile = oldTile.drawLocation;
                oldPushableTile = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.pushableTile, Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }
            if (foundNextTile)
            {
                drawLocationNextPushableTile = nextTile.drawLocation + newRoomShift;
                nextTile.pushed = false;
                nextPushableTile = new UniversalSprite(game, itemSpriteSheet, TransitionStateStorage.pushableTile, Color.White, SpriteEffects.None, new Vector2(1, 1), roomLimiter, 0.0f);
            }

        }

        public void Draw()
        {
            roomexteriorOld.Draw(drawLocationExteriorOld);
            roominteriorOld.Draw(drawLocationInteriorOld);
            roomexteriorNext.Draw(drawLocationExteriorNext);
            roominteriorNext.Draw(drawLocationInteriorNext);
            topDoorOld.Draw(drawLocationTopDoorOld);
            leftDoorOld.Draw(drawLocationLeftDoorOld);
            rightDoorOld.Draw(drawLocationRightDoorOld);
            bottomDoorOld.Draw(drawLocationBottomDoorOld);
            topDoorNext.Draw(drawLocationTopDoorNext);
            leftDoorNext.Draw(drawLocationLeftDoorNext);
            rightDoorNext.Draw(drawLocationRightDoorNext);
            bottomDoorNext.Draw(drawLocationBottomDoorNext);
            if (foundOldTile)
            {
                oldPushableTile.Draw(drawLocationOldPushableTile);
            }
            if (foundNextTile)
            {
                nextPushableTile.Draw(drawLocationNextPushableTile);
            }
            pHUD.Draw();
        }
        public void UpdateCollisions()
        {

        }
        public void Update()
        {
            int windowHeightFloor = ((windowHeight / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST;
            int windowWidthFloor = (windowWidth / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            timer--;
            int adj = TransitionStateStorage.adjust;
            if (timer == 0)
            {
                game.currentGameState = game.currentMainGameState;
                game.util.keyPressedTempVariable = false;
                if (nextroom.getRoomNumber() == TransitionStateStorage.specialRoomNumber + 1 && oldroom.getRoomNumber() == TransitionStateStorage.specialRoomNumber)
                {
                    game.linkStateMachine.ChangeDirection(LinkStateMachine.Direction.down);
                    game.link.SetLocation(new Vector2(windowWidthFloor + TransitionStateStorage.linkAdjust * ParserUtility.SCALE_FACTOR + adj * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.temp * ParserUtility.SCALE_FACTOR));
                    goto Skip;
                }
                else if (nextroom.getRoomNumber() == TransitionStateStorage.specialRoomNumber)
                {
                    game.linkStateMachine.ChangeDirection(LinkStateMachine.Direction.down);
                    game.link.SetLocation(new Vector2(windowWidthFloor + TransitionStateStorage.linkSmallAdjust * ParserUtility.SCALE_FACTOR + adj * ParserUtility.SCALE_FACTOR, windowHeightFloor + (-adj * ParserUtility.SCALE_FACTOR) + ParserUtility.SPRITE_SIZE * ParserUtility.SCALE_FACTOR));
                    goto Skip;
                }
                switch (transitionDirection)
                {
                    case Collision.Collision.Direction.up:
                        game.linkStateMachine.ChangeDirection(LinkStateMachine.Direction.up);
                        game.link.SetLocation(new Vector2(windowWidthFloor + TransitionStateStorage.verticalDoorAdjust * ParserUtility.SCALE_FACTOR + adj * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.largeAdjust * ParserUtility.SCALE_FACTOR));
                        break;
                    case Collision.Collision.Direction.left:
                        game.linkStateMachine.ChangeDirection(LinkStateMachine.Direction.left);
                        game.link.SetLocation(new Vector2(windowWidthFloor + TransitionStateStorage.horizontalDoorAdjust * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.smallAdjust * ParserUtility.SCALE_FACTOR + adj * ParserUtility.SCALE_FACTOR));
                        break;
                    case Collision.Collision.Direction.right:
                        game.linkStateMachine.ChangeDirection(LinkStateMachine.Direction.right);
                        game.link.SetLocation(new Vector2(windowWidthFloor + ParserUtility.SPRITE_SIZE * ParserUtility.SCALE_FACTOR, windowHeightFloor + TransitionStateStorage.smallAdjust * ParserUtility.SCALE_FACTOR + adj * ParserUtility.SCALE_FACTOR));
                        break;
                    case Collision.Collision.Direction.down:
                        game.linkStateMachine.ChangeDirection(LinkStateMachine.Direction.down);
                        game.link.SetLocation(new Vector2(windowWidthFloor + TransitionStateStorage.verticalDoorAdjust * ParserUtility.SCALE_FACTOR + adj * ParserUtility.SCALE_FACTOR, windowHeightFloor + ParserUtility.SPRITE_SIZE * ParserUtility.SCALE_FACTOR));
                        break;
                }
            }


        Skip:
            Vector2 animationShift = new Vector2(0, 0);

            switch (transitionDirection)
            {
                case Collision.Collision.Direction.up:
                    animationShift = new Vector2(0, animationSpeed);
                    break;
                case Collision.Collision.Direction.left:
                    animationShift = new Vector2(animationSpeed, 0);
                    break;
                case Collision.Collision.Direction.right:
                    animationShift = new Vector2(-animationSpeed, 0);
                    break;
                case Collision.Collision.Direction.down:
                    animationShift = new Vector2(0, -animationSpeed);
                    break;
            }

            drawLocationExteriorOld = drawLocationExteriorOld + animationShift;
            drawLocationInteriorOld = drawLocationInteriorOld + animationShift;

            drawLocationExteriorNext = drawLocationExteriorNext + animationShift;
            drawLocationInteriorNext = drawLocationInteriorNext + animationShift;

            drawLocationTopDoorOld = drawLocationTopDoorOld + animationShift;
            drawLocationLeftDoorOld = drawLocationLeftDoorOld + animationShift;
            drawLocationRightDoorOld = drawLocationRightDoorOld + animationShift;
            drawLocationBottomDoorOld = drawLocationBottomDoorOld + animationShift;

            drawLocationTopDoorNext = drawLocationTopDoorNext + animationShift;
            drawLocationLeftDoorNext = drawLocationLeftDoorNext + animationShift;
            drawLocationRightDoorNext = drawLocationRightDoorNext + animationShift;
            drawLocationBottomDoorNext = drawLocationBottomDoorNext + animationShift;

            if (foundOldTile)
            {
                drawLocationOldPushableTile = drawLocationOldPushableTile + animationShift;
            }
            if (foundNextTile)
            {
                drawLocationNextPushableTile = drawLocationNextPushableTile + animationShift;
            }

            pHUD.Update();
        }
    }
}
