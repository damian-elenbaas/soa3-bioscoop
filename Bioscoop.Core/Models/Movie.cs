
namespace Bioscoop.Core.Models;

public class Movie(string title)
{
    private string Title { get; set; } = title;
    private IList<MovieScreening> MovieScreenings { get; set; } = [];

    public string GetTitle => Title;

    public void AddScreening(MovieScreening movieScreening)
    {
        MovieScreenings.Add(movieScreening);
    }

    public override String ToString()
    {
        return Title;
    }
}
