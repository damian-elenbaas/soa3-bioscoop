
namespace Bioscoop.Core.Models;

public class PremiumTicketStudentBehavior : IPremiumTicketBehavior
{
    public double CalculatePremiumPriceAddition(MovieTicket ticket)
    {
        if (ticket.IsPremiumTicket)
        {
            return Prices.STUDENT_EXTRA_PREMIUM_PRICE;
        }
        else
        {
            return 0d;
        }
    }
}
