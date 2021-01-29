using System.Collections.Generic;

namespace Battleship.Library.Model
{
    public class BattleshipConfiguration
    {
        public int GridSize { get; set; }
        public List<ShipConfiguration> Ships { get; set; }
    }
}