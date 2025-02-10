
namespace Bioscoop.Core.Models;

public interface IPremiumTicketBehavior
{
    double CalculatePremiumPriceAddition(MovieTicket ticket);
}
