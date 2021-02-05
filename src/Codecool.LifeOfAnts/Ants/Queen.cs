using Codecool.LifeOfAnts.Utilities;
using System;

namespace Codecool.LifeOfAnts.Ants
{
    public class Queen : Ant
    {
        public int Mood { get; private set; }
        private Random _random;
        private Guid MatingDroneId;
        private int MatingTime;

        public Queen(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
            _random = new Random();
            Mood = _random.Next(50, 101);
            
            colony.OnMove += Move;
            _name = 'Q';
        }

        public void TryMate(Drone drone)
        {
            if (Mood > 0)
            {
                if (!MatingDroneId.Equals(drone.DroneId) || (MatingDroneId.Equals(drone.DroneId) && MatingTime == 0))
                    drone.Position = KickOff();
            }
            else
            {
                MatingDroneId = drone.DroneId;
                MatingTime = 10;
                Mood = _random.Next(50, 101);
                Colony.Msg = "HALLELUJAH!";
            }
        }

        private Position KickOff()
        {
            while (true)
            {
                int x = _random.Next(1, Colony.Width);
                int y = _random.Next(1, Colony.Width);

                if (x == 1 || x == Colony.Width - 1 || y == 1 || y == Colony.Width - 1)
                {
                    return new Position(x, y);
                }
            }
        }
        
        public override void Move(object sender, EventArgs args)
        {
            if (MatingTime > 0)
                MatingTime--;

            if (Mood > 0)
                Mood--;
            
            Colony.ArenaModifyPosition(this.Position, _name);
        }
    }
}