
namespace Bioscoop.Core.Models;

public class PaidOrderState(Order order) : IOrderState
{

    private readonly Order parentOrder = order;

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

    public void SendOrder()
    {
        order.SetState(new CompletedOrderState(order));
    }

    public void CancelOrder()
    {

    }

}
