using System;

namespace Codecool.LifeOfAnts.Ants
{
    using Codecool.LifeOfAnts.Utilities;

    public abstract class Ant
    {
        protected Direction Direction;
        public Position Position;
        protected Colony Colony;
        protected char _name;

        public Ant(Position position, Direction direction, Colony colony)
        {
            Direction = direction;
            Position = position;
            Colony = colony;
        }

        public abstract void Move(object sender, EventArgs args);
    }
}