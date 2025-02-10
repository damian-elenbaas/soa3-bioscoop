
namespace Bioscoop.Core.Models;

public interface IGroupDiscountBehavior
{
    double CalculateGroupDiscountOfTicket(int groupSize);
}
