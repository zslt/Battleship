using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleship.Cli.Model;
using Battleship.Library;
using Battleship.Library.Model;

namespace Battleship.Cli
{
    public class ConsoleGame
    {
        private readonly IGame game;
        private readonly Grid grid;

        private readonly IList<ConsoleKey> validLetterKeys = new List<ConsoleKey>()
        {
            ConsoleKey.A,
            ConsoleKey.B,
            ConsoleKey.C,
            ConsoleKey.D,
            ConsoleKey.E,
            ConsoleKey.F,
            ConsoleKey.G,
            ConsoleKey.H,
            ConsoleKey.I,
            ConsoleKey.J
        };

        public ConsoleGame(IGame game, Grid grid)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.grid = grid ?? throw new ArgumentNullException(nameof(grid));
        }

        public void Start()
        {
            game.ShipSunk += (sender, e) => Console.WriteLine($"\n{e.Name} has sunk!");
            game.AllShipsSunk += (sender, e) =>
            {
                Console.WriteLine($"All ships have sunk!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            };

            game.Start();

            ConsoleWriteGame();

            var input = "";

            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        ClearConsoleLine();
                        Console.WriteLine("Game ends.");
                        return;
                    case ConsoleKey.Enter:
                        UpdateGame(input);
                        input = "";
                        Console.Write("\n");
                        ConsoleWriteGame();
                        break;
                    case ConsoleKey.Backspace:
                    default:
                        input = UpdateInput(input, key);
                        ClearConsoleLine();
                        Console.Write(input);                        
                        break;
                }
            }
        }

        private void UpdateGame(string input)
        {
            if (input == "") return;
            if (input.Length < 2 || input.Length > 3) return;

            var column = (int)Enum.Parse<Letter>(input.Substring(0,1), true);
            var row = input.Length == 2
                ? int.Parse(input.Substring(1, 1)) - 1
                : int.Parse(input.Substring(1, 2)) - 1;

            grid.GridData[row, column] = game.Fire(new Location(row, column)) ? 2 : 1;
        }

        private string UpdateInput(string input, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Backspace)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    return input.Substring(0, input.Length - 1);
                }
            }
            else
            {
                if (input.Length == 0
                    && validLetterKeys.Contains(key.Key)
                    && Enum.TryParse<Letter>(key.KeyChar.ToString(), true, out var letter)
                    && grid.ColumnLetters.Contains(letter))
                {
                    return input + key.KeyChar.ToString();
                }

                var isNumber = int.TryParse(key.KeyChar.ToString(), out var rowNumber);

                if (input.Length == 1 
                    && isNumber && 1 <= rowNumber && rowNumber <= grid.Size)
                {
                    return input + key.KeyChar.ToString();
                }

                if (grid.Size == 10
                    && input.Length == 2
                    && int.Parse(input.Substring(1, 1)) == 1
                    && isNumber && rowNumber == 0)
                {
                    return input + key.KeyChar.ToString();
                }
            }

            return input;
        }

        private void ClearConsoleLine()
        {
            Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
        }

        private void ConsoleWriteGame()
        {
            Console.WriteLine(grid.ToString());
            Console.WriteLine("1 is a miss. 2 is a hit.");
            Console.WriteLine("Press ESC to stop. Or fire at will!");
        }
    }
}