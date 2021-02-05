using System;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Worker : Ant
    {
        private Random _random; 
        public Worker(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
            _random = new Random();
            
            colony.OnMove += Move;
            _name = 'W';
        }

        public override void Move(object sender, EventArgs args)
        {
            int x = 0;
            int y = 0;

            bool loop = true;
            
            while (loop)
            {
                byte randomDirection = (byte) _random.Next(0, 4);
                Direction direction = (Direction) randomDirection;

                switch (direction)
                {
                    case Direction.East:
                        x = this.Position.X + 1;
                        y = this.Position.Y;
                        break;
                    case Direction.South:
                        x = this.Position.X;
                        y = this.Position.Y + 1;
                        break;
                    case Direction.West:
                        x = this.Position.X - 1;
                        y = this.Position.Y;
                        break;
                    case Direction.North:
                        x = this.Position.X;
                        y = this.Position.Y - 1;
                        break;
                }
                
                Utilities.Position position = new Position(x, y);
                if (Colony.IsValidPosition(position))
                {
                    Colony.ArenaModifyPosition(this.Position, ' ');
                    this.Position = position;
                    Colony.ArenaModifyPosition(this.Position, _name);
                    
                    loop = false;
                }
            }
        }
    }
}