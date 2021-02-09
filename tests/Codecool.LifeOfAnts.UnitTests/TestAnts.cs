using System;
using NUnit.Framework;
using Codecool.LifeOfAnts;
using Codecool.LifeOfAnts.Utilities;

namespace Codecool.LifeOfAnts.UnitTests
{
    [TestFixture]
    public class TestAnts
    {
        [Test]
        public void TestGetValidPosition()
        {
            Colony colony = new Colony(10);
            Position position = colony.GetValidPosition();
            
            Assert.IsTrue(position.X >= 0 && position.Y <= 10);
        }
    }
}