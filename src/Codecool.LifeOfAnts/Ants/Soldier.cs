using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.Ants
{
    public class Soldier : Ant
    {
        public Soldier(Position position, Direction direction, Colony colony)
            : base(position, direction, colony)
        {
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}