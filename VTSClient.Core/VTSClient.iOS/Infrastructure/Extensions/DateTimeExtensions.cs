using System;
using Foundation;

namespace VTSClient.iOS.Infrastructure.Extensions
{
	public static class DateTimeExtensions
	{
		public static NSDate ConvertToNsDate(this DateTime date)
		{
			DateTime newDate = TimeZone.CurrentTimeZone.ToLocalTime(
				new DateTime(2001, 1, 1, 0, 0, 0));
			return NSDate.FromTimeIntervalSinceReferenceDate(
				(date - newDate).TotalSeconds);
		}
	}
}