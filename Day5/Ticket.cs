namespace Day5
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public Seat GetSeat()
        {
            return new Seat(TicketId);
        }

    }
}