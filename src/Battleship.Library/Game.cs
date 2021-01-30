using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Library.Model;

namespace Battleship.Library
{
    public class Game : IGame
    {
        private readonly BattleshipConfiguration config;
        private IList<Ship> ships;
        private int remainingShips;
        
        public event ShipSunkHandler ShipSunk;        
        public event EventHandler AllShipsSunk;

        public Game(BattleshipConfiguration config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Start()
        {
            //TODO: validate number of ships >1 and <=5
            ships = config.Ships
                .SelectMany(x => Enumerable.Range(0, x.Quantity)
                .Select(y => new Ship(config.GridSize, x.Size, x.Name)))
                .ToList();

            remainingShips = ships.Count;

            for (int i = 0; i < ships.Count; i++)
            {
                ships[i].SetPosition();

                for (int j = 1; j < ships.Count; j++)
                {
                    ships[j].RemovePosition(ships[i].Position);
                }
            }
        }

        public bool Fire(Location location)
        {
            foreach (var ship in ships)
            {
                if (ship.IsHit(location))
                {
                    ship.DecrementHealth();

                    if (ship.Health == 0)
                    {
                        OnShipSunk(ship);
                        remainingShips -= 1;
                    }

                    if (remainingShips == 0)
                    {
                        OnAllShipsSunk();
                    }

                    return true;
                }
            }

            return false;
        }

        internal void OnShipSunk(Ship ship)
        {
            ShipSunkHandler handler = ShipSunk;
            handler?.Invoke(this, new ShipSunkEventArgs { Name = ship.Name });
        }

        internal void OnAllShipsSunk()
        {
            EventHandler handler = AllShipsSunk;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }        
}