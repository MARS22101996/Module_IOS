using UIKit;
using VTSClient.DAL.Enums;

namespace VTSClient.iOS.Infrastructure
{
	public static class VacationTypeSetting
	{

		public static UIImage GetPicture(VacationType type)
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
