using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleship.Library.Model;

namespace Battleship.Cli.Model
{
    public class Grid
    {
        private const int maxSize = 10;

        public int Size { get; }

        public int[,] GridData { get; }

        public IList<Letter> ColumnLetters { get; }

        public Grid(int size)
        {
            if (size == 0)
            {
                throw new ArgumentException($"{nameof(size)} cannot be zero.");
            }

            if (size < 0)
            {
                throw new ArgumentException($"{nameof(size)} cannot be negative.");
            }

            if (size > maxSize)
            {
                throw new ArgumentException($"{nameof(size)} has the maximum value of {maxSize}.");
            }

            Size = size;
            ColumnLetters = new List<Letter>((Letter[])Enum.GetValues(typeof(Letter)))
                .Take(Size)
                .ToList();
            GridData = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    GridData[i, j] = 0;
                }
            }
        }

        public override string ToString()
        {            
            var text = ("    " + string.Join(" ", ColumnLetters.Select(x => x.ToString())) + "\n   ");
            text += string.Concat(Enumerable.Repeat("__", ColumnLetters.Count())) + "\n";

            for (int i = 0; i < Size; i++)
            {
                var rowTexts = new List<string>();
                var rowNumber = i < maxSize - 1 ? $"{i + 1} | " : $"{i + 1}| ";
                rowTexts.Add(rowNumber);

                for (int j = 0; j < Size; j++)
                {
                    rowTexts.Add(j < Size - 1 ? $"{GridData[i, j]} " : $"{GridData[i, j]}\n");                    
                }

                var rowText = string.Join("", rowTexts);
                text += rowText;
            }

            return text;
        }
    }
}