
namespace Bioscoop.Core.Models;

public class CanceledOrderState(Order order) : IOrderState 
{
    private readonly Order parentOrder = order;

    public void CreateOrder(int ticketCount, MovieScreening movieScreening, bool parkingCard)
    {

    }

    public void SubmitOrder()
    {

    }

    public void UpdateOrder()
    {

    }

    public void SentReminder()
    {

    }

    public void PayOrder()
    {

    }

    public void SentOrder()
    {

    }

    public void CancelOrder()
    {

    }

}
