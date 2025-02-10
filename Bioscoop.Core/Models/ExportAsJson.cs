using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bioscoop.Core.Models;
public class ExportAsJson : IExportBehavior
{
    public void Export(Order order)
    {
        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        var json = new
        {
            OrderNr = order.GetOrderNr(),
            StudentOrder = order.GetIsStudentOrder(),
            MovieTickets = order.GetMovieTickets().Select(ticket => new
            {
                MovieScreening = new
                {
                    Movie = new
                    {
                        Title = ticket.GetMovieScreening.GetMovie.GetTitle
                    },
                    DateAndTime = ticket.GetMovieScreening.GetDateAndTime(),
                    PricePerSeat = ticket.GetMovieScreening.GetPricePerSeat()
                },
                RowNr = ticket.GetRowNr,
                SeatNr = ticket.GetSeatNr,
                ticket.IsPremiumTicket
            })
        };
        var jsonString = JsonSerializer.Serialize(json);
        File.WriteAllText(Path.Combine(projectDirectory ?? "", "order.json"), jsonString);
    }

}
