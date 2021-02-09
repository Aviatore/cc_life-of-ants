namespace Codecool.LifeOfAnts.Ants
{
    using System;
    using Codecool.LifeOfAnts.Utilities;

    public class Drone : Ant
    {
        public Guid DroneId { get; } 
        
        public Drone(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
            _name = 'D';
            
            DroneId = Guid.NewGuid();
            
            colony.OnMove += Move;
        }

        public override void Move(object sender, EventArgs args)
        {
            int diffX = _colony.QueenAnt.Position.X - Position.X;
            int diffY = _colony.QueenAnt.Position.Y - Position.Y;

            if (Math.Abs(diffX) > 1 || Math.Abs(diffY) > 1)
            {
                Utilities.Position position;
                
                if (Math.Abs(diffX) > Math.Abs(diffY))
                {
                    position = new Position(Position.X + (diffX / Math.Abs(diffX)), Position.Y);
                }
                else
                {
                    position = new Position(Position.X, Position.Y + (diffY / Math.Abs(diffY)));
                }
                
                _colony.ArenaModifyPosition(this.Position, ' ');
                this.Position = position;
                _colony.ArenaModifyPosition(this.Position, _name);
            }
            else
            {
                _colony.ArenaModifyPosition(this.Position, ' ');
                _colony.QueenAnt.TryMate(this);
                _colony.ArenaModifyPosition(this.Position, _name);
            }
        }
    }
}