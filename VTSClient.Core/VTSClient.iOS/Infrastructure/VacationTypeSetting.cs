using UIKit;

namespace VTSClient.iOS.Infrastructure
{
	public static class VacationTypeSetting
	{

		public static UIImage GetPicture(string type)
		{
			switch (type)
			{
				case "Regular":
					return UIImage.FromBundle("Icon_Request_Green");

				case "Exceptional":
					return UIImage.FromBundle("Icon_Request_Gray");

				case "Sick":
					return UIImage.FromBundle("Icon_Request_Plum");

				case "Overtime":
					return UIImage.FromBundle("Icon_Request_Blue");

				default:
					return UIImage.FromBundle("Icon_Request_Dark");
			}
		}
	}
}
