using System;
using System.Windows;
using WpfFrontEndProto.ViewModels;

namespace WpfFrontEndProto.Views
{
    public partial class CurveDataView : Window
    {
        private CurveDataViewModel _viewModel;
        public CurveDataView(CurveDataViewModel vm)
        {
            _viewModel = vm;
            InitializeComponent();
            this.DataContext = _viewModel;
        }

	}
}