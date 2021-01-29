using Battleship.Library.Model;

namespace Battleship.Library
{
    public interface IGame
    {
        void Start();

        bool Fire(Location location);
    }
}