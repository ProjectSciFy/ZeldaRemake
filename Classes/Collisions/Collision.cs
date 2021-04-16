namespace CSE3902_Game_Sprint0.Classes.Collision
{
    public class Collision
    {
        public enum Direction { none, up, down, left, right };
        private Direction direction { get; set; }

        public Collision(Direction direction)
        {
            this.direction = direction;
        }
    }
}
