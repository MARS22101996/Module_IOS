using System;
using Foundation;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS.Cells
{
	public partial class VacationTableCell : UITableViewCell
	{
		public static readonly NSString _key = new NSString("VacationTableCell");
		public static readonly UINib _nib;

		static VacationTableCell()
		{
			_nib = UINib.FromName("VacationTableCell", NSBundle.MainBundle);
		}

		protected VacationTableCell(IntPtr handle) : base(handle)
		{
		}

		public void UpdateData(VacationDto vacation)
		{
			ImageType.Image = VacationTypeSetting.GetPicture(vacation.VacationType);
			TextDate.Text = $"{vacation.Start.ToShortDateString()} - {vacation.End.ToShortDateString()}";
			TextType.Text = vacation.VacationType.ToString();
			TextStatus.Text = vacation.VacationStatus.ToString();
		}
	}
}
