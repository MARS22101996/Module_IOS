using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.iOS.Cells;

namespace VTSClient.iOS.DataSources
{
	public class VacationsDataSource : UITableViewSource
	{
		private readonly List<VacationDto> _vacationList;
		private readonly UITableViewController _controller;
		private readonly NSString _cellIdentifier;

		public VacationsDataSource(IEnumerable<VacationDto> vacationList, UITableViewController callingController)
		{
			_vacationList = (List<VacationDto>) vacationList;
			_controller = callingController;
			_cellIdentifier = new NSString("VacationTableCell");
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (VacationTableCell) tableView.DequeueReusableCell(_cellIdentifier);

			cell.UpdateData(_vacationList[indexPath.Row]);
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _vacationList.Count;
		}

		//public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		//{
		//	var board = UIStoryboard.FromName("Main", null);
		//	var ctrl = board.InstantiateViewController("DetailsViewController") as DetailsViewController;
		//	ctrl.Vacation = _vacationList[indexPath.Row];
		//	_controller.NavigationController.PushViewController(ctrl, false);
		//}
	}
}
