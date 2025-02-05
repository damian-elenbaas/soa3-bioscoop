
namespace Bioscoop.Core.Models;

public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
{
    private MovieScreening MovieScreening { get; init; } = movieScreening;
    private int RowNr { get; init; } = seatRow;
    private int SeatNr { get; init; } = seatNr;
    private bool IsPremium { get; init; } = isPremiumReservation;

    public bool IsPremiumTicket => IsPremium;
    public MovieScreening GetMovieScreening => MovieScreening;
    public int GetRowNr => RowNr;
    public int GetSeatNr => SeatNr;

    public double GetPrice() => MovieScreening.GetPricePerSeat();

    public DateTime GetDateAndTime() => MovieScreening.GetDateAndTime();

    public override string ToString()
    {
        return $"Movie: {MovieScreening}, Seat: {RowNr}-{SeatNr}";
    }
}
