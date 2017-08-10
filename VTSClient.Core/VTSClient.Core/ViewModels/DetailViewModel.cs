using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Models;
using VTSClient.DAL.Entities;
using VTSClient.DAL.Enums;
using VTSClient.DAL.Repositories;

namespace VTSClient.Core.ViewModels
{
	public class DetailViewModel : MvxViewModel
	{
		private readonly IApiVacationService _vacationService;

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

			 SetVacation();

			 SetData();
		}

		private void SetVacation()
		{
			Vacation = _vacationService.GetExampleVacation();
		}

		private void SetData()
		{
			StartDay = Vacation.Start.Day.ToString();
			StartMonth = Vacation.Start.ToString("m");
			StartYear = Vacation.Start.Year.ToString();

			EndDay = Vacation.End.Day.ToString();
			EndMonth = Vacation.End.ToString("m");
			EndYear = Vacation.End.Year.ToString();

			StatusButtonSelectedSegment = Vacation.VacationStatus == VacationStatus.Approved ? 0 : 1;

			Page = (int) Vacation.VacationType;

			TypeText = Enum.GetName(typeof(VacationType), 0);
		}

	}
}
