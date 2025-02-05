
using System.Text.Json;

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
        string? projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        switch (exportFormat)
        {
            case TicketExportFormat.PLAINTEXT:
                ExportToPlainText(projectDirectory);
                break;
            case TicketExportFormat.JSON:
                ExportToJSON(projectDirectory);
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
                var isWeekDay = dateAndTime.Day >= 1 && dateAndTime.Day <= 4;

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

    private void ExportToPlainText(string? projectDirectory)
    {
        var text = $"OrderNr: {OrderNr}\nIsStudentOrder: {IsStudentOrder}\nMovieTickets:\n";
        text += string.Join("\n - ", MovieTickets.Select(ticket => ticket.ToString()));
        File.WriteAllText(Path.Combine(projectDirectory ?? "", "order.txt"), text);
    }

    private void ExportToJSON(string? projectDirectory)
    {
        var json = new
        {
            OrderNr,
            IsStudentOrder,
            MovieTickets = MovieTickets.Select(ticket => new
            {
                MovieScreening = new
                {
                    Movie = new
                    {
                        Title = ticket.GetMovieScreening.GetMovie.GetTitle
                    },
                    DateAndTime = ticket.GetMovieScreening.GetDateAndTime,
                    PricePerSeat = ticket.GetMovieScreening.GetPricePerSeat
                },
                RowNr = ticket.GetRowNr,
                SeatNr = ticket.GetSeatNr,
                ticket.IsPremiumTicket
            })
        };
        var jsonString = JsonSerializer.Serialize(json);
        File.WriteAllText(Path.Combine(projectDirectory ?? "", "order.json"), jsonString);
    }
}
