
using System;
using Autofac;
using UIKit;
using VTSClient.BLL.Interfaces;
using VTSClient.DAL.Enums;
using VTSClient.iOS.DataSources;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS
{
	public partial class VacationsTableViewController : UITableViewController
	{
		private IApiVacationService _vacationService;
		public FilterEnum Filter { get; set; }

		public VacationsTableViewController (IntPtr handle) : base (handle)
		{
			_vacationService = IOSSetup.Container.Resolve<IApiVacationService>();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddButtonEvent);
			SetVacations();
		}

		private async void SetVacations()
		{
			var vacations = await _vacationService.FilterVacations(Filter);
			var vacationsDataSource = new VacationsDataSource(vacations, this);
			TableView.ContentInset = new UIEdgeInsets(20, 0, 0, 0);
			TableView.Source = vacationsDataSource;
		}

		//private void AddButtonEvent(object sender, EventArgs e)
		//{
		//	var board = UIStoryboard.FromName("Main", null);
		//	var ctrl = board.InstantiateViewController("DetailsViewController") as DetailsViewController;
		//	NavigationController.PushViewController(ctrl, false);
		//}
	}
}
