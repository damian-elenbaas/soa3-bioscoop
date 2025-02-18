
using Bioscoop.Core.Models;

using NSubstitute;

namespace Bioscoop.Tests.Models;

public class UnsubmittedStateTests
{

    [Fact]
    public void SubmitOrder_Should_ChangeState_To_SubmittedOrderState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new UnsubmittedState(order);
        order.SetState(sut);

        // Act
        sut.SubmitOrder();

        // Assert
        order.Received().SetState(Substitute.For<SubmittedOrderState>(order));
    }

    [Fact]
    public void UpdateOrder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new UnsubmittedState(order);
        order.SetState(sut);

        // Act
        sut.UpdateOrder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

    [Fact]
    public void SendReminder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new UnsubmittedState(order);
        order.SetState(sut);

        // Act
        sut.SendReminder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

    [Fact]
    public void PayOrder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new UnsubmittedState(order);
        order.SetState(sut);

        // Act
        sut.PayOrder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

    [Fact]
    public void SendOrder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new UnsubmittedState(order);
        order.SetState(sut);

        // Act
        sut.SendOrder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

    [Fact]
    public void CancelOrder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new UnsubmittedState(order);
        order.SetState(sut);

        // Act
        sut.CancelOrder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

}
