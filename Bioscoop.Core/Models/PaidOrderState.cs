
namespace Bioscoop.Core.Models;

public class PaidOrderState(Order order) : IOrderState
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

    public void SendReminder()
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
