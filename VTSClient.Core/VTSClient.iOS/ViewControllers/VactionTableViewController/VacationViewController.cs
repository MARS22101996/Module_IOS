using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.iOS.Table;

namespace VTSClient.iOS
{
	public partial class VacationViewController : UITableViewController
	{
		public IEnumerable<VacationDto> Vacations { get; set; }

		private readonly UIBarButtonItem _buttonMenu;
		private readonly UIBarButtonItem _buttonAdd;

		public VacationViewController(IntPtr intPtr) : base(intPtr) 
		{
			_buttonMenu = new UIBarButtonItem(UIBarButtonSystemItem.Action);
			_buttonAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			NavigationItem.LeftBarButtonItem = _buttonMenu;
			NavigationItem.RightBarButtonItem = _buttonAdd;

			Title = IOSStrings.VacationViewController.Title;
			BindEvents();
		}

		public override void ViewDidUnload()
		{
			base.ViewDidUnload();
			UnbindEvents();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return Vacations.Count();
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (TableViewCellVacation)TableView.DequeueReusableCell(IOSStrings.VacationViewController.CellName);
			cell.UpdateData(Vacations.ToList()[indexPath.Row]);

			return cell;
		}

		//public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		//{
		//	VacationDto selectedVacation = Vacations.ToList()[indexPath.Row];

		//	var addOrUpdateVacationController = (AddOrUpdateViewController)Storyboard.InstantiateViewController(IOSStrings.AddOrUpdateController.Name);
		//	addOrUpdateVacationController.VacationDto = selectedVacation;

		//	NavigationController.PushViewController(addOrUpdateVacationController, true);
		//}

		private void OnButtonMenuClick(object sender, EventArgs e)
		{
			NavigationController.PopToRootViewController(true);
		}

		//private void OnButtonAddClick(object sender, EventArgs e)
		//{
		//	var addOrUpdateVacationController = (AddOrUpdateViewController)Storyboard.InstantiateViewController(IOSStrings.AddOrUpdateController.Name);
		//	addOrUpdateVacationController.VacationDto = null;
		//	NavigationController.PushViewController(addOrUpdateVacationController, true);
		//}

		private void BindEvents() 
		{
			_buttonMenu.Clicked += OnButtonMenuClick;
			//_buttonAdd.Clicked += OnButtonAddClick;
		}

		private void UnbindEvents()
		{
			_buttonMenu.Clicked -= OnButtonMenuClick;
			//_buttonAdd.Clicked -= OnButtonAddClick;
		}
	}
}

