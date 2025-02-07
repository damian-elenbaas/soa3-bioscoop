
using Bioscoop.Core.Models;

namespace Bioscoop.Tests.Models;

public class OrderTests
{
    [Fact(DisplayName = "CalculatePrice_WhenIsStudentOrder_AndNonPremium")]
    public void CalculatePrice_WhenIsStudentOrder_AndNonPremium()
    {
        // Arrange
        var order = new Order(1, true);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), false, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), false, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(6, result);
    }

    //FIXME: This logic is weird because it is based on order
    [Fact(DisplayName = "CalculatePrice_WhenIsStudentOrder_AndOnePremiumOneNonPremium")]
    public void CalculatePrice_WhenIsStudentOrder_AndOnePremiumOneNonPremium()
    {
        // Arrange
        var order = new Order(1, true);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), false, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(6, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenStudentOrder_ThreePremium")]
    public void CalculatePrice_WhenStudentOrder_ThreePremium()
    {
        // Arrange
        var order = new Order(1, true);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        var ticket3 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        order.AddSeatReservation(ticket3);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(16, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenStudentOrder_FourPremium")]
    public void CalculatePrice_WhenStudentOrder_FourPremium()
    {
        // Arrange
        var order = new Order(1, true);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        var ticket3 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        var ticket4 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), DateTime.Now.AddDays(3), 6), true, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        order.AddSeatReservation(ticket3);
        order.AddSeatReservation(ticket4);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(16, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenNonStudent_MondayOrder_TwoNonPremium")]
    public void CalculatePrice_WhenNonStudent_MondayOrder_TwoNonPremium()
    {
        // Arrange
        var today = DateTime.Now;
        var nextMonday = today.AddDays((int)DayOfWeek.Monday - (int)today.DayOfWeek);
        var order = new Order(1, false);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextMonday, 6), false, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextMonday, 6), false, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(6, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenNonStudent_ThursdayOrder_TwoNonePremium")]
    public void CalculatePrice_WhenNonStudent_ThursdayOrder_TwoNonePremium()
    {
        // Arrange
        var today = DateTime.Now;
        var nextThursday = today.AddDays((int)DayOfWeek.Thursday - (int)today.DayOfWeek);
        var order = new Order(1, false);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextThursday, 6), false, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextThursday, 6), false, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(6, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenNonStudent_FridayOrder_TwoNonPremium")]
    public void CalculatePrice_WhenNonStudent_FridayOrder_TwoNonPremium()
    {
        // Arrange
        var today = DateTime.Now;
        var nextFriday = today.AddDays((int)DayOfWeek.Friday - (int)today.DayOfWeek);
        var order = new Order(1, false);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), false, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), false, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(12, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenNonStudent_FridayOrder_TwoPremium")]
    public void CalculatePrice_WhenNonStudent_FridayOrder_TwoPremium()
    {
        // Arrange
        var today = DateTime.Now;
        var nextFriday = today.AddDays((int)DayOfWeek.Friday - (int)today.DayOfWeek);
        var order = new Order(1, false);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), true, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), true, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(18, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenNonStudent_FridayOrder_FivePremium")]
    public void CalculatePrice_WhenNonStudent_FridayOrder_FivePremium()
    {
        // Arrange
        var today = DateTime.Now;
        var nextFriday = today.AddDays((int)DayOfWeek.Friday - (int)today.DayOfWeek);
        var order = new Order(1, false);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), true, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), true, 1, 1);
        var ticket3 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), true, 1, 1);
        var ticket4 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), true, 1, 1);
        var ticket5 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextFriday, 6), true, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        order.AddSeatReservation(ticket3);
        order.AddSeatReservation(ticket4);
        order.AddSeatReservation(ticket5);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(45, result);
    }

    [Fact(DisplayName = "CalculatePrice_WhenNonStudent_SaturdayOrder_SixPremium")]
    public void CalculatePrice_WhenNonStudent_SaturdayOrder_SixNonPremium()
    {
        // Arrange
        var today = DateTime.Now;
        var nextSaturday = today.AddDays((int)DayOfWeek.Saturday - (int)today.DayOfWeek);
        var order = new Order(1, false);
        var ticket1 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextSaturday, 6), true, 1, 1);
        var ticket2 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextSaturday, 6), true, 1, 1);
        var ticket3 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextSaturday, 6), true, 1, 1);
        var ticket4 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextSaturday, 6), true, 1, 1);
        var ticket5 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextSaturday, 6), true, 1, 1);
        var ticket6 = new MovieTicket(new MovieScreening(new Movie("Bubu baba"), nextSaturday, 6), true, 1, 1);
        order.AddSeatReservation(ticket1);
        order.AddSeatReservation(ticket2);
        order.AddSeatReservation(ticket3);
        order.AddSeatReservation(ticket4);
        order.AddSeatReservation(ticket5);
        order.AddSeatReservation(ticket6);
        // Act
        var result = order.CalculatePrice();
        // Assert
        Assert.Equal(48.6, result);
    }

}
