using MvvmCross.Core.ViewModels;
using MvvmSeed.Application.ViewModels.Interfaces;
using MvvmSeed.Domain.Services;

namespace MvvmSeed.Application.ViewModels
{
    public class SampleViewModel : MvxViewModel, ISampleViewModel
    {
        private readonly IStringRandomizerService _stringRandomizerService;

        public SampleViewModel(IStringRandomizerService stringRandomizerService)
        {
            _stringRandomizerService = stringRandomizerService;

            DoSomethingCommand = new MvxCommand(DoSomethingCommandExecute);
            SampleString = _stringRandomizerService.LastRandomizedValue;
        }

        public IMvxCommand DoSomethingCommand { get; }

        public string SampleString
        {
            get { return _sampleString; }
            set { _sampleString = value; RaisePropertyChanged(); }
        }
        private string _sampleString;

        private void DoSomethingCommandExecute()
        {
            SampleString = _stringRandomizerService.RandomizeString(SampleString);
        }
    }
}