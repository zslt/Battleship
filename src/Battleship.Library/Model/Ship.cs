using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.BLL.Models
{
    public class Ship
    {
        public IList<IList<Location>> AvailablePositions { get; private set; }        
        public IList<Location> Position { get; private set; }
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Ship(int gridSize, int shipSize, string name)
        {
            //TODO: validate size e.g, max size is 10, 0 is invalid, shipSize has to fit gridSize
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name == "") throw new ArgumentException(nameof(name));
            
            Health = shipSize;
            
            AvailablePositions = new List<IList<Location>>();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j <= gridSize - shipSize; j++)
                {
                    //horizontal
                    AvailablePositions.Add(Enumerable.Range(0, shipSize).Select(k => new Location(i, j + k)).ToList());
                    //vertical
                    AvailablePositions.Add(Enumerable.Range(0, shipSize).Select(k => new Location(j + k, i)).ToList());
                }
            }
        }

        public void SetPosition(int? index = null)
        {
            Position = AvailablePositions[index ?? new Random().Next(AvailablePositions.Count)];
        }

        public void RemovePosition(IList<Location> occupied)
        {            
            AvailablePositions = AvailablePositions
                .Where(available =>
                    occupied.All(oloc => 
                    !available.Any(aloc => aloc == oloc)))
                .ToList();
        }

        public bool IsHit(Location location)
        {
            return Position.Any(l => l == location);
        }

        public void DecrementHealth()
        {
            if (Health > 0)
            {
                Health -= 1;
            }
        }
    }
}