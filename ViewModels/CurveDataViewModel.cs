using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfFrontEndProto.Models;
using WpfFrontEndProto;

namespace WpfFrontEndProto.ViewModels
{
	public class CurveDataViewModel : ViewModelBase
	{
		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy;  }
			set { SetProperty(ref _isBusy, value); }
		}

		private DateTime _startTime;
		public DateTime StartTime
		{
			get { return _startTime; }
			set { SetProperty(ref _startTime, value); }
		}

		private DateTime _endTime;
		public DateTime EndTime
		{
			get { return _endTime; }
			set { SetProperty(ref _endTime, value); }
		}

		private IList<SensorReading> _qresults;
		public IList<SensorReading> QueryResults
		{
			get { return _qresults; }
			set { SetProperty(ref _qresults, value);  }
		}

		private string _deviceId;
		public string DeviceId
		{
			get { return _deviceId;  }
			set { SetProperty(ref _deviceId, value); }
		}

		private IList<string> _devices;
		public IList<string> Devices
		{
			get { return _devices;  }
			set { SetProperty(ref _devices, value);  }
		}

		public IAsyncCommand<object> QueryCommand { get; private set; }
		public IAsyncCommand<Window> CloseCommand { get; private set; }


		public CurveDataViewModel()
		{
			QueryCommand = new AsyncCommand<object>(ExecuteQueryDataCommand, CanExecute);
			CloseCommand = new AsyncCommand<Window>(ExecuteCloseCommand, CanExecute);
		}

		private async Task ExecuteQueryDataCommand(object arg = null)
		{
			IsBusy = true;
			IsBusy = false;
		}

		private async Task ExecuteCloseCommand(Window view)
		{
			IsBusy = true;
			view.Close();
			IsBusy = false;
		}

		private bool CanExecute()
		{
			return !IsBusy;
		}
	}
}