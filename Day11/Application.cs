using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    foreach (var row in new int[] { -1, 0, 1 })
                    {
                        foreach (var pos in new int[] { -1, 0, 1 })
                        {
                            Rows[i][j].Adjacents.Add(FindAdjacents(i, j, row, pos));
                        }
                    }
                    
                    var minRow = onlyNearest ? 1 : i;
                    var minPos = onlyNearest ? 1 : j;

                    if (minRow > minPos)
                    {
                        minPos = minRow;
                    }
                    else if (minPos > minRow)
                    {
                        minRow = minPos;
                    }

                    for (int row = -minRow; row <= minRow; row++)
                    {
                        var adjacentRow = i + row;

                        for (int pos = -minPos; pos <= minPos; pos++)
                        {
                            var adjacentPos = j + pos;

                            if (adjacentRow >= 0 && adjacentRow < rowCount && adjacentPos >= 0 && adjacentPos < rowPosCount && i * rowPosCount + j != adjacentRow * rowPosCount + adjacentPos)
                            {
                                Rows[i][j].Adjacents.Add(Rows[adjacentRow][adjacentPos]);
                            }
                        }
                    }
                }
            }
        }

        private List<Position> FindAdjacents(int row, int col, int rowInc, int posInc)
        {
            throw new NotImplementedException();
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
                    var adjacentsOccupied = pos.Adjacents.Where(p => p.Occupied).Count();

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
