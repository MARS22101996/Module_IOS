using System;
using System.Collections.Generic;
using Autofac;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS
{
	public partial class MenuTableViewController : UITableViewController
	{
		private string[] _menuSections;
		private IEnumerable<VacationDto> _vacationDtos;
		private IApiVacationService _vacationService;

		public MenuTableViewController(IntPtr intPtr) : base(intPtr)
		{
			_menuSections = new string[] 
			{
				IOSStrings.MenuTableViewController.CellAll,
				IOSStrings.MenuTableViewController.CellOpened,
				IOSStrings.MenuTableViewController.CellClosed
			};
			_vacationService = IOSSetup.Container.Resolve<IApiVacationService>();
		}

		public override async void ViewDidLoad()
		{
			var vacationTask =_vacationService.GetVacationAsync();

			base.ViewDidLoad();

			_vacationDtos = await vacationTask;

			ImageAvatar.Image = UIImage.FromBundle("Avatar");

			LabelFullName.Text = $"{IOSStrings.UserStrings.Name} {IOSStrings.UserStrings.LastName}";

			var vacationViewController = (VacationViewController)Storyboard.InstantiateViewController(IOSStrings.VacationViewController.Name);
		
			ShowDetailViewController(vacationViewController, this);

			TableView.Source = new MenuTableViewSourse(this, _menuSections, _vacationDtos);
		}
	}
}

