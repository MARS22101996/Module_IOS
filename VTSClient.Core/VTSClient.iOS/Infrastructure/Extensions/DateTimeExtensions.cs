using System;
using Foundation;

namespace VTSClient.iOS.Infrastracture.Extensions
{
	public static class DateTimeExtensions
	{
		public static NSDate ConvertToNSDate(this DateTime date)
		{
			DateTime newDate = TimeZone.CurrentTimeZone.ToLocalTime(
				new DateTime(2001, 1, 1, 0, 0, 0));
			return NSDate.FromTimeIntervalSinceReferenceDate(
				(date - newDate).TotalSeconds);
		}
	}
}
