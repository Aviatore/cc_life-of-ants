namespace Codecool.LifeOfAnts.Ants
{
    using Codecool.LifeOfAnts.Utilities;

    public abstract class Ant
    {
        protected Direction Direction;
        protected Position Position;
        protected Colony Colony;

        public Ant(Position position, Direction direction, Colony colony)
        {
            Direction = direction;
            Position = position;
            Colony = colony;
        }

        public abstract void Move();
    }
}