using System.Collections.Generic;

namespace Battleship.BLL.Model
{
    public class BattleshipConfiguration
    {
        public int GridSize { get; set; }
        public List<ShipConfiguration> Ships { get; set; }
    }
}