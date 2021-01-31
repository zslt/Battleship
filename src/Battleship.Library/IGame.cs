using System;
using Battleship.Library.Model;

namespace Battleship.Library
{    
    public interface IGame
    {
        event EventHandler<ShipSunkEventArgs> ShipSunk;
        
        event EventHandler AllShipsSunk;

        void Start();

        bool Fire(Location location);
    }
}