using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using WpfFrontEndProto.Models;
using WpfFrontEndProto.Services.Interfaces;
using Newtonsoft.Json;

namespace WpfFrontEndProto.Services
{
	public class FileCurveDataService : ICurveDataService
	{
		public async Task<List<SensorReading>> GetCurveDataAsync(string id, DateTime start, DateTime end)
		{
			try
			{
				var result = new List<SensorReading>();


				return await GetDataAsync(id, start, end);
			}
			catch
			{
				return null;
			}
		}

		public Task SeedCurveDataAsync(string id, List<SensorReading> data)
		{
			throw new NotImplementedException();
		}

		private async Task<List<SensorReading>>GetDataAsync(string id, DateTime start, DateTime end)
		{
			var basepath = ConfigurationManager.AppSettings["DataServiceBasePath"];
			if (basepath == null)
			{
				throw new Exception("Invalid configuration setting - basepath not found");
			}

			basepath = Path.Combine(basepath, @"Devices");

			return await Task<List<SensorReading>>.Run( async () =>
			  {
				  var time = start;
				  var result = new List<SensorReading>();
				  var done = false;
				  while (!done)
				  {
					  var filename = Path.Combine(Path.Combine(Path.Combine(basepath, id), $"{time.Year}"), $"{time.Month:00}_data.json");
					  var fi = new FileInfo(filename);
					  if (!fi.Exists)
						  continue;

					  var jsondata = await fi.OpenText().ReadToEndAsync();
					  var data = JsonConvert.DeserializeObject<List<SensorReading>>(jsondata);
					  result.AddRange(data);

					  time = time.AddMonths(1);
					  done = time >= end;
				  }

				  result = result.Where(o => o.Timestamp >= start && o.Timestamp <= end)
					.OrderBy(o => o.Timestamp)
					.ToList();

				  return result;
			  });
		}
	}
}
