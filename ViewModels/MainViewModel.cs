using System.Threading.Tasks;
using System.Windows;

using WpfFrontEndProto;

namespace WpfFrontEndProto.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value ); }
        }

        public IAsyncCommand<object> ViewDataCommand { get; private set; }
        public IAsyncCommand<object> SeedDataCommand { get; private set; }

        public MainViewModel()
        {
            ViewDataCommand = new AsyncCommand<object>(ExecuteViewDataAsync, CanExecute);
            SeedDataCommand = new AsyncCommand<object>(ExecuteSeedDataAsync, CanExecute);
        }

        private async Task ExecuteViewDataAsync(object arg = null)
        {
            IsBusy = true;
            //MessageBox.Show("Show View Data view");
            ViewUtils.ShowCurveDataModalView();
            IsBusy = false;
        }

        private async Task ExecuteSeedDataAsync(object arg = null)
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
