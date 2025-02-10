using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bioscoop.Core.Models;
public class ExportAsPlainText : IExportBehavior
{
    public void Export(Order order)
    {
        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
        var text = $"OrderNr: {order.GetOrderNr()}\nIsStudentOrder: {order.GetIsStudentOrder()}\nMovieTickets:\n";
        text += string.Join("\n- ", order.GetMovieTickets().Select((ticket, index) => index == 0 ? $"- {ticket}" : ticket.ToString()));
        File.WriteAllText(Path.Combine(projectDirectory ?? "", "order.txt"), text);
    }

}
