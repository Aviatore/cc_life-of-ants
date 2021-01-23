namespace Codecool.LifeOfAnts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Codecool.LifeOfAnts.Ants;
    using Codecool.LifeOfAnts.Utilities;

    /// <summary>
    /// Colony
    /// </summary>
    public class Colony
    {
        private int _width;
        private List<Ant> _listOfAnts;

        public Colony(int width, int workersQuantity, int soldiersQuantity, int droneQuantity)
        {
            _width = width;
        }

        private bool IsValidPosition(Position position)
        {
            Position topLeft = new Position(0, 0);
            Position topRight = new Position(_width - 1, _width - 1);

            return position.X >= topLeft.X && position.X <= topRight.X && position.Y >= topLeft.Y &&
                   position.Y <= topRight.Y;
        }

        /// <summary>
        /// GenerateAnts
        /// </summary>
        public void GenerateAnts()
        {
            
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            
        }

        /// <summary>
        /// DisplayAttribute
        /// </summary>
        public void DisplayAttribute()
        {
            
        }
    }
}