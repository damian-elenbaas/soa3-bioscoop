
namespace Bioscoop.Core.Models;

public class FreeTicketNonStudentBehavior : IFreeTicketBehavior
{
    public bool IsFree(int ticketNr, MovieTicket ticket)
    {
        var dateAndTime = ticket.GetDateAndTime();

        // ma/di/wo/do
        var isWeekDay = dateAndTime.DayOfWeek >= DayOfWeek.Monday && dateAndTime.DayOfWeek <= DayOfWeek.Thursday;

        return ticketNr % 2 == 0 && isWeekDay;
    }
}
