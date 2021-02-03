using System;
using Battleship.Library.Model;

namespace Battleship.Library
{    
    public class FirsAvailablePositionShipFactory : IShipFactory
    {
        private readonly int gridSize;

        public FirsAvailablePositionShipFactory(int gridSize)
        {
            this.gridSize = gridSize;
        }

        public Ship Create(ShipConfiguration ship) => new Ship(gridSize, ship.Size, ship.Name, false);
    }
}