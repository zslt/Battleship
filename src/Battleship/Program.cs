using System;

namespace Battleship
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

            var grid = new Grid(config.GridSize);            
            var game = new Game(config);
        }
    }
}