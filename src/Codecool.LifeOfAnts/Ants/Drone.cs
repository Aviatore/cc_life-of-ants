using System;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : Ant
    {
        public Guid DroneId { get; } 
        public Drone(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
            DroneId = Guid.NewGuid();
            colony.OnMove += Move;
            _name = 'D';
        }

        public override void Move(object sender, EventArgs args)
        {
            int diffX = Colony.QueenAnt.Position.X - Position.X;
            int diffY = Colony.QueenAnt.Position.Y - Position.Y;

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
                
                Colony.ArenaModifyPosition(this.Position, ' ');
                this.Position = position;
                Colony.ArenaModifyPosition(this.Position, _name);
            }
            else
            {
                Colony.ArenaModifyPosition(this.Position, ' ');
                Colony.QueenAnt.TryMate(this);
                Colony.ArenaModifyPosition(this.Position, _name);
            }
        }
    }
}