
using System.Text.Json;

namespace Bioscoop.Core.Models;

public class Order(int orderNr, bool isStudentOrder)
{
    private int OrderNr { get; } = orderNr;
    private bool IsStudentOrder { get; } = isStudentOrder;
    private IList<MovieTicket> MovieTickets { get; set; } = [];

    private IExportBehavior ExportBehavior { get; set; }

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
        if (IsStudentOrder)
        {
            return CalculateStudentPrice();
        }
        else
        {
            return CalculateNonStudentPrice();
        }
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

    private double CalculateStudentPrice()
    {
        return MovieTickets
            .Select((ticket, index) =>
            {
                var ticketNr = index + 1;
                // Elke 2e ticket is gratis.
                if (ticketNr % 2 == 0)
                {
                    return 0d;
                }

                var price = ticket.GetPrice();

                if (ticket.IsPremiumTicket)
                {
                    price += Prices.STUDENT_EXTRA_PREMIUM_PRICE;
                }

                return price;
            })
            .Sum();
    }

    private double CalculateNonStudentPrice()
    {
        var hasGroupDiscount = MovieTickets.Count >= 6;

        return MovieTickets
            .Select((ticket, index) =>
            {
                var ticketNr = index + 1;
                var dateAndTime = ticket.GetDateAndTime();

                // ma/di/wo/do
                var isWeekDay = dateAndTime.DayOfWeek >= DayOfWeek.Monday && dateAndTime.DayOfWeek <= DayOfWeek.Thursday;

                // elke 2e ticket gratis bij een doordeweekse dag.
                if (ticketNr % 2 == 0 && isWeekDay)
                {
                    return 0d;
                }

                var price = ticket.GetPrice();

                if (ticket.IsPremiumTicket)
                {
                    price += Prices.STANDARD_EXTRA_PREMIUM_PRICE;
                }

                if (hasGroupDiscount)
                {
                    // 10 procent korting
                    price *= Prices.GROUP_DISCOUNT_PERCENTAGE;
                }

                return price;
            })
            .Sum();
    }
}
