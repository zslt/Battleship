using System;

namespace Battleship.BLL.Model
{
    public class Location
    {
        public int Row { get; }
        public int Column { get; }
        
        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj) =>
            return obj is Location && this == (Location)obj;

        public override int GetHashCode() => (Row, Column).GetHashCode();

        public static bool operator ==(Location x, Location y) =>
            x.Row == y.Row && x.Column == y.Column;

        public static bool operator !=(Location x, Location y) => return !(x == y);
    }
}