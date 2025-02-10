
namespace Bioscoop.Core.Models;

public class PremiumTicketNonStudentBehavior : IPremiumTicketBehavior
{
    public double CalculatePremiumPriceAddition(MovieTicket ticket)
    {
        if (ticket.IsPremiumTicket)
        {
            return Prices.STANDARD_EXTRA_PREMIUM_PRICE;
        }
        else
        {
            return 0d;
        }
    }
}
