using System;

namespace Day12
{
    public class WayPoint
    {
        public WayPoint()
        {
            NorthPos = 1;
            EastPos = 10;
        }
        public int NorthPos { get; set; }
        public int EastPos { get; set; }

        public void SetPos(int northPos, int eastPos)
        {
            NorthPos = northPos;
            EastPos = eastPos;
        }

        public void SetOrientation(Move move)
        {
            int north = NorthPos;
            int east = EastPos;

            if (move.Amount == 90)
            {
                if (move.Type == "L")
                {
                    NorthPos = east;
                    EastPos = -north;
                }
                else if (move.Type == "R")
                {
                    NorthPos = -east;
                    EastPos = north;
                }
            }
            else if (move.Amount == 180)
            {
                NorthPos = -north;
                EastPos = -east;
            }
            else if (move.Amount == 270)
            {
                if (move.Type == "L")
                {
                    NorthPos = -east;
                    EastPos = north;
                }
                else if (move.Type == "R")
                {
                    NorthPos = east;
                    EastPos = -north;
                }
            }
        }
    }
}
