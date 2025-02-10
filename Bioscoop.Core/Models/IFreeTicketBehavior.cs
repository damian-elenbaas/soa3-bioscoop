
namespace Bioscoop.Core.Models;

public interface IFreeTicketBehavior
{
    bool IsFree(int ticketNr, MovieTicket ticket);
}
