using MvvmCross.Core.ViewModels;

namespace MvvmSeed.Application.ViewModels.Interfaces
{
    public interface ISampleViewModel
    {
        IMvxCommand DoSomethingCommand { get; }
        string SampleString { get; set; }
    }
}