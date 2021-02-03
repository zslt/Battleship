using System;
using Battleship.Library.Model;

namespace Battleship.Library
{    
    public class RandomPositionShipFactory : IShipFactory
    {
        private readonly int gridSize;

        public RandomPositionShipFactory(int gridSize)
        {
            this.gridSize = gridSize;
        }

        public Ship Create(ShipConfiguration ship) => new Ship(gridSize, ship.Size, ship.Name);
    }
}