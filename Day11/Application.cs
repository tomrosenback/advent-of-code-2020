using Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    public class Application
    {
        public Application(string file)
        {
            Rows = HelperMethods.GetRows(file, row =>
            {
                var positions = new List<Position>();

                foreach (var position in row.ToCharArray())
                {
                    positions.Add(new Position(position));
                }

                return positions;

            }).ToList();

            SetAdjacents(true);
        }

        private void SetAdjacents(bool onlyNearest)
        {
            ClearAdjacents();

            var rowCount = Rows.Count;
            var rowPosCount = Rows.First().Count;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < rowPosCount; j++)
                {
                    // horizontal
                    SetAdjacents(i, j, 0, 1, onlyNearest);
                    SetAdjacents(i, j, 0, -1, onlyNearest);

                    // vertical
                    SetAdjacents(i, j, 1, 0, onlyNearest);
                    SetAdjacents(i, j, -1, 0, onlyNearest);

                    // diagonals
                    SetAdjacents(i, j, 1, 1, onlyNearest);
                    SetAdjacents(i, j, 1, -1, onlyNearest);
                    SetAdjacents(i, j, -1, 1, onlyNearest);
                    SetAdjacents(i, j, -1, -1, onlyNearest);
                }
            }
        }

        private void SetAdjacents(int row, int col, int rowInc, int posInc, bool onlyNearest)
        {
            var rowCount = Rows.Count;
            var rowPosCount = Rows.First().Count;
            List<List<int>> adjacents = new List<List<int>>();

            for (int i = row + rowInc; i >= 0 && i < rowCount; i += rowInc)
            {
                for (int j = col + posInc; j >= 0 && j < rowPosCount; j += posInc)
                {
                    if (i >= 0 && i < rowCount && j >= 0 && j <= rowPosCount)
                    {
                        adjacents.Add(new List<int>() { i, j });
                    }

                    if (onlyNearest)
                    {
                        break;
                    }
                }

                if (onlyNearest)
                {
                    break;
                }
            }

            if (adjacents.Any())
            {
                Rows[row][col].Adjacents.Add(adjacents);
            }
        }

        public int NumberOfSeatsOccupied => Rows.SelectMany(r => r).Where(p => p.Occupied).Count();

        public void ClearSeats()
        {
            foreach (var row in Rows)
            {
                foreach (var pos in row.Where(p => p.IsSeat && p.Occupied))
                {
                    pos.Occupied = false;
                    pos.NewOccupation = false;
                    pos.Dirty = false;
                }
            }
        }

        public void ClearAdjacents()
        {
            foreach (var row in Rows)
            {
                foreach (var pos in row.Where(p => p.Adjacents.Any()))
                {
                    pos.Adjacents.Clear();
                }
            }
        }

        public void FillSeatsByNearestAdjacent()
        {
            ClearSeats();
            SetAdjacents(true);
            FillSeats(4);
        }

        public void FillSeatsByAnyAdjacent()
        {
            ClearSeats();
            SetAdjacents(false);
            FillSeats(5);
        }

        private void FillSeats(int minNumberOfOccupiedAdjacents)
        {
            int seatsOccupied = NumberOfSeatsOccupied;

            foreach (var row in Rows)
            {
                foreach (var pos in row.Where(p => p.IsSeat))
                {
                    int adjacentsOccupied = 0;

                    foreach (var adjacents in pos.Adjacents)
                    {
                        foreach (var adjacentPos in adjacents)
                        {
                            if(Rows[adjacentPos.First()][adjacentPos.Last()].Occupied)
                            {
                                adjacentsOccupied++;
                                break;
                            }
                        }
                    }

                    if (!pos.Occupied && adjacentsOccupied == 0)
                    {
                        pos.Dirty = true;
                        pos.NewOccupation = true;
                    }
                    else if (pos.Occupied && adjacentsOccupied >= minNumberOfOccupiedAdjacents)
                    {
                        pos.Dirty = true;
                        pos.NewOccupation = false;
                    }
                }
            }

            foreach (var row in Rows)
            {
                foreach (var pos in row)
                {
                    if (pos.Dirty)
                    {
                        pos.Occupied = pos.NewOccupation;
                        pos.Dirty = false;
                    }
                }
            }

            if (seatsOccupied != NumberOfSeatsOccupied)
            {
                FillSeats(minNumberOfOccupiedAdjacents);
            }
        }

        public List<List<Position>> Rows { get; set; }
    }
}
