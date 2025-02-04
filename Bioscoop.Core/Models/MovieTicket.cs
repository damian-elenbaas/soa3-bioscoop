
namespace Bioscoop.Core.Models;

public class MovieTicket
{
    private int RowNr { get; init; }
    private int SeatNr { get; init; }
    private bool IsPremium { get; init; }

    public bool IsPremiumTicket => IsPremium;

    public double GetPrice()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
