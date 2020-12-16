using System;

namespace Day12
{
    public class Ship
    {
        public Ship()
        {
            Orientation = 90;
            WayPoint = new WayPoint();
        }

        public int Orientation { get; set; }
        public int NorthPos { get; set; }
        public int EastPos { get; set; }
        public int ManhattanDistance => Math.Abs(NorthPos) + Math.Abs(EastPos);
        public WayPoint WayPoint { get; set; }

        public void Move(Move move, bool waypointMove)
        {
            /*
            
            Action N means to move north by the given value.
            Action S means to move south by the given value.
            Action E means to move east by the given value.
            Action W means to move west by the given value.
            Action L means to turn left the given number of degrees.
            Action R means to turn right the given number of degrees.
            Action F means to move forward by the given value in the direction the ship is currently facing.

            */

            switch (move.Type)
            {
                case "N":
                    if (waypointMove)
                    {
                        WayPoint.NorthPos += move.Amount;
                    }
                    else
                    {
                        NorthPos += move.Amount;
                    }
                    break;
                case "S":
                    if (waypointMove)
                    {
                        WayPoint.NorthPos -= move.Amount;
                    }
                    else
                    {
                        NorthPos -= move.Amount;
                    }
                    break;
                case "E":
                    if (waypointMove)
                    {
                        WayPoint.EastPos += move.Amount;
                    }
                    else
                    {
                        EastPos += move.Amount;
                    }
                    break;
                case "W":
                    if (waypointMove)
                    {
                        WayPoint.EastPos -= move.Amount;
                    }
                    else
                    {
                        EastPos -= move.Amount;
                    }
                    break;
                case "L":
                    if (waypointMove)
                    {
                        WayPoint.SetOrientation(move);
                    }
                    else
                    {
                        Orientation -= move.Amount;
                    }
                    break;
                case "R":
                    if (waypointMove)
                    {
                        WayPoint.SetOrientation(move);
                    }
                    else
                    {
                        Orientation += move.Amount;
                    }
                    break;
                case "F":
                    int amount = move.Amount;
                    if (waypointMove)
                    {
                        NorthPos += WayPoint.NorthPos * amount;
                        EastPos += WayPoint.EastPos * amount;
                    }
                    else
                    {
                        MoveForward(amount);
                    }
                    break;
                default:
                    break;
            }

            AdjustOrientation();
        }

        private void MoveForward(int amount)
        {
            switch (Orientation)
            {
                case 0:
                    Move(new Move("N" + amount), false);
                    break;
                case 90:
                    Move(new Move("E" + amount), false);
                    break;
                case 180:
                    Move(new Move("S" + amount), false);
                    break;
                case 270:
                    Move(new Move("W" + amount), false);
                    break;
            }
        }

        private void AdjustOrientation()
        {
            if (Orientation < 0)
            {
                Orientation += 360;
            }
            else if (Orientation >= 360)
            {
                Orientation -= 360;
            }
        }
    }
}