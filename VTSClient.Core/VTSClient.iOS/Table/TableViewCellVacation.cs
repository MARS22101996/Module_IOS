using System;

using Foundation;
using UIKit;
using VTSClient.BLL.Dto;

namespace VTSClient.iOS.Table
{
	public partial class TableViewCellVacation : UITableViewCell
	{
		public static readonly NSString Key = new NSString("TableViewCellVacation");
		public static readonly UINib Nib;

		static TableViewCellVacation()
		{
			Nib = UINib.FromName("TableViewCellVacation", NSBundle.MainBundle);
		}

		protected TableViewCellVacation(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateData(VacationDto vacationDto)
		{
			ImageViewVacationType.Image = UIImage.FromBundle("RequestBlue");
			LabelVacationDate.Text = $"{vacationDto.Start:MMM dd} - {vacationDto.End:MMM dd}";
			LabelVacationStatus.Text = vacationDto.VacationStatus.ToString();
			LabelVacationType.Text = vacationDto.VacationType.ToString();
		}
	}
}
