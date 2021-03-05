namespace CSE3902_Game_Sprint0.Classes.Collision
{
    public class Collision
    {
        //Maintains an enum definition of what kinds of collisions can occur
        public enum Direction { none, up, down, left, right };
        private Direction direction;

        public Collision(Direction direction)
        {
            this.direction = direction;
        }
    }
}
