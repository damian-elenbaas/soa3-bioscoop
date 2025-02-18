
namespace Bioscoop.Core.Models;

public class UnsubmittedState(Order order) : IOrderState
{

    private readonly Order parentOrder = order;

    public void SubmitOrder()
    {
        order.SetState(new SubmittedOrderState(order));
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

    }

    public void CancelOrder()
    {

    }

}
