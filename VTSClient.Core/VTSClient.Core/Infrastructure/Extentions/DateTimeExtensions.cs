using System;
using System.Globalization;

namespace VTSClient.Core.Infrastructure.Extentions
{
    public static class DateTimeExtensions
	{
		public static string ToShortDate(this DateTime dateTime)
		{
			return string.Format($"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month)} {dateTime.Day}");
		}

		public static string ToShortMonth(this DateTime dateTime)
		{
			return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
		}
	}

}
