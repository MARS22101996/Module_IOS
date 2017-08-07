using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foundation;
using UIKit;
using VTSClient.BLL.Dto;

namespace VTSClient.iOS
{
	
public class MenuTableViewSourse : UITableViewSource
	{
		private const string CellId = "cellMenu";
		private readonly UITableViewController _controller;
		private readonly IEnumerable<VacationDto> _vacationDtos;
		private readonly string[] _sections;

		public MenuTableViewSourse(UITableViewController controller, string[] sections, IEnumerable<VacationDto> vacationDtos)
		{
			_sections = sections;
			_controller = controller;
			_vacationDtos = vacationDtos;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellId, indexPath);
			cell.TextLabel.Text = _sections[indexPath.Row];

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _sections.Count();
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			bool isSelected = true; 
			var vacationViewController = (VacationViewController)_controller.Storyboard.InstantiateViewController(IOSStrings.VacationViewController.Name);

			switch (indexPath.Row)
			{
				case 0:
					vacationViewController.Vacations = _vacationDtos;
					break;
				case 1:
					vacationViewController.Vacations = _vacationDtos.Where(v => v.VacationStatus != 4);
					break;
				case 2:
					vacationViewController.Vacations = _vacationDtos.Where(v => v.VacationStatus == 4);
					break;
				default:
					isSelected = false;
				break;
			}

			if (isSelected) 
			{
				_controller.ShowDetailViewController(vacationViewController, _controller);
			}
		}
	}
}
