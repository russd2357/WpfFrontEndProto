﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfFrontEndProto.Models;
using WpfFrontEndProto.Services.Interfaces;

namespace WpfFrontEndProto.Services
{
	public class LocalCurveDataService : ICurveDataService
	{
		public async Task<List<SensorReading>> GetCurveDataAsync(string id, DateTime start, DateTime end)
		{
			try
			{
				return await GetCurveAsync(id, start, end);
			}
			catch (Exception)
			{
				return null;
			}
		}

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		public async Task SeedCurveDataAsync(string id, List<SensorReading> data)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
		{
			return;
		}


		private async Task<List<SensorReading>> GetCurveAsync(string id, DateTime start, DateTime end)
		{
			var result = new List<SensorReading>();

			await Task<List<SensorReading>>.Run(() =>
			{
				var min = 2.5D;
				var max = 5.5D;
				var rand = new Random();
				var sign = 1;
				var time = start.AddSeconds(25);
				while (time < end)
				{
					result.Add(new SensorReading { Timestamp = time, Value = (double)Math.Round( min + (max - min)*rand.NextDouble(), 2) });
					sign = DateTime.Now.Millisecond % 2 == 0 ? 1 : -1;
					time = time.AddMinutes((int)(5 + sign * rand.NextDouble()));
				}

			});

			return result;
		}

	}
}
