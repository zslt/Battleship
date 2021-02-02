using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Library.Model;

namespace Battleship.Library.Test
{
    public class ShipTests
    {
        [Test]
        public void Ship_sets_last_position()
        {
            // Arrange
            var ship = new Ship(2, 1, "ship");
            ship.RemovePosition(new List<Location>()
            {
                new Location(0, 0),
                new Location(0, 1),
                new Location(1, 0)
            });

            // Act
            ship.SetPosition(0);

            // Assert
            Assert.AreEqual(ship.Position, new List<Location>() { new Location(1, 1) });
        }

        [Test]
        public void Ship_cannot_set_invalid_position()
        {
            // Arrange
            var ship = new Ship(2, 1, "ship");
            ship.RemovePosition(new List<Location>()
            {
                new Location(0, 0),
                new Location(0, 1),
                new Location(1, 0),
                new Location(1, 1)
            });

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ship.SetPosition(0));
        }
    }
}