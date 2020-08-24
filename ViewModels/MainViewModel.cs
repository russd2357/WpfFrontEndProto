using System.Threading.Tasks;
using System.Windows;

using WpfFrontEndProto;

namespace WpfFrontEndProto.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IViewUtils _viewUtils;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value ); }
        }

        public IAsyncCommand<object> ViewDataCommand { get; private set; }
        public IAsyncCommand<object> SeedDataCommand { get; private set; }

        public MainViewModel(IViewUtils viewUtils)
        {
            _viewUtils = viewUtils;
            ViewDataCommand = new AsyncCommand<object>(ExecuteViewDataAsync, CanExecute);
            SeedDataCommand = new AsyncCommand<object>(ExecuteSeedDataAsync, CanExecute);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		private async Task ExecuteViewDataAsync(object arg = null)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
		{
            IsBusy = true;
            //MessageBox.Show("Show View Data view");
            _viewUtils.ShowCurveDataModalView();
            IsBusy = false;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		private async Task ExecuteSeedDataAsync(object arg = null)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
		{
            IsBusy = true;
            MessageBox.Show("Show Seed Data view");
            IsBusy = false;
        }

        private bool CanExecute()
        {
            return !IsBusy;
        }
    }
}
