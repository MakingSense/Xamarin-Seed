using System;
using System.Threading;
using Moq;
using MvvmSeed.Application.ViewModels;
using MvvmSeed.Domain.Services;
using Xunit;

namespace MvvmSeed.UnitTests.ViewModels
{
    public class SampleViewModelTest
    {
        private readonly Mock<IStringRandomizerService> _stringRandomizerServiceMock = new Mock<IStringRandomizerService>();

        [Fact]
        public void DoSomethingCommand_ShouldTriggerPropertyChangedEvent_WhenDoSomethingCommandIsExecuted()
        {
            // Arrange
            var sampleViewModel = new SampleViewModel(_stringRandomizerServiceMock.Object);
            sampleViewModel.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);//UT lacks UI Dispatcher, we need to set this value to false if we want to receive notifications when there's no UI Dispatcher
            var eventWaiter = new AutoResetEvent(false);
            sampleViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SampleViewModel.SampleString))
                    eventWaiter.Set();
            };

            // Act
            sampleViewModel.DoSomethingCommand.Execute();

            // Assert
            var propertyChangedWasRaised = eventWaiter.WaitOne(timeout: TimeSpan.FromSeconds(1));
            Assert.True(propertyChangedWasRaised);
        }
    }
}
