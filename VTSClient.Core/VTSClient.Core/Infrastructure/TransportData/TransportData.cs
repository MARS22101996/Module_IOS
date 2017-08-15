using System;

namespace VTSClient.Core.Infrastructure.TransportData
{
	public class TransportData
	{
		private static Guid _id;
		public static Guid GetId()
		{
			
			return _id;
		}

		public static void SetId(Guid id)
		{
			_id = id;
		}
	}
}
