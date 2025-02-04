
namespace Bioscoop.Core.Models;

public class Movie(string title)
{
    private string Title { get; set; } = title;
    private IList<MovieScreening> MovieScreenings { get; set; } = [];

    public void AddScreening(MovieScreening movieScreening)
    {
        MovieScreenings.Add(movieScreening);
    }
}
