using Codecool.LifeOfAnts.Utilities;

using System;

namespace Codecool.LifeOfAnts.Ants
{
    public class Soldier : Ant
    {
        public Soldier(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
            colony.OnMove += Move;
            _name = 'S';
        }

        public override void Move(object sender, EventArgs args)
        {
            int x = 0;
            int y = 0;

            bool loop = true;
            
            while (loop)
            {
                switch (this.Direction)
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
                    TurnLeft();

                    loop = false;
                }
                else
                {
                    Console.WriteLine($"Pos: {position.X} {position.Y} {this.Direction}");
                    Console.ReadKey();
                }
            }
        }

        private void TurnLeft()
        {
            if (this.Direction > Direction.North)
            {
                this.Direction--;
            }
            else
            {
                this.Direction = Direction.West;
            }
        }
    }
}