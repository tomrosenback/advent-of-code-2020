using Helpers;

namespace Day12
{
    public class Application
    {
        public static int MoveShip(string file, bool waypointMove)
        {
            var moves = HelperMethods.GetRows(file, row => new Move(row));
            var ship = new Ship();

            foreach (var move in moves)
            {
                ship.Move(move, waypointMove);
            }

            return ship.ManhattanDistance;
        }
    }
}
