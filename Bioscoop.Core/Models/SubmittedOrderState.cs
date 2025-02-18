
namespace Bioscoop.Core.Models;

public class SubmittedOrderState(Order order) : IOrderState
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
        order.SetState(new ProvisionalOrderState(order));
    }

    public void PayOrder()
    {
        order.SetState(new PaidOrderState(order));
    }

    public void SendOrder()
    {

    }

    public void CancelOrder()
    {
        order.SetState(new CanceledOrderState(order));
    }

}
