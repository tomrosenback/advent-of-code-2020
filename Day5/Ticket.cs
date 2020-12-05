namespace Day5
{
    public class Ticket
    {
        public Ticket()
        {

        }

        public Ticket(string ticketId)
        {
            TicketId = ticketId;

            // parse seat
            if (ticketId.Length == 10)
            {
                Row = ParseSeat(ticketId.Substring(0, 7), 127, 'F');
                Column = ParseSeat(ticketId.Substring(7), 7, 'L');
            }
        }

        public string TicketId { get; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatId => Row * 8 + Column;

        private int ParseSeat(string data, int max, char lower)
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
                else
                {
                    min = max - half;
                }
            }

            return min;
        }
    }
}