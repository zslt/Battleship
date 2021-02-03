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
            
            var consoleGame = new ConsoleGame(
                new Game(config, new RandomPositionShipFactory(config.GridSize)),
                new Grid(config.GridSize));
            
            consoleGame.Start();

            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        } 
    }
}