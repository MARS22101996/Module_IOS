using System;
using Foundation;
using UIKit;
using VTSClient.DAL.Enums;

namespace VTSClient.iOS.DataSources
{
	public class MenuTableViewSource : UITableViewSource
	{
		private UITableViewController controller;
		private string[] data;

		private const string cell_id= "cellid";

		public MenuTableViewSource(UITableViewController controller, string[] data)
		{
			this.data = data;
			this.controller = controller;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(cell_id, indexPath);

			cell.TextLabel.Text = data[indexPath.Row];

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return data.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var vacations = controller.Storyboard.InstantiateViewController("VacationsTableViewController") as VacationsTableViewController;

			switch (indexPath.Row)
			{
				case 0:
					vacations.Filter = FilterEnum.All;
					break;
				case 1:
					vacations.Filter = FilterEnum.Opened;
					break;
				case 2:
					vacations.Filter = FilterEnum.Closed;
					break;
			}

			controller.ShowDetailViewController(vacations, controller);
		}
	}
}
