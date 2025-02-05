
namespace Bioscoop.Core.Models;

public class MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
{
    private Movie Movie { get; set; } = movie;
    private DateTime DateAndTime { get; set; } = dateAndTime;
    private double PricePerSeat { get; set; } = pricePerSeat;

    public Movie GetMovie => Movie;

    public DateTime GetDateAndTime => DateAndTime;

    public double GetPricePerSeat => PricePerSeat;

    public override string ToString()
    {
        return $"{Movie}, Date: {DateAndTime}";
    }
}
