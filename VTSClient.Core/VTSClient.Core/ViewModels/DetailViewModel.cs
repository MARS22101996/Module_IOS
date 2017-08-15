using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Infrastructure.Extentions;
using VTSClient.Core.Infrastructure.TransportData;
using VTSClient.Core.Models;
using VTSClient.DAL.Enums;
using VTSClient.DAL.Repositories;

namespace VTSClient.Core.ViewModels
{
	public class DetailViewModel : MvxViewModel<VacationData>
	{
		private readonly IApiVacationService _vacationService;


		private IMvxCommand _changeStatusCommand;

		private IMvxCommand _swipeEventCommand;

		private IMvxCommand _startDayCommand;

		private bool _isStartDate;

		public bool IsDatePickerVacation { get; set; }

		public DateTime DatePickerVacationDate { get; set; }

		public bool IsDatePickerToolbar { get; set; }

		private VacationDto Vacation { get; set; }

		public string StartDay { get; set; }

		public string StartMonth { get; set; }

		public string StartYear { get; set; }

		public string EndDay { get; set; }

		public string EndMonth { get; set; }

		public string EndYear { get; set; }

		public int StatusButtonSelectedSegment { get; set; }

		public string TypeText { get; set; }

		public int Page { get; set; }

		public DetailViewModel()
		{
			AutoMapperCoreConfiguration.Configure();

			var repo = new CommonApiRepository();

			_vacationService = new ApiVacationService(repo);

		}

		public IMvxCommand ChangeStatusCommand => _changeStatusCommand ??
												 (_changeStatusCommand = new MvxCommand(
													 () =>
													 {
														 Vacation.VacationStatus = (StatusButtonSelectedSegment== 1) ? VacationStatus.Closed : VacationStatus.Approved;
													 }));

		public IMvxCommand SwipeEventCommand => _swipeEventCommand ??
										 (_swipeEventCommand = new MvxCommand(
											 SwipeEvent));


		public IMvxCommand StartDayCommand => _startDayCommand ??
										 (_startDayCommand = new MvxCommand(
											 StartDateEvent));

		public override async Task Initialize(VacationData parameter)
		{

		}

		private void StartDateEvent()
		{
			var date = Vacation.Start;
			ShowDatePicker(date);
			_isStartDate = true;
		}

		private void ShowDatePicker(DateTime date)
		{
			IsDatePickerVacation = false;
			IsDatePickerToolbar = false;
			DatePickerVacationDate = date;
		}

		private async  Task SetVacation()
		{
			var id = TransportData.GetId();

			if (id == default(Guid))
			{
				Vacation = _vacationService.GetExampleVacation();
			}
			else
			{
				Vacation =await  _vacationService.GetVacationByIdAsync(id);
			}
		}

		private void SetData()
		{			
			StartDay = Vacation.Start.Day.ToString();

			StartMonth = Vacation.Start.ToShortMonth();

			StartYear = Vacation.Start.Year.ToString();

			EndDay = Vacation.End.Day.ToString();

			EndMonth = Vacation.End.ToShortMonth();

			EndYear = Vacation.End.Year.ToString();

			StatusButtonSelectedSegment = Vacation.VacationStatus == VacationStatus.Approved ? 0 : 1;

			Page = (int) Vacation.VacationType;

			TypeText = Enum.GetName(typeof(VacationType), 0);

			DatePickerVacationDate = Vacation.Start;

		}

		private void SwipeEvent()
		{
			var page = Page;
			Vacation.VacationType = (VacationType)page;
			TypeText = Enum.GetName(typeof(VacationType), page);
		}

		public async Task Init(VacationData parameter)
		{
			TransportData.SetId(parameter.Id);

			//await SetVacation();

			//SetData();
		}
	}
}
