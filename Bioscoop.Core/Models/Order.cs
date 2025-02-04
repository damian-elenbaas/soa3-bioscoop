
namespace Bioscoop.Core.Models;

public class Order(int orderNr, bool isStudentOrder)
{
    private int OrderNr { get; } = orderNr;
    private bool IsStudentOrder { get; } = isStudentOrder;
    private IList<MovieTicket> MovieTickets { get; set; } = [];

    public int GetOrderNr() => OrderNr;

    public void AddSeatReservation(MovieTicket ticket)
    {
        MovieTickets.Add(ticket);
    }

    public double CalculatePrice()
    {
        throw new NotImplementedException();
    }

    public void Export(TicketExportFormat exportFormat)
    {
        throw new NotImplementedException();
    }
}
