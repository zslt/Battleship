using System;

namespace Battleship.Library.Model
{
    public class ShipSunkEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}