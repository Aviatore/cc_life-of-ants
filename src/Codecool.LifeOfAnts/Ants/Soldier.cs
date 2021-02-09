namespace Codecool.LifeOfAnts.Ants
{
    using System;
    using Codecool.LifeOfAnts.Utilities;

    public class Soldier : Ant
    {
        public Soldier(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
            _name = 'S';
            
            colony.OnMove += Move;
        }

        public override void Move(object sender, EventArgs args)
        {
            int x = 0;
            int y = 0;

            bool loop = true;
            
            while (loop)
            {
                switch (this._direction)
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
                if (_colony.IsValidPosition(position))
                {
                    _colony.ArenaModifyPosition(this.Position, ' ');
                    this.Position = position;
                    _colony.ArenaModifyPosition(this.Position, _name);
                    
                    TurnLeft();

                    loop = false;
                }
                else
                {
                    Console.WriteLine($"Pos: {position.X} {position.Y} {this._direction}");
                    Console.ReadKey();
                }
            }
        }

        private void TurnLeft()
        {
            if (this._direction > Direction.North)
            {
                this._direction--;
            }
            else
            {
                this._direction = Direction.West;
            }
        }
    }
}