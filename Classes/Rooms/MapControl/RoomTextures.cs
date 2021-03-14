using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Rooms.MapControl
{
    public class RoomTextures
    {
        private Texture2D texture = null;

        public const int INSIDE_HEIGHT = 112;
        public const int INSIDE_WIDTH = 192;
        public const int ROOM_HEIGHT = 176;
        public const int ROOM_WIDTH = 256;
        
        public const int DOOR_SIZE = 32; //rectangle, 32 pixels each side

        private RoomTextures()
        {

        }

        public Texture2D getRoomTexture()
        {
            return this.texture;
        }
    }
}
