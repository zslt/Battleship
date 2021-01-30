using System;
using Battleship.Library.Model;

namespace Battleship.Library
{
    public delegate void ShipSunkHandler(object sender, ShipSunkEventArgs e);
    
    public interface IGame
    {
        event ShipSunkHandler ShipSunk;
        
        event EventHandler AllShipsSunk;

        void Start();

        bool Fire(Location location);
    }
}