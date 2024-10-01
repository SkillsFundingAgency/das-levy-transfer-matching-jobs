﻿using System.Threading.Tasks;
using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using NServiceBus;
using NUnit.Framework;
using SFA.DAS.LevyTransferMatching.Functions.Api;
using SFA.DAS.LevyTransferMatching.Functions.Events;
using SFA.DAS.LevyTransferMatching.Messages.Events;

namespace SFA.DAS.LevyTransferMatching.Functions.UnitTests.EventHandlers;

[TestFixture]
public class ApplicationFundingDeclinedEventHandlerTests
{
    private ApplicationFundingDeclinedEventHandler _handler;
    private ApplicationFundingDeclinedEvent _event;
    private Mock<ILevyTransferMatchingApi> _api;
    private readonly Fixture _fixture = new();

    [SetUp]
    public void Setup()
    {
        _api = new Mock<ILevyTransferMatchingApi>();
        _event = _fixture.Create<ApplicationFundingDeclinedEvent>();
        _handler = new ApplicationFundingDeclinedEventHandler(_api.Object, Mock.Of<ILogger<ApplicationFundingDeclinedEventHandler>>());
    }

    [Test]
    public async Task Run_Invokes_ApplicationFundingDeclined_Api_Endpoint()
    {
        await _handler.Handle(_event, Mock.Of<IMessageHandlerContext>());

        _api.Verify(x => x.ApplicationFundingDeclined(It.Is<ApplicationFundingDeclinedRequest>(r =>
            r.ApplicationId == _event.ApplicationId &&
            r.PledgeId == _event.PledgeId &&
            r.Amount == _event.Amount)));
    }
}