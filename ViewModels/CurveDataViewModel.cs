using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfFrontEndProto.Models;
using WpfFrontEndProto;
using WpfFrontEndProto.Services.Interfaces;

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

		//private bool _setValueOnLostFocus = false;
		//public bool SetValueOnLostFocus
		//{
		//	get { return _setValueOnLostFocus;  }
		//	set { SetProperty(ref _setValueOnLostFocus, value);  }
		//}

		private DateTime _startTime;
		public DateTime StartTime
		{
			get { return _startTime; }
			set { SetProperty(ref _startTime, value); }
		}

		private DateTime _startClockTime;
		public DateTime StartClockTime
		{
			get { return _startClockTime; }
			set { SetProperty(ref _startClockTime, value); }
		}

		private DateTime _endTime;
		public DateTime EndTime
		{
			get { return _endTime; }
			set { SetProperty(ref _endTime, value); }
		}

		private DateTime _endClockTime;
		public DateTime EndClockTime
		{
			get { return _endClockTime; }
			set { SetProperty(ref _endClockTime, value); }
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

		private readonly ICurveDataService _dataService;

		public IAsyncCommand<object> QueryCommand { get; private set; }
		public IAsyncCommand<Window> CloseCommand { get; private set; }


		public CurveDataViewModel(ICurveDataService dataService)
		{
			_dataService = dataService;
			QueryCommand = new AsyncCommand<object>(ExecuteQueryDataCommand, CanExecute);
			CloseCommand = new AsyncCommand<Window>(ExecuteCloseCommand, CanExecute);
			StartTime = DateTime.UtcNow;
			EndTime = DateTime.UtcNow;
			
		}

		private async Task ExecuteQueryDataCommand(object arg = null)
		{
			IsBusy = true;
			if (string.IsNullOrEmpty(DeviceId))
			{
				MessageBox.Show("DeviceId cannot be empty");
				
			}
			else
			{
				StartTime = StartTime.Date + StartClockTime.TimeOfDay;
				EndTime = EndTime.Date + EndClockTime.TimeOfDay;
				var raw = await _dataService.GetCurveDataAsync(DeviceId, StartTime, EndTime);
				var ret = new List<SensorReading>();

				// we're going to filter the curve to a max of 1000 points
				var factor = (int)(raw.Count / 400);
				for (int i = 0; i <= raw.Count; i++)
				{
					if (i == 0 || i % factor == 0)
					{
						ret.Add(raw[i]);
					}
					continue;
				}
				
				// make sure the last point is in the curve.
				if (ret.IndexOf(raw[^1]) == -1)
				{
					ret.Add(raw[^1]);
				}
				
				QueryResults = ret;
			}
			IsBusy = false;
		}

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		private async Task ExecuteCloseCommand(Window view)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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