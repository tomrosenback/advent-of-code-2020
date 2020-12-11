using System.Collections.Generic;

namespace Day11
{
    public class Position
    {
        public Position(char position)
        {
            IsSeat = position == 'L' || position == '#';
            Occupied = position == '#';
            NewOccupation = false;
            Dirty = false;
            Adjacents = new List<List<Position>>();
        }

        public bool IsSeat { get; set; }
        public bool Occupied { get; set; }
        public bool NewOccupation { get; set; }
        public bool Dirty { get; set; }
        public List<List<Position>> Adjacents { get; set; }
    }
}
