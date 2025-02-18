
namespace Bioscoop.Core.Models;

public class NotifyPublisher
{

    private readonly IList<INotifyService> Subscribers = [];

    public void Subscribe(INotifyService subscriber)
    {
        Subscribers.Add(subscriber);
    }

    public void Unsubscribe(INotifyService subscriber)
    {
        Subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string message, string receiver)
    {
        foreach (var sub in Subscribers)
        {
            sub.Notify(message, receiver);
        }
    }

}
