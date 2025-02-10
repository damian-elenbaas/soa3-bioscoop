
namespace Bioscoop.Core.Models;

public class FreeTicketStudentBehavior : IFreeTicketBehavior
{
    public bool IsFree(int ticketNr, MovieTicket ticket)
    {
        return ticketNr % 2 == 0;
    }
}
