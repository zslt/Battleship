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

        public Grid(int size)
        {
            //TODO: validate, max size 10
            Size = size;

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
            var columnLetters = new List<Letter>((Letter[])Enum.GetValues(typeof(Letter))).Take(Size);
            var text = ("    " + string.Join(" ", columnLetters.Select(x => x.ToString())) + "\n   ");
            text += string.Concat(Enumerable.Repeat("__", columnLetters.Count())) + "\n";

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