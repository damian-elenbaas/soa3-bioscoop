
namespace Bioscoop.Core.Models;

public class Order(int orderNr, bool isStudentOrder)
{
    private int OrderNr { get; } = orderNr;
    private bool IsStudentOrder { get; } = isStudentOrder;

    public void Export(TicketExportFormat exportFormat)
    {
        throw new NotImplementedException();
    }
}
