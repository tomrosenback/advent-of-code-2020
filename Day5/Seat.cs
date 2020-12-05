namespace Day5
{
    public class Seat
    {
        public Seat()
        {

        }

        public Seat(string ticketId)
        {
            // parse seat
            if (ticketId.Length == 10)
            {
                Row = ParseSeat(ticketId.Substring(0, 7), 127, 'F', 'B');
                Column = ParseSeat(ticketId.Substring(7), 7, 'L', 'R');
            }
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatId => Row * 8 + Column;
        public int SeatIdValidation { get; set; }

        private int ParseSeat(string data, int max, char lower, char upper)
        {
            int min = 0;

            // parse column
            for (int i = 0; i < data.Length; i++)
            {
                var chr = data[i];
                int half = (max - min) / 2;

                if (chr == lower)
                {
                    max = half + min;
                }
                else if (chr == upper)
                {
                    min = max - half;
                }
            }

            return min;
        }
    }
}