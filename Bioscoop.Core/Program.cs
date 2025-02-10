using Bioscoop.Core.Models;

Console.WriteLine("Starting Bioscoop App!");
var movie = new Movie("Bubu baba");
var screening = new MovieScreening(movie, DateTime.Now.AddDays(-1), 10.0);
Console.WriteLine(DateTime.Now.AddDays(-1).DayOfWeek);
var ticket = new MovieTicket(screening, false, 1, 1);
var ticket2 = new MovieTicket(screening, false, 1, 1);
var order = new Order(1, false);
order.AddSeatReservation(ticket);
order.AddSeatReservation(ticket2);
order.Export(TicketExportFormat.JSON);
