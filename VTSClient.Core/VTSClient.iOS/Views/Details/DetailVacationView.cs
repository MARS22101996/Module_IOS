using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.ViewModels;
using VTSClient.DAL.Enums;
using VTSClient.DAL.Repositories;
using VTSClient.iOS.Infrastructure;
using VTSClient.iOS.Infrastructure.Extensions;
using VTSClient.Core.Infrastructure.Extentions;

namespace VTSClient.iOS.Views.Details
{
	public partial class DetailVacationView : MvxViewController<DetailViewModel>
	{
		public VacationDto Vacation { get; set; }

		private readonly IApiVacationService _vacationService;

		private bool IsStartDate;

		public DetailVacationView() : base("DetailVacationView", null)
		{
			AutoMapperCoreConfiguration.Configure();

			var repo = new CommonApiRepository();

			_vacationService = new ApiVacationService(repo);

			SetVacation();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//NavigationItem.BackBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Action);

			//NavigationItem.Title = "Request";

			//NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Save);

			//SetData();

			//SetNavigationBar();
			//ApplyBindings();


			SetNavigationBar();

			SetData();

            HideDatePicker();

			BindEvents();
		}

		private void SetData()
		{
			var i = StartDay;
			StartDay.SetTitle(Vacation.Start.Day.ToString(), UIControlState.Normal);
			StartMonth.SetTitle(Vacation.Start.ToShortMonth(), UIControlState.Normal);
			StartYear.SetTitle(Vacation.Start.Year.ToString(), UIControlState.Normal);

			EndDay.SetTitle(Vacation.End.Day.ToString(), UIControlState.Normal);
			EndMonth.SetTitle(Vacation.End.ToShortMonth(), UIControlState.Normal);
			EndYear.SetTitle(Vacation.End.Year.ToString(), UIControlState.Normal);

			StatusSegment.SelectedSegment = (Vacation.VacationStatus == VacationStatus.Approved) ? 0 : 1;

			Page.CurrentPage = (int)Vacation.VacationType;
			PageImage.Image = VacationTypeSetting.GetPicture(Vacation.VacationType);
			TypeText.Text = Enum.GetName(typeof(VacationType), 0);
		}

		private void SetNavigationBar()
		{
			NavigationItem.BackBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Action);
			NavigationItem.Title = "Request";
			NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Save, SaveButtonEvent);
		}

		private void BindEvents()
		{
			StatusSegment.ValueChanged += ChangeStatus;
			Page.ValueChanged += SwipeEvent;

			StartDay.TouchUpInside += StartDateEvent;
			StartMonth.TouchUpInside += StartDateEvent;
			StartYear.TouchUpInside += StartDateEvent;

			EndDay.TouchUpInside += EndDateEvent;
			EndMonth.TouchUpInside += EndDateEvent;
			EndYear.TouchUpInside += EndDateEvent;
		}

		private void UnbindEvents()
		{
			StatusSegment.ValueChanged -= ChangeStatus;
			Page.ValueChanged -= SwipeEvent;

			StartDay.TouchUpInside -= StartDateEvent;
			StartMonth.TouchUpInside -= StartDateEvent;
			StartYear.TouchUpInside -= StartDateEvent;

			EndDay.TouchUpInside -= EndDateEvent;
			EndMonth.TouchUpInside -= EndDateEvent;
			EndYear.TouchUpInside -= EndDateEvent;
		}

		private void ChangeStatus(object s, EventArgs e)
		{
			Vacation.VacationStatus = (StatusSegment.SelectedSegment == 1) ? VacationStatus.Closed : VacationStatus.Approved;
		}

		private void ChangeType()
		{
			var page = (int)Page.CurrentPage;
			Vacation.VacationType = (VacationType)page;
			PageImage.Image = VacationTypeSetting.GetPicture(Vacation.VacationType);
			TypeText.Text = Enum.GetName(typeof(VacationType), page);
		}

		private void EndDateEvent(object s, EventArgs e)
		{
			var date = Vacation.End.ConvertToNSDate();
			ShowDatePicker(date);
			IsStartDate = false;
		}

		private void StartDateEvent(object s, EventArgs e)
		{
			var date = Vacation.Start.ConvertToNSDate();
			ShowDatePicker(date);
			IsStartDate = true;
		}

		private void ShowDatePicker(NSDate date)
		{
			DatePickerVacation.Hidden = false;
			DatePickerToolbar.Hidden = false;
			DatePickerVacation.SetDate(date, true);
		}

		private void HideDatePicker()
		{
			DatePickerToolbar.Hidden = true;
			DatePickerVacation.Hidden = true;
		}

		private void SaveButtonEvent(object sender, EventArgs e)
		{
			_vacationService.CreateVacationAsync(Vacation);
		}

		private void DatePickerStartButtonEvent()
		{
			var date = (DateTime)DatePickerVacation.Date;
			StartDay.SetTitle(date.Day.ToString(), UIControlState.Normal);
			StartMonth.SetTitle(date.ToShortMonth(), UIControlState.Normal);
			StartYear.SetTitle(date.Year.ToString(), UIControlState.Normal);
			Vacation.Start = date;
			DatePickerVacation.Hidden = true;
            DatePickerBar.Hidden = true;

        }

		partial void CancelButtonChoose(Foundation.NSObject sender)
		{
			HideDatePicker();
		}

		private void DatePickerEndButtonEvent()
		{
			var date = (DateTime)DatePickerVacation.Date;
			EndDay.SetTitle(date.Day.ToString(), UIControlState.Normal);
			EndMonth.SetTitle(date.ToShortMonth(), UIControlState.Normal);
			EndYear.SetTitle(date.Year.ToString(), UIControlState.Normal);
			Vacation.End = date;
			DatePickerVacation.Hidden = false;
			DatePickerBar.Hidden = true;
		}

		private void SwipeEvent(object sender, EventArgs e)
		{
			var page = (int)Page.CurrentPage;
			Vacation.VacationType = (VacationType)page;
			PageImage.Image = VacationTypeSetting.GetPicture(Vacation.VacationType);
			TypeText.Text = Enum.GetName(typeof(VacationType), page);
		}

		partial void ActionRight(Foundation.NSObject sender)
		{
			Page.CurrentPage -= 1;
			ChangeType();
		}

		partial void ActionLeft(Foundation.NSObject sender)
		{
			Page.CurrentPage += 1;
			ChangeType();
		}

		partial void DoneButtonChoose(Foundation.NSObject sender)
		{
			if (IsStartDate)
			{
				DatePickerStartButtonEvent();
				return;
			}
			DatePickerEndButtonEvent();

			HideDatePicker();
		}


		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<DetailVacationView, DetailViewModel>();

			bindingSet.Bind(StartDay)
			   .For("Title")
			   .To(vm => vm.StartDay);

			bindingSet.Bind(StartMonth)
			   .For("Title")
			   .To(vm => vm.StartMonth);

			bindingSet.Bind(StartYear)
			  .For("Title")
			  .To(vm => vm.StartYear);

			bindingSet.Bind(EndDay)
			  .For("Title")
			  .To(vm => vm.EndDay);

			bindingSet.Bind(EndMonth)
			  .For("Title")
			  .To(vm => vm.EndMonth);

			bindingSet.Bind(EndYear)
			  .For("Title")
			   .To(vm => vm.EndYear);

			bindingSet.Bind(StatusSegment)
			  .For("SelectedSegment")
			   .To(vm => vm.StatusButtonSelectedSegment);

			bindingSet.Bind(TypeText)
				.For("Text")
				.To(vm => vm.TypeText);

			bindingSet.Bind(Page)
				.For("CurrentPage")
				.To(vm => vm.Page);

			bindingSet.Apply();
		}

		private void SetVacation()
		{
			Vacation = _vacationService.GetExampleVacation();
		}
	}
}

