using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Library.Model;

namespace Battleship.Library.Test
{
    public class ConfigurationValidatorTests
    {

        [Test]
        public void Grid_size_cannot_be_negative()
        {
            // Arrange
            var config = new BattleshipConfiguration
            {
                GridSize = -1,
                Ships = new List<ShipConfiguration>()
                {
                    new ShipConfiguration
                    {
                        Name = "ship",
                        Quantity = 1,
                        Size = 1,                        
                    }
                } 
            };

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Game(config));
            Assert.That(exception.Message, Is.EqualTo("GridSize cannot be negative."));
        }

        [Test]
        public void Grid_size_cannot_be_zero()
        {
            // Arrange
            var config = new BattleshipConfiguration
            {
                GridSize = 0,
                Ships = new List<ShipConfiguration>()
                {
                    new ShipConfiguration
                    {
                        Name = "ship",
                        Quantity = 1,
                        Size = 1,                        
                    }
                } 
            };

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Game(config));
            Assert.That(exception.Message, Is.EqualTo("GridSize cannot be zero."));
        }

        [Test]
        public void Grid_size_cannot_be_greater_than_ten()
        {
            // Arrange
            var config = new BattleshipConfiguration
            {
                GridSize = 11,
                Ships = new List<ShipConfiguration>()
                {
                    new ShipConfiguration
                    {
                        Name = "ship",
                        Quantity = 1,
                        Size = 1,                        
                    }
                } 
            };

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Game(config));
            Assert.That(exception.Message, Is.EqualTo("GridSize has the maximum value of 10."));
        }

        [Test]
        public void Ship_size_cannot_be_greater_than_grid_size()
        {
            // Arrange
            var config = new BattleshipConfiguration
            {
                GridSize = 1,
                Ships = new List<ShipConfiguration>()
                {
                    new ShipConfiguration
                    {
                        Name = "ship",
                        Quantity = 1,
                        Size = 2,                        
                    }
                } 
            };

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Game(config));
            Assert.That(exception.Message, Is.EqualTo("A ship cannot have greater size than the gird size."));
        }

        [Test]
        public void Ship_size_cannot_be_zero()
        {
            // Arrange
            var config = new BattleshipConfiguration
            {
                GridSize = 1,
                Ships = new List<ShipConfiguration>()
                {
                    new ShipConfiguration
                    {
                        Name = "ship",
                        Quantity = 1,
                        Size = 0,                        
                    }
                } 
            };

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Game(config));
            Assert.That(exception.Message, Is.EqualTo("A ship cannot have size zero."));
        }

        [Test]
        public void Ships_cannot_be_empty()
        {
            // Arrange
            var config = new BattleshipConfiguration
            {
                GridSize = 1,
                Ships = new List<ShipConfiguration>() 
            };

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Game(config));
            Assert.That(exception.Message, Is.EqualTo("Ships must have at leas one ship."));
        }

        [Test]
        public void Total_ship_size_cannot_be_greater_than_grid_area()
        {
            // Arrange
            var config = new BattleshipConfiguration
            {
                GridSize = 2,
                Ships = new List<ShipConfiguration>()
                {
                    new ShipConfiguration
                    {
                        Name = "ship",
                        Quantity = 5,
                        Size = 1,                        
                    }
                } 
            };

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Game(config));
            Assert.That(exception.Message, Is.EqualTo("Total ship size is larger than available space on the gird."));
        }
    }
}