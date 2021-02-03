using System;
using Battleship.Library.Model;

namespace Battleship.Library
{    
    public interface IShipFactory
    {
        Ship Create(ShipConfiguration ship);
    }
}