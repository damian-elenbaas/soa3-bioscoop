using Bioscoop.Core.Models;

Console.WriteLine("Starting Bioscoop App!");
var movie = new Movie("Bubu baba");
var screening = new MovieScreening(movie, DateTime.Now.AddDays(3), 10.0);
var ticket = new MovieTicket(screening, false, 1, 1);
var order = new Order(1, false);
order.AddSeatReservation(ticket);
order.Export(TicketExportFormat.JSON);
