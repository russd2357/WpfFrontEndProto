using System.Windows;
using WpfFrontEndProto.ViewModels;

namespace WpfFrontEndProto.Views
{
    public partial class CurveDataView : Window
    {
        private CurveDataViewModel _viewModel = new CurveDataViewModel();
        public CurveDataView()
        {
           this.DataContext = _viewModel;
           InitializeComponent();
        }
    }
}