
using Bioscoop.Core.Models;

using NSubstitute;

namespace Bioscoop.Tests.Models;

public class SubmittedOrderStateTests
{

    [Fact]
    public void SubmitOrder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new SubmittedOrderState(order);
        order.SetState(sut);

        // Act
        sut.SubmitOrder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

    [Fact]
    public void UpdateOrder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new SubmittedOrderState(order);
        order.SetState(sut);

        // Act
        sut.UpdateOrder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

    [Fact]
    public void SendReminder_Should_ChangeState_To_ProvisionalOrderState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new SubmittedOrderState(order);
        order.SetState(sut);

        // Act
        sut.SendReminder();

        // Assert
        order.Received().SetState(Substitute.For<ProvisionalOrderState>(order));
    }

    [Fact]
    public void PayOrder_Should_ChangeState_To_PaidOrderState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new SubmittedOrderState(order);
        order.SetState(sut);

        // Act
        sut.PayOrder();

        // Assert
        order.Received().SetState(Substitute.For<PaidOrderState>(order));
    }

    [Fact]
    public void SendOrder_ShouldNot_ChangeState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new SubmittedOrderState(order);
        order.SetState(sut);

        // Act
        sut.SendOrder();

        // Assert
        order.DidNotReceive().SetState(Substitute.For<IOrderState>());
    }

    [Fact]
    public void CancelOrder_Should_ChangeState_To_CancelOrderState()
    {
        // Arrange
        var order = Substitute.For<Order>(0, false);
        var sut = new SubmittedOrderState(order);
        order.SetState(sut);

        // Act
        sut.CancelOrder();

        // Assert
        order.Received().SetState(Substitute.For<CanceledOrderState>(order));
    }

}
