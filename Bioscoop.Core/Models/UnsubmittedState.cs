
namespace Bioscoop.Core.Models;

public class UnsubmittedState(Order order) : IOrderState 
{

    private readonly Order parentOrder = order;

    public void CreateOrder(int ticketCount, MovieScreening movieScreening, bool parkingCard) 
    {
        return;
    }

    public void SubmitOrder()
    {
        order.SetState(new SubmittedOrderState());
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
