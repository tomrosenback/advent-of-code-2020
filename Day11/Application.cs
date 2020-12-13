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

            RowsCount = Rows.Count;
            RowPosCount = Rows.First().Count();
        }

        private int GetAdjacentsOccupied(int row, int col, int rowInc, int posInc, bool onlyNearest)
        {
            var rowCount = Rows.Count;
            var rowPosCount = Rows.First().Count;
            int occupiedAdjacents = 0;

            for (int i = row + rowInc; i >= 0 && i < rowCount; i += rowInc)
            {
                for (int j = col + posInc; j >= 0 && j < rowPosCount; j += posInc)
                {
                    if (i >= 0 && i < rowCount && j >= 0 && j <= rowPosCount && Rows[i][j].IsSeat && Rows[i][j].Occupied)
                    {
                        occupiedAdjacents++;
                        break;
                    }

                    if (onlyNearest || occupiedAdjacents > 0)
                    {
                        break;
                    }
                }

                if (onlyNearest || occupiedAdjacents > 0)
                {
                    break;
                }
            }

            return occupiedAdjacents;
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

        public void FillSeatsByNearestAdjacent()
        {
            ClearSeats();
            FillSeats(4, true);
        }

        public void FillSeatsByAnyAdjacent()
        {
            ClearSeats();
            FillSeats(5, false);
        }

        private void FillSeats(int minNumberOfOccupiedAdjacents, bool onlyNearestAdjacents)
        {
            int seatsOccupied = NumberOfSeatsOccupied;

            for (int row = 0; row < Rows.Count(); row++)
            {
                for (int pos = 0; pos < Rows[row].Count; pos++)
                {
                    if (Rows[row][pos].IsSeat)
                    {
                        int adjacentsOccupied = 0;

                        // horizontal
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, 0, 1, onlyNearestAdjacents);
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, 0, -1, onlyNearestAdjacents);

                        // vertical
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, 1, 0, onlyNearestAdjacents);
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, -1, 0, onlyNearestAdjacents);

                        // diagonals
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, 1, 1, onlyNearestAdjacents);
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, 1, -1, onlyNearestAdjacents);
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, -1, 1, onlyNearestAdjacents);
                        adjacentsOccupied += GetAdjacentsOccupied(row, pos, -1, -1, onlyNearestAdjacents);

                        if (!Rows[row][pos].Occupied && adjacentsOccupied == 0)
                        {
                            Rows[row][pos].Dirty = true;
                            Rows[row][pos].NewOccupation = true;
                        }
                        else if (Rows[row][pos].Occupied && adjacentsOccupied >= minNumberOfOccupiedAdjacents)
                        {
                            Rows[row][pos].Dirty = true;
                            Rows[row][pos].NewOccupation = false;
                        }
                    }
                }
            }

            foreach (var row in Rows)
            {
                foreach (var pos in row.Where(p => p.IsSeat))
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
                FillSeats(minNumberOfOccupiedAdjacents, onlyNearestAdjacents);
            }
        }

        public List<List<Position>> Rows { get; set; }
        public int RowsCount { get; private set; }
        public int RowPosCount { get; }
    }
}
