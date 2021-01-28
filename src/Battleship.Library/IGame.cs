namespace Battleship.BLL
{
    public interface IGame
    {
        void Start();

        bool Fire(Location location);
    }
}