
namespace Bioscoop.Core.Models;

public class PaidOrderState : IOrderState 
{

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
        order.SetState(new CompletedOrderState(order));
    }

    public void CancelOrder()
    {

    }

}
