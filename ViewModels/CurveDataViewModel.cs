using System;
using System.Collections.Generic;
using WpfFrontEndProto.Models;

namespace WpfFrontEndProto.ViewModels
{
	public class CurveDataViewModel : ViewModelBase
	{
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
	}
}