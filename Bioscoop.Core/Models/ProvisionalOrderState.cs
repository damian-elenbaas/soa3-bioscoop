
namespace Bioscoop.Core.Models;

public class ProvisionalOrderState(Order order) : IOrderState
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
        order.SetState(new PaidOrderState(order));
    }

    public void SentOrder()
    {

    }

    public void CancelOrder()
    {
        order.SetState(new CanceledOrderState(order));
    }

}
