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

        public IAsyncCommand ViewDataCommand { get; private set; }
        public IAsyncCommand SeedDataCommand { get; private set; }

        public MainViewModel()
        {
            ViewDataCommand = new AsyncCommand(ExecuteViewDataAsync, CanExecute);
            SeedDataCommand = new AsyncCommand(ExecuteSeedDataAsync, CanExecute);
        }

        private async Task ExecuteViewDataAsync()
        {
            IsBusy = true;
            //MessageBox.Show("Show View Data view");
            ViewUtils.ShowCurveDataModalView();
            IsBusy = false;
        }

        private async Task ExecuteSeedDataAsync()
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
