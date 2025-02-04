
namespace Bioscoop.Core.Models;

public class Movie(string title)
{
    private string Title { get; set; } = title;

    public void AddScreening()
    {
        throw new NotImplementedException();
    }
}
