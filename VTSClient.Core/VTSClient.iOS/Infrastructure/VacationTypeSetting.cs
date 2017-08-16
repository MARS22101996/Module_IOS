using UIKit;
using VTSClient.DAL.Enums;

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

		public static UIImage GetPictureFromPage(VacationType type)
		{
			switch (type)
			{
				case VacationType.Regular:
					return UIImage.FromBundle("Icon_Request_Green");

				case VacationType.Exceptional:
					return UIImage.FromBundle("Icon_Request_Gray");

				case VacationType.Sick:
					return UIImage.FromBundle("Icon_Request_Plum");

				case VacationType.Overtime:
					return UIImage.FromBundle("Icon_Request_Blue");

				default:
					return UIImage.FromBundle("Icon_Request_Dark");
			}
		}
	}
}
