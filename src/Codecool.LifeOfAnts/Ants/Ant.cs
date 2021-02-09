namespace Codecool.LifeOfAnts.Ants
{
    using System;
    using Codecool.LifeOfAnts.Utilities;

    /// <summary>
    /// The base class for all possible ant types.
    /// </summary>
    public abstract class Ant
    {
        public Position Position { get; set; } 
        
        protected Direction _direction;
        protected Colony _colony;
        protected char _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ant"/> class.
        /// </summary>
        /// <param name="position">The instance of the Position class.</param>
        /// <param name="direction">The Direction enum.</param>
        /// <param name="colony">The instance of the Colony class.</param>
        public Ant(Position position, Direction direction, Colony colony)
        {
            Position = position;
            _direction = direction;
            _colony = colony;
        }

        /// <summary>
        /// Moves the ant within formicarium.
        /// The method is a handler of the OnMove event raised by the instance of the Colony class. 
        /// </summary>
        /// <param name="sender">The instance of the Colony class.</param>
        /// <param name="args">The event handler arguments (empty by default).</param>
        public abstract void Move(object sender, EventArgs args);
    }
}