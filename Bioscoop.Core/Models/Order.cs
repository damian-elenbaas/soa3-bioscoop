
namespace Bioscoop.Core.Models;

public class Order
{
    private int OrderNr { get; }
    private bool IsStudentOrder { get; }
    private IList<MovieTicket> MovieTickets { get; set; } = [];

    private IExportBehavior ExportBehavior { get; set; }
    public IFreeTicketBehavior FreeTicketBehavior { get; set; }
    public IGroupDiscountBehavior GroupDiscountBehavior { get; set; }
    public IPremiumTicketBehavior PremiumTicketBehavior { get; set; }

    public Order(int orderNr, bool isStudentOrder)
    {
        OrderNr = orderNr;
        IsStudentOrder = isStudentOrder;
        ExportBehavior = new ExportAsPlainText();

        if (IsStudentOrder)
        {
            FreeTicketBehavior = new FreeTicketStudentBehavior();
            GroupDiscountBehavior = new GroupDiscountStudentBehavior();
            PremiumTicketBehavior = new PremiumTicketStudentBehavior();
        }
        else
        {
            FreeTicketBehavior = new FreeTicketNonStudentBehavior();
            GroupDiscountBehavior = new GroupDiscountNonStudentBehavior();
            PremiumTicketBehavior = new PremiumTicketNonStudentBehavior();
        }
    }

    public int GetOrderNr() => OrderNr;
    public bool GetIsStudentOrder() => IsStudentOrder;
    public IList<MovieTicket> GetMovieTickets() => MovieTickets;

    public void SetExportBehavior(IExportBehavior exportBehavior)
    {
        ExportBehavior = exportBehavior;
    }

    public void AddSeatReservation(MovieTicket ticket)
    {
        MovieTickets.Add(ticket);
    }

    public double CalculatePrice()
    {
        return MovieTickets
            .Select((ticket, index) =>
            {
                var ticketNr = index + 1;
                if (FreeTicketBehavior.IsFree(ticketNr, ticket))
                {
                    return 0d;
                }

                var price = ticket.GetPrice();
                price += PremiumTicketBehavior.CalculatePremiumPriceAddition(ticket);
                price *= 1 - GroupDiscountBehavior.CalculateGroupDiscountOfTicket(MovieTickets.Count);

                return price;
            })
            .Sum();
    }

    public void Export(TicketExportFormat exportFormat)
    {
        switch (exportFormat)
        {
            case TicketExportFormat.PLAINTEXT:
                SetExportBehavior(new ExportAsPlainText());
                ExportBehavior.Export(this);
                break;
            case TicketExportFormat.JSON:
                SetExportBehavior(new ExportAsJson());
                ExportBehavior.Export(this);
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
