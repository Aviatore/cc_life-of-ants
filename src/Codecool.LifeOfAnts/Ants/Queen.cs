namespace Codecool.LifeOfAnts.Ants
{
    using System;
    using Codecool.LifeOfAnts.Utilities;

    public class Queen : Ant
    {
        public int Mood { get; private set; }
        
        private Random _random;
        private Guid _matingDroneId;
        private int _matingTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queen"/> class.
        /// </summary>
        /// <param name="position">The instance of the Position class.</param>
        /// <param name="direction">The Direction enum.</param>
        /// <param name="colony">The instance of the Colony class.</param>
        public Queen(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
            _random = new Random();
            _name = 'Q';
            
            Mood = _random.Next(50, 101);

            colony.OnMove += Move;
        }

        /// <summary>
        /// The method executed by drone after reaching Queen's position.
        /// </summary>
        /// <param name="drone">An instance of the Drone class.</param>
        public void TryMate(Drone drone)
        {
            if (Mood > 0)
            {
                // Set of rules to kick off a Drone by the Queen
                if (!_matingDroneId.Equals(drone.DroneId) || (_matingDroneId.Equals(drone.DroneId) && _matingTime == 0))
                    drone.Position = KickOff();
            }
            else
            {
                _matingDroneId = drone.DroneId;
                _matingTime = 10;
                
                // Set the message to be printed by the Colony below the formicarium display 
                _colony.Msg = "HALLELUJAH!";
                
                Mood = _random.Next(50, 101);
            }
        }

        /// <summary>
        /// Kicks of a Drone to a random position (formicarium edges).
        /// </summary>
        /// <returns>The instance of the Position class.</returns>
        private Position KickOff()
        {
            while (true)
            {
                int x = _random.Next(1, _colony.Width + 1);
                int y = _random.Next(1, _colony.Width + 1);

                if (x == 1 || x == _colony.Width || y == 1 || y == _colony.Width)
                {
                    return new Position(x, y);
                }
            }
        }
        
        /// <summary>
        /// The method actually does not move the Queen, but updates the Queen's mood and
        /// controls the mating time.
        /// </summary>
        /// <param name="sender">The instance of the Colony class.</param>
        /// <param name="args">The event handler arguments (empty by default).</param>
        public override void Move(object sender, EventArgs args)
        {
            if (_matingTime > 0)
                _matingTime--;

            if (Mood > 0)
                Mood--;
            
            _colony.ArenaModifyPosition(this.Position, _name);
        }
    }
}