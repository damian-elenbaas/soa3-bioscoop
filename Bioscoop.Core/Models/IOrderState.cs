
namespace Bioscoop.Core.Models;

public interface IOrderState
{

    public void SubmitOrder();

    public void UpdateOrder();

    public void SendReminder();

    public void PayOrder();

    public void SendOrder();

    public void CancelOrder();

}
