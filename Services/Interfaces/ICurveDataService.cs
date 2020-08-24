using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfFrontEndProto.Models;

namespace WpfFrontEndProto.Services.Interfaces
{
	public interface ICurveDataService
	{
		public Task<List<SensorReading>> GetCurveDataAsync(string id, DateTime start, DateTime end);

		public Task SeedCurveDataAsync(string id, List<SensorReading> data);
	}
}
