using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Battleship.Cli.Model;
using Battleship.Library;
using Battleship.Library.Model;
using Microsoft.Extensions.Configuration;

namespace Battleship.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var appsettings = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var section = appsettings.GetSection(nameof(BattleshipConfiguration));
            var config = section.Get<BattleshipConfiguration>();

            var game = new Game(config);
            game.Start();
            GameLoop(game, new Grid(config.GridSize));

            Console.WriteLine("Game ends.");

            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        public static void GameLoop(Game game, Grid grid)
        {
            Console.WriteLine(grid.ToString());
            Console.WriteLine("Press ESC to stop. Or fire at will!");

            string input = null;

            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Backspace:
                        if (!string.IsNullOrEmpty(input))
                        {
                            input = input.Substring(0, input.Length - 1);
                        }
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                        Console.Write(input);
                        break;
                    case ConsoleKey.Enter:
                        var column = (int)Enum.Parse(typeof(Letter), input.Substring(0,1), true);
                        var row = input.Length == 2
                            ? int.Parse(input.Substring(1, 1)) - 1
                            : int.Parse(input.Substring(1, 2)) - 1;

                        var isHit = game.Fire(new Location(row, column));

                        grid.GridData[row, column] = isHit ? 2 : 1;

                        input = null;
                        Console.WriteLine("\n" + grid.ToString());
                        Console.WriteLine("Press ESC to stop. Or fire at will!");
                        break;
                    default:
                        input += key.KeyChar;
                        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                        Console.Write(input);
                        break;
                }
            }
        }
    }
}