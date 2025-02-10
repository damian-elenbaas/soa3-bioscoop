
namespace Bioscoop.Core.Models;

public class GroupDiscountNonStudentBehavior : IGroupDiscountBehavior
{
    public double CalculateGroupDiscountOfTicket(int groupSize)
    {
        if (groupSize >= 6)
        {
            return 0.10;
        }
        else
        {
            return 0d;
        }
    }
}
