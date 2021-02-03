using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Library.Model;

namespace Battleship.Library
{
    internal static class ConfigurationValidator
    {
        private const int maxSize = 10;

        public static void Validate(this BattleshipConfiguration battleshipConfiguration)
        {
            if (battleshipConfiguration.GridSize == 0)
            {
                throw new ArgumentException($"{nameof(battleshipConfiguration.GridSize)} cannot be zero.");
            }

            if (battleshipConfiguration.GridSize < 0)
            {
                throw new ArgumentException($"{nameof(battleshipConfiguration.GridSize)} cannot be negative.");
            }

            if (battleshipConfiguration.GridSize > maxSize)
            {
                throw new ArgumentException($"{nameof(battleshipConfiguration.GridSize)} has the maximum value of {maxSize}.");
            }

            if (battleshipConfiguration.Ships.Any(x => string.IsNullOrEmpty(x.Name)))
            {
                throw new ArgumentException($"A ship must have a name.");
            }

            if (!battleshipConfiguration.Ships.Any())
            {
                throw new ArgumentException($"{nameof(battleshipConfiguration.Ships)} must have at leas one ship.");
            }

            if (battleshipConfiguration.Ships.Any(x => x.Size > battleshipConfiguration.GridSize))
            {
                throw new ArgumentException($"A ship cannot have greater size than the gird size.");
            }

            if (battleshipConfiguration.Ships.Any(x => x.Size == 0))
            {
                throw new ArgumentException($"A ship cannot have size zero.");
            }

            if (battleshipConfiguration.Ships.Any(x => x.Size < 0))
            {
                throw new ArgumentException($"A ship cannot have negative size.");
            }

            if (battleshipConfiguration.Ships.Sum(x => x.Size * x.Quantity) > Math.Pow(battleshipConfiguration.GridSize, 2))
            {
                throw new ArgumentException($"Total ship size is larger than available space on the gird.");
            }
        }
    }
}