using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Library.Model;

namespace Battleship.Library
{
    public class Game : IGame
    {
        private readonly BattleshipConfiguration config;

        public IList<Ship> Ships { get; private set; }

        public Game(BattleshipConfiguration config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Start()
        {
            //TODO: validate number of ships >1 and <=5
            Ships = config.Ships
                .SelectMany(x => Enumerable.Range(0, x.Amount)
                .Select(y => new Ship(config.GridSize, x.Size, x.Name)))
                .ToList();

            for (int i = 0; i < Ships.Count; i++)
            {
                Ships[i].SetPosition();

                for (int j = 1; j < Ships.Count; j++)
                {
                    Ships[j].RemovePosition(Ships[i].Position);
                }
            }
        }

        public bool Fire(Location location)
        {
            foreach (var ship in Ships)
            {
                if (ship.IsHit(location))
                {
                    ship.DecrementHealth();
                    return true;
                }
            }

            return false;
        }
    }        
}