
namespace Bioscoop.Core.Models;

public class CompletedOrderState(Order order) : IOrderState
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

    }

    public void CancelOrder()
    {

    }

}
