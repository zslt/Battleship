using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Library.Model;

namespace Battleship.Library.Test
{
    public class GameTests
    {
        [Test]
        public void Game_raises_event_when_a_ship_sinks()
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
                        Size = 1,                        
                    }
                }
            };
            var game = new Game(config, new FirsAvailablePositionShipFactory(config.GridSize));

            var shipSunkRaised = false;
            game.ShipSunk += (o,e) => shipSunkRaised = true;

            game.Start();

            // Act
            game.Fire(new Location(0, 0));

            // Assert
            Assert.IsTrue(shipSunkRaised);
        }

        [Test]
        public void Game_raises_event_when_all_ships_have_sunk()
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
                        Size = 1,                        
                    }
                } 
            };
            var game = new Game(config, new FirsAvailablePositionShipFactory(config.GridSize));

            var allShipsSunkRaised = false;
            game.AllShipsSunk += (o,e) => allShipsSunkRaised = true;

            game.Start();

            // Act
            game.Fire(new Location(0, 0));

            // Assert
            Assert.IsTrue(allShipsSunkRaised);
        }
    }
}